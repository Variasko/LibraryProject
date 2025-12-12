from fastapi import APIRouter, Depends, HTTPException
from sqlalchemy import select, delete
from sqlalchemy.orm import Session, selectinload
from src.database.database import get_session
from src.database.models import Author, Book, BookIncoming, TakingBook
from src.schemas.Author.author_create import AuthorCreate
from src.schemas.Author.author_update import AuthorUpdate

author_router = APIRouter(prefix="/authors", tags=["Authors"])


@author_router.get(
    "/",
    summary="Получить всех авторов",
    description="Возвращает список всех авторов в библиотеке",
)
def get_authors(session: Session = Depends(get_session)):
    stmt = select(Author).options(selectinload(Author.books))
    result = session.execute(stmt)
    return result.scalars().all()


@author_router.get(
    "/{author_id}",
    summary="Получить автора по ID",
    description="Возвращает автора с указанным ID в библиотеке",
)
def get_author(author_id: int, session: Session = Depends(get_session)):
    stmt = select(Author).where(Author.id == author_id).options(selectinload(Author.books))
    result = session.execute(stmt)
    author = result.scalars().first()
    if not author:
        raise HTTPException(status_code=404, detail="Автор не найден")
    return author


@author_router.post(
    '/new_author',
    summary='Добавить нового автора',
    description='Добавляет нового автора в библиотеку',
)
def add_author(author: AuthorCreate, session: Session = Depends(get_session)):
    new_author = Author(**author.model_dump())
    session.add(new_author)
    session.commit()
    session.refresh(new_author)
    return new_author


@author_router.put(
    "/update_author/{author_id}",
    summary="Изменить автора",
    description="Изменяет данные автора в библиотеке",
)
def update_author(author_id: int, new_author: AuthorUpdate, session: Session = Depends(get_session)):
    stmt = select(Author).where(Author.id == author_id)
    result = session.execute(stmt)
    author = result.scalars().first()
    if not author:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Автор не найден")

    # Обновляем только непустые поля
    for var, value in new_author.model_dump(exclude_unset=True).items():
        setattr(author, var, value)

    session.commit()
    session.refresh(author)
    return author


@author_router.delete(
    "/delete_author/{author_id}",
    summary="Удалить автора",
    description="Удаляет автора из библиотеки. Удаление невозможно, если существуют книги этого автора.",
)
def delete_author(author_id: int, session: Session = Depends(get_session)):
    stmt = select(Author).where(Author.id == author_id)
    result = session.execute(stmt)
    author = result.scalars().first()
    if not author:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Автор не найден")

    # Проверяем, есть ли книги у этого автора
    stmt_books = select(Book).where(Book.author_id == author_id)
    result_books = session.execute(stmt_books)
    books = result_books.scalars().all()

    if books:
        from fastapi import HTTPException
        raise HTTPException(status_code=400, detail="Невозможно удалить автора: существуют книги этого автора.")

    session.delete(author)
    session.commit()
    return {"detail": "Автор успешно удалён"}


# --- НОВЫЙ ЭНДПОИНТ ---
@author_router.delete(
    "/delete_author/{author_id}/with_books",
    summary="Удалить автора и все его книги каскадно",
    description="Удаляет автора и все книги, поступления и взятия, связанные с ним.",
)
def delete_author_with_books(author_id: int, session: Session = Depends(get_session)):
    stmt = select(Author).where(Author.id == author_id)
    result = session.execute(stmt)
    author = result.scalars().first()
    if not author:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Автор не найден")

    # 1. Получаем все книги автора
    stmt_books = select(Book.id).where(Book.author_id == author_id)
    result_books = session.execute(stmt_books)
    book_ids = [row.id for row in result_books]

    if book_ids:
        # 2. Удаляем связанные записи из taking_books
        stmt_delete_takings = delete(TakingBook).where(TakingBook.book_id.in_(book_ids))
        session.execute(stmt_delete_takings)

        # 3. Удаляем связанные записи из book_incomings
        stmt_delete_incomings = delete(BookIncoming).where(BookIncoming.book_id.in_(book_ids))
        session.execute(stmt_delete_incomings)

        # 4. Удаляем книги
        stmt_delete_books = delete(Book).where(Book.id.in_(book_ids))
        session.execute(stmt_delete_books)

    # 5. Удаляем автора
    session.delete(author)
    session.commit()

    return {"detail": "Автор и все связанные данные успешно удалены"}
