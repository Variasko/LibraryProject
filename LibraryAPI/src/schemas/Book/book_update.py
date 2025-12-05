from pydantic import BaseModel


class BookUpdate(BaseModel):
    title: str | None = None
    author_id: int | None = None
    amount: int | None = None
