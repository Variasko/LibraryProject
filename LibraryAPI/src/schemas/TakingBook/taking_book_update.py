from pydantic import BaseModel
from datetime import date


class TakingBookUpdate(BaseModel):
    book_id: int | None = None
    user_id: int | None = None
    employee_id: int | None = None
    taking_date: date | None = None
    is_returned: bool | None = None
    return_date: date | None = None
