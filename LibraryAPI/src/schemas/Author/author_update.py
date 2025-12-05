from pydantic import BaseModel


class AuthorUpdate(BaseModel):
    surname: str | None = None
    name: str | None = None
    patronymic: str | None = None
    birth_year: int | None = None
    death_year: int | None = None
