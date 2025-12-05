# src/api/routers/book_router.py
from fastapi import APIRouter, Depends
from sqlalchemy import select
from sqlalchemy.orm import Session
from src.database.database import get_session
from src.database.models import Book, Author
from src.schemas.Book.book_create import BookCreate
from src.schemas.Book.book_update import BookUpdate  # <-- Новый импорт

book_router = APIRouter(
    prefix="/books",
    tags=["Books"],
)


def _get_author_or_404(session: Session, author_id: int) -> Author:
    stmt = select(Author).where(Author.id == author_id)
    result = session.execute(stmt)
    author = result.scalars().first()
    if not author:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Автор не найден")
    return author


@book_router.get(
    "/",
    summary="Получить все книги",
    description="Возвращает список всех книг в библиотеке",
)
def get_books(session: Session = Depends(get_session)):
    stmt = select(Book)
    result = session.execute(stmt)
    books = result.scalars().all()
    return books


@book_router.get(
    "/{book_id}",
    summary="Получить книгу по ID",
    description="Возвращает книгу с указанным ID в библиотеке",
)
def get_book(book_id: int, session: Session = Depends(get_session)):
    stmt = select(Book).where(Book.id == book_id)
    result = session.execute(stmt)
    book = result.scalars().first()
    if not book:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Книга не найдена")
    return book


@book_router.post(
    "/new_book",
    summary="Добавить книгу",
    description="Добавляет книгу в библиотеку",
)
def add_book(book: BookCreate, session: Session = Depends(get_session)):
    if book.amount < 0:
        from fastapi import HTTPException
        raise HTTPException(status_code=400, detail="Количество книг не может быть меньше нуля")

    _get_author_or_404(session, book.author_id)

    new_book = Book(**book.model_dump())
    session.add(new_book)
    session.commit()
    session.refresh(new_book)
    return new_book


@book_router.put(
    "/update_book/{book_id}",
    summary="Изменить книгу",
    description="Изменяет данные книги в библиотеке",
)
def update_book(book_id: int, new_book: BookUpdate, session: Session = Depends(get_session)):
    stmt = select(Book).where(Book.id == book_id)
    result = session.execute(stmt)
    book = result.scalars().first()
    if not book:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Книга не найдена")

    if new_book.amount is not None and new_book.amount < 0:
        from fastapi import HTTPException
        raise HTTPException(status_code=400, detail="Количество книг не может быть меньше нуля")

    # Проверяем, если меняется автор
    if new_book.author_id is not None:
        _get_author_or_404(session, new_book.author_id)

    # Обновляем только непустые поля
    for var, value in new_book.model_dump(exclude_unset=True).items():
        setattr(book, var, value)

    session.commit()
    session.refresh(book)
    return book


@book_router.delete(
    "/delete_book/{book_id}",
    summary="Удалить книгу",
    description="Удаляет книгу из библиотеки",
)
def delete_book(book_id: int, session: Session = Depends(get_session)):
    stmt = select(Book).where(Book.id == book_id)
    result = session.execute(stmt)
    book = result.scalars().first()
    if not book:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Книга не найдена")
    session.delete(book)
    session.commit()
    return {"detail": "Книга успешно удалена"}
