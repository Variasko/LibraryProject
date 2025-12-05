from pydantic import BaseModel
from datetime import date


class TakingBookCreate(BaseModel):
    book_id: int
    user_id: int
    employee_id: int
    taking_date: date  # Обязательное поле
    is_returned: bool = False  # По умолчанию книга не возвращена
    return_date: date | None = None  # Может быть пустым, если не возвращена
