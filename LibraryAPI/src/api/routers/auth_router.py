from fastapi import APIRouter, Depends
from sqlalchemy import select
from sqlalchemy.orm import Session
from src.database.database import get_session
from src.database.models import Employee
from src.schemas.Auth.auth_model import AuthModel

auth_router = APIRouter(prefix='/auth', tags=['Auth'])


@auth_router.post('/')
def auth(authorizationData: AuthModel, session: Session = Depends(get_session)):
    # допущение: пароли не хешируем
    stmt = (select(Employee)
            .where(Employee.login == authorizationData.login)
            .where(Employee.password == authorizationData.password))
    result = session.execute(stmt)
    employee = result.scalar_one_or_none()
    if not employee:
        from fastapi import HTTPException
        raise HTTPException(status_code=401, detail='Неправильные логин или пароль')
    return employee
