from pydantic import BaseModel
from datetime import date


class BookIncomingCreate(BaseModel):
    book_id: int
    amount: int  # Должно быть > 0, проверка будет в роутере
    incoming_date: date  # Обязательное поле
