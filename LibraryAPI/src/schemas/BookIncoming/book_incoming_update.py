from pydantic import BaseModel
from datetime import date


class BookIncomingUpdate(BaseModel):
    book_id: int | None = None
    amount: int | None = None  # Должно быть > 0, проверка будет в роутере
    incoming_date: date | None = None
