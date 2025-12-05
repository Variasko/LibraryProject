from pydantic import BaseModel


class BookCreate(BaseModel):
    title: str
    author_id: int
    amount: int