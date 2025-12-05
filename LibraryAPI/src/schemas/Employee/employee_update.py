from pydantic import BaseModel
from datetime import date

class EmployeeUpdate(BaseModel):
    surname: str | None = None
    name: str | None = None
    patronymic: str | None = None
    birthday: date | None = None
    post_id: int | None = None
    login: str | None = None
    password: str | None = None  # В реальности — хешировать!