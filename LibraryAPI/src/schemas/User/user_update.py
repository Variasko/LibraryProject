from pydantic import BaseModel
from datetime import date


class UserUpdate(BaseModel):
    surname: str | None = None
    name: str | None = None
    patronymic: str | None = None
    birthday: date | None = None
    registration_date: date | None = None
