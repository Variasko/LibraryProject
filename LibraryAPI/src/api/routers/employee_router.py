from fastapi import APIRouter, Depends
from sqlalchemy import select
from sqlalchemy.orm import Session
from src.database.database import get_session
from src.database.models import Employee, Post
from src.schemas.Employee.employee_create import EmployeeCreate
from src.schemas.Employee.employee_update import EmployeeUpdate

employee_router = APIRouter(
    prefix="/employees",
    tags=["Employees"]
)


def _get_post_or_404(session: Session, post_id: int) -> Post:
    """
    Вспомогательная функция для проверки существования должности.
    Вызывает HTTPException 404, если должность не найдена.
    """
    stmt = select(Post).where(Post.id == post_id)
    result = session.execute(stmt)
    post = result.scalars().first()
    if not post:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Должность не найдена")
    return post


@employee_router.get(
    "/",
    summary="Получить всех сотрудников",
    description="Возвращает список всех сотрудников библиотеки",
)
def get_employees(session: Session = Depends(get_session)):
    stmt = select(Employee)
    result = session.execute(stmt)
    employees = result.scalars().all()
    return employees


@employee_router.get(
    "/{employee_id}",
    summary="Получить сотрудника по ID",
    description="Возвращает сотрудника с указанным ID",
)
def get_employee(employee_id: int, session: Session = Depends(get_session)):
    stmt = select(Employee).where(Employee.id == employee_id)
    result = session.execute(stmt)
    employee = result.scalars().first()
    if not employee:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Сотрудник не найден")
    return employee


@employee_router.post(
    "/new_employee",
    summary="Добавить сотрудника",
    description="Добавляет нового сотрудника в библиотеку",
)
def add_employee(employee: EmployeeCreate, session: Session = Depends(get_session)):
    # Проверяем, существует ли должность
    _get_post_or_404(session, employee.post_id)

    new_employee = Employee(**employee.model_dump())
    session.add(new_employee)
    session.commit()
    session.refresh(new_employee)
    return new_employee


@employee_router.put(
    "/update_employee/{employee_id}",
    summary="Изменить сотрудника",
    description="Изменяет данные сотрудника в библиотеке",
)
def update_employee(employee_id: int, new_employee: EmployeeUpdate, session: Session = Depends(get_session)):
    stmt = select(Employee).where(Employee.id == employee_id)
    result = session.execute(stmt)
    employee = result.scalars().first()
    if not employee:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Сотрудник не найден")

    # Проверяем, если меняется должность
    if new_employee.post_id is not None:
        _get_post_or_404(session, new_employee.post_id)

    # Обновляем только непустые поля
    for var, value in new_employee.model_dump(exclude_unset=True).items():
        setattr(employee, var, value)

    session.commit()
    session.refresh(employee)
    return employee


@employee_router.delete(
    "/delete_employee/{employee_id}",
    summary="Удалить сотрудника",
    description="Удаляет сотрудника из библиотеки",
)
def delete_employee(employee_id: int, session: Session = Depends(get_session)):
    stmt = select(Employee).where(Employee.id == employee_id)
    result = session.execute(stmt)
    employee = result.scalars().first()
    if not employee:
        from fastapi import HTTPException
        raise HTTPException(status_code=404, detail="Сотрудник не найден")
    session.delete(employee)
    session.commit()
    return {"detail": "Сотрудник успешно удалён"}
