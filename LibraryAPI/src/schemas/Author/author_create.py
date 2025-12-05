from pydantic import BaseModel


class AuthorCreate(BaseModel):
    surname: str
    name: str
    patronymic: str
    birth_year: int
    death_year: int
