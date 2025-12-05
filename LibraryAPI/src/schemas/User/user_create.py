from pydantic import BaseModel
from datetime import date


class UserCreate(BaseModel):
    surname: str
    name: str
    patronymic: str | None = None
    birthday: date | None = None
    registration_date: date  # Обязательное поле
