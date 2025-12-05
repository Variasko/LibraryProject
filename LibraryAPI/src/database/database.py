# src/database/database.py
from sqlalchemy.orm import sessionmaker
from sqlalchemy import create_engine
from pathlib import Path
from . import models

# Убедимся, что директория существует
DB_PATH = Path(__file__).parent / 'database.db'
DB_PATH.parent.mkdir(parents=True, exist_ok=True)

DATABASE_URL = f"sqlite:///{DB_PATH}"

engine = create_engine(DATABASE_URL)
new_session = sessionmaker(bind=engine, expire_on_commit=False)


def get_session():
    with new_session() as session:
        yield session
