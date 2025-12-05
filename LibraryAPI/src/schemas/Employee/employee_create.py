from pydantic import BaseModel
from datetime import date

class EmployeeCreate(BaseModel):
    surname: str
    name: str
    patronymic: str | None = None
    birthday: date | None = None
    post_id: int
    login: str
    password: str  # Допущение — просто строка. В реальности — хешировать!