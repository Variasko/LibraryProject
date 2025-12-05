from fastapi import FastAPI

from config import host, port
from src.database.models import Base
from src.api.routers import main_router
from src.database.database import engine

app = FastAPI()

Base.metadata.create_all(bind=engine)

app.include_router(main_router)

if __name__ == '__main__':
    from uvicorn import *
    run(app, host=host, port=port)