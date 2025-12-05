from fastapi import APIRouter

from src.database.database import engine
from src.database.models import Base

database_router = APIRouter(
    prefix="/database",
    tags=["Database"]
)


@database_router.get(
    "/init_database",
    summary='Создание таблиц БД',
    description="Удаление имеющихся таблиц и создание новых",
)
def init_database():
    try:
        with engine.begin() as conn:
            conn.run_sync(Base.metadata.drop_all)
            conn.run_sync(Base.metadata.create_all)

        return {
            "message": "База данных создана"
        }
    except Exception as e:
        return {
            "message": str(e)
        }
