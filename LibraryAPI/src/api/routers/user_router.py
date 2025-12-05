from fastapi import APIRouter, Depends
from sqlalchemy import select
from sqlalchemy.orm import Session
from src.database.database import get_session
from src.database.models import User
from src.schemas.User.user_create import UserCreate
from src.schemas.User.user_update import UserUpdate

user_router = APIRouter(
    prefix="/users",
    tags=["Users"]
)


@user_router.get(
    "/",
    summary="Получить всех пользователей",
    description="Возвращает список всех пользователей",
)
def get_users(session: Session = Depends(get_session)):
    stmt = select(User)
    result = session.execute(stmt)
    users = result.scalars().all()
    return users


@user_router.get(
    "/{user_id}",
    summary="Получить пользователя по ID",
    description="Возвращает пользователя с указанным ID",
)
def get_user(user_id: int, session: Session = Depends(get_session)):
    stmt = select(User).where(User.id == user_id)
    result = session.execute(stmt)
    user = result.scalars().first()
    if not user:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Пользователь не найден")
    return user


@user_router.post(
    "/new_user",
    summary="Добавить пользователя",
    description="Добавляет нового пользователя",
)
def add_user(user: UserCreate, session: Session = Depends(get_session)):
    new_user = User(**user.model_dump())
    session.add(new_user)
    session.commit()
    session.refresh(new_user)
    return new_user


@user_router.put(
    "/update_user/{user_id}",
    summary="Изменить пользователя",
    description="Изменяет данные пользователя",
)
def update_user(user_id: int, new_user: UserUpdate, session: Session = Depends(get_session)):
    stmt = select(User).where(User.id == user_id)
    result = session.execute(stmt)
    user = result.scalars().first()
    if not user:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Пользователь не найден")

    # Обновляем только непустые поля
    for var, value in new_user.model_dump(exclude_unset=True).items():
        setattr(user, var, value)

    session.commit()
    session.refresh(user)
    return user


@user_router.delete(
    "/delete_user/{user_id}",
    summary="Удалить пользователя",
    description="Удаляет пользователя",
)
def delete_user(user_id: int, session: Session = Depends(get_session)):
    stmt = select(User).where(User.id == user_id)
    result = session.execute(stmt)
    user = result.scalars().first()
    if not user:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Пользователь не найден")
    session.delete(user)
    session.commit()
    return {"detail": "Пользователь успешно удалён"}
