# src/api/routers/book_incoming_router.py
from fastapi import APIRouter, Depends
from sqlalchemy import select
from sqlalchemy.orm import Session
from src.database.database import get_session
from src.database.models import BookIncoming, Book
from src.schemas.BookIncoming.book_incoming_create import BookIncomingCreate
from src.schemas.BookIncoming.book_incoming_update import BookIncomingUpdate

book_incoming_router = APIRouter(
    prefix="/book_incomings",
    tags=["Book Incomings"]
)


def _get_book_or_404(session: Session, book_id: int) -> Book:
    """
    Вспомогательная функция для проверки существования книги.
    Вызывает HTTPException 404, если книга не найдена.
    """
    stmt = select(Book).where(Book.id == book_id)
    result = session.execute(stmt)
    book = result.scalars().first()
    if not book:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Книга не найдена")
    return book


@book_incoming_router.get(
    "/",
    summary="Получить все поступления книг",
    description="Возвращает список всех поступлений книг",
)
def get_book_incomings(session: Session = Depends(get_session)):
    stmt = select(BookIncoming)
    result = session.execute(stmt)
    book_incomings = result.scalars().all()
    return book_incomings


@book_incoming_router.get(
    "/{incoming_id}",
    summary="Получить поступление по ID",
    description="Возвращает поступление с указанным ID",
)
def get_book_incoming(incoming_id: int, session: Session = Depends(get_session)):
    stmt = select(BookIncoming).where(BookIncoming.id == incoming_id)
    result = session.execute(stmt)
    book_incoming = result.scalars().first()
    if not book_incoming:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Поступление не найдено")
    return book_incoming


@book_incoming_router.post(
    "/new_incoming",
    summary="Добавить поступление книги",
    description="Добавляет новое поступление книги",
)
def add_book_incoming(incoming: BookIncomingCreate, session: Session = Depends(get_session)):
    if incoming.amount <= 0:
        from fastapi import HTTPException
        raise HTTPException(status_code=400, detail="Количество книг в поступлении должно быть больше 0")

    # Проверяем, существует ли книга
    _get_book_or_404(session, incoming.book_id)

    new_incoming = BookIncoming(**incoming.model_dump())
    session.add(new_incoming)
    session.commit()
    session.refresh(new_incoming)
    return new_incoming


@book_incoming_router.put(
    "/update_incoming/{incoming_id}",
    summary="Изменить поступление книги",
    description="Изменяет данные поступления книги",
)
def update_book_incoming(incoming_id: int, new_incoming: BookIncomingUpdate, session: Session = Depends(get_session)):
    stmt = select(BookIncoming).where(BookIncoming.id == incoming_id)
    result = session.execute(stmt)
    incoming = result.scalars().first()
    if not incoming:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Поступление не найдено")

    if new_incoming.amount is not None and new_incoming.amount <= 0:
        from fastapi import HTTPException
        raise HTTPException(status_code=400, detail="Количество книг в поступлении должно быть больше 0")

    # Проверяем, если меняется книга
    if new_incoming.book_id is not None:
        _get_book_or_404(session, new_incoming.book_id)

    # Обновляем только непустые поля
    for var, value in new_incoming.model_dump(exclude_unset=True).items():
        setattr(incoming, var, value)

    session.commit()
    session.refresh(incoming)
    return incoming


@book_incoming_router.delete(
    "/delete_incoming/{incoming_id}",
    summary="Удалить поступление книги",
    description="Удаляет поступление книги",
)
def delete_book_incoming(incoming_id: int, session: Session = Depends(get_session)):
    stmt = select(BookIncoming).where(BookIncoming.id == incoming_id)
    result = session.execute(stmt)
    incoming = result.scalars().first()
    if not incoming:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Поступление не найдено")
    session.delete(incoming)
    session.commit()
    return {"detail": "Поступление успешно удалено"}
