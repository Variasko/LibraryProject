from fastapi import APIRouter

from src.api.routers import (database_router, book_router, author_router,
                             post_router, employee_router, user_router,
                             book_incoming_router, taking_book_router,
                             auth_router)

main_router = APIRouter()

main_router.include_router(database_router.database_router)
main_router.include_router(author_router.author_router)
main_router.include_router(author_router.author_router)
main_router.include_router(book_router.book_router)
main_router.include_router(book_incoming_router.book_incoming_router)
main_router.include_router(employee_router.employee_router)
main_router.include_router(post_router.post_router)
main_router.include_router(taking_book_router.taking_book_router)
main_router.include_router(user_router.user_router)
