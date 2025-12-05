# src/api/routers/post_router.py
from fastapi import APIRouter, Depends
from sqlalchemy import select
from sqlalchemy.orm import Session
from src.database.database import get_session
from src.database.models import Post
from src.schemas.Post.post_create import PostCreate
from src.schemas.Post.post_update import PostUpdate  # <-- Новый импорт

post_router = APIRouter(
    prefix="/posts",
    tags=["Posts"]
)


@post_router.get(
    "/",
    summary="Получить все должности",
    description="Возвращает список всех должностей в библиотеке",
)
def get_posts(session: Session = Depends(get_session)):
    stmt = select(Post)
    result = session.execute(stmt)
    posts = result.scalars().all()
    return posts


@post_router.get(
    "/{post_id}",
    summary="Получить должность по ID",
    description="Возвращает должность с указанным ID",
)
def get_post(post_id: int, session: Session = Depends(get_session)):
    stmt = select(Post).where(Post.id == post_id)
    result = session.execute(stmt)
    post = result.scalars().first()
    if not post:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Должность не найдена")
    return post


@post_router.post(
    "/new_post",
    summary="Добавить должность",
    description="Добавляет новую должность в библиотеку",
)
def add_post(post: PostCreate, session: Session = Depends(get_session)):
    new_post = Post(**post.model_dump())
    session.add(new_post)
    session.commit()
    session.refresh(new_post)
    return new_post


@post_router.put(
    "/update_post/{post_id}",
    summary="Изменить должность",
    description="Изменяет данные должности в библиотеке",
)
def update_post(post_id: int, new_post: PostUpdate, session: Session = Depends(get_session)):
    stmt = select(Post).where(Post.id == post_id)
    result = session.execute(stmt)
    post = result.scalars().first()
    if not post:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Должность не найдена")

    # Обновляем только непустые поля
    for var, value in new_post.model_dump(exclude_unset=True).items():
        setattr(post, var, value)

    session.commit()
    session.refresh(post)
    return post


@post_router.delete(
    "/delete_post/{post_id}",
    summary="Удалить должность",
    description="Удаляет должность из библиотеки",
)
def delete_post(post_id: int, session: Session = Depends(get_session)):
    stmt = select(Post).where(Post.id == post_id)
    result = session.execute(stmt)
    post = result.scalars().first()
    if not post:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Должность не найдена")
    session.delete(post)
    session.commit()
    return {"detail": "Должность успешно удалена"}
