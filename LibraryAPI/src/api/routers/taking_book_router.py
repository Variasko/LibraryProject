# src/api/routers/taking_book_router.py
from fastapi import APIRouter, Depends
from sqlalchemy import select
from sqlalchemy.orm import Session
from src.database.database import get_session
from src.database.models import TakingBook, Book, User, Employee
from src.schemas.TakingBook.taking_book_create import TakingBookCreate
from src.schemas.TakingBook.taking_book_update import TakingBookUpdate

taking_book_router = APIRouter(
    prefix="/taking_books",
    tags=["Taking Books"]
)


def _get_book_or_404(session: Session, book_id: int) -> Book:
    stmt = select(Book).where(Book.id == book_id)
    result = session.execute(stmt)
    book = result.scalars().first()
    if not book:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Книга не найдена")
    return book


def _get_user_or_404(session: Session, user_id: int) -> User:
    stmt = select(User).where(User.id == user_id)
    result = session.execute(stmt)
    user = result.scalars().first()
    if not user:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Пользователь не найден")
    return user


def _get_employee_or_404(session: Session, employee_id: int) -> Employee:
    stmt = select(Employee).where(Employee.id == employee_id)
    result = session.execute(stmt)
    employee = result.scalars().first()
    if not employee:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Сотрудник не найден")
    return employee


@taking_book_router.get(
    "/",
    summary="Получить все взятия книг",
    description="Возвращает список всех взятий книг",
)
def get_taking_books(session: Session = Depends(get_session)):
    stmt = select(TakingBook)
    result = session.execute(stmt)
    taking_books = result.scalars().all()
    return taking_books


@taking_book_router.get(
    "/{taking_id}",
    summary="Получить взятие книги по ID",
    description="Возвращает взятие книги с указанным ID",
)
def get_taking_book(taking_id: int, session: Session = Depends(get_session)):
    stmt = select(TakingBook).where(TakingBook.id == taking_id)
    result = session.execute(stmt)
    taking_book = result.scalars().first()
    if not taking_book:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Взятие книги не найдено")
    return taking_book


@taking_book_router.post(
    "/new_taking",
    summary="Добавить взятие книги",
    description="Добавляет новое взятие книги пользователем",
)
def add_taking_book(taking: TakingBookCreate, session: Session = Depends(get_session)):
    # Проверяем, существуют ли книга, пользователь и сотрудник
    _get_book_or_404(session, taking.book_id)
    _get_user_or_404(session, taking.user_id)
    _get_employee_or_404(session, taking.employee_id)

    new_taking = TakingBook(**taking.model_dump())
    session.add(new_taking)
    session.commit()
    session.refresh(new_taking)
    return new_topic


@taking_book_router.put(
    "/update_taking/{taking_id}",
    summary="Изменить взятие книги",
    description="Изменяет данные взятия книги",
)
def update_taking_book(taking_id: int, new_taking: TakingBookUpdate, session: Session = Depends(get_session)):
    stmt = select(TakingBook).where(TakingBook.id == taking_id)
    result = session.execute(stmt)
    taking = result.scalars().first()
    if not taking:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Взятие книги не найдено")

    # Проверяем, если меняется книга, пользователь или сотрудник
    if new_taking.book_id is not None:
        _get_book_or_404(session, new_taking.book_id)
    if new_taking.user_id is not None:
        _get_user_or_404(session, new_taking.user_id)
    if new_taking.employee_id is not None:
        _get_employee_or_404(session, new_taking.employee_id)

    # Обновляем только непустые поля
    for var, value in new_taking.model_dump(exclude_unset=True).items():
        setattr(taking, var, value)

    session.commit()
    session.refresh(taking)
    return taking


@taking_book_router.delete(
    "/delete_taking/{taking_id}",
    summary="Удалить взятие книги",
    description="Удаляет взятие книги",
)
def delete_taking_book(taking_id: int, session: Session = Depends(get_session)):
    stmt = select(TakingBook).where(TakingBook.id == taking_id)
    result = session.execute(stmt)
    taking = result.scalars().first()
    if not taking:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Взятие книги не найдено")
    session.delete(taking)
    session.commit()
    return {"detail": "Взятие книги успешно удалено"}
