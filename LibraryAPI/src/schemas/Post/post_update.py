from pydantic import BaseModel

class PostUpdate(BaseModel):
    name: str | None = None