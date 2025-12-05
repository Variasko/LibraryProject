# LibraryAPI

Серверная часть приложения по управлению библиотекой. Предоставляет REST API для взаимодействия с сущностями: книги, авторы, сотрудники, пользователи, должности, поступления книг и взятия книг.

## Запуск

1.  **Настройка конфигурации:**
    *   Перед запуском откройте файл `src/app_config.toml`.
    *   Убедитесь, что параметр `is_debug` выставлен в нужное значение:
        *   `is_debug=1` — для режима отладки.
        *   `is_debug=0` — для продакшн режима.
    *   В режиме отладки (`is_debug=1`) обычно используется локальный хост `127.0.0.1`. В продакшн режиме (`is_debug=0`) хост будет взят из первого элемента списка `hosts`, убедитесь, что он доступен.

2.  **Установка зависимостей:**
    *   Убедитесь, что у вас установлен `uv`. Если нет, установите его (например, через `pip install uv` или соответствующий менеджер пакетов).
    *   Перейдите в папку `src` вашего проекта (там, где находится `pyproject.toml`).
    *   Выполните команду `uv sync`, чтобы установить все зависимости, указанные в `pyproject.toml`.

3.  **Запуск API:**
    *   Убедитесь, что вы находитесь в **корневой папке** проекта (там, где находится `main.py`).
    *   Выполните команду:
        ```bash
        python main.py
        ```
        На Windows это будет та же команда: `python main.py`. Убедитесь, что используется Python из виртуального окружения, созданного `uv` (например, активируйте его, если нужно, или `uv run python main.py`).

## Таблица эндпоинтов

| Номер | Эндпоинт | Метод | Формат отправки данных (Тело) | Формат возвращаемых данных | Описание |
| :--- | :--- | :--- | :--- | :--- | :--- |
| 1 | `/database/init_database` | `GET` | - | `{}` | Создание таблиц БД. Удаление имеющихся таблиц и создание новых. |
| 2 | `/authors/` | `GET` | - | `[{"id": 1, "surname": "string", "name": "string", ...}, ...]` | Получить всех авторов. Возвращает список всех авторов в библиотеке. |
| 3 | `/authors/{author_id}` | `GET` | - | `{"id": 1, "surname": "string", "name": "string", ...}` | Получить автора по ID. Возвращает автора с указанным ID в библиотеке. |
| 4 | `/authors/new_author` | `POST` | `{"surname": "string", "name": "string", "patronymic": "string", "birth_year": 0, "death_year": 0}` | `{"id": 1, "surname": "string", "name": "string", ...}` | Добавить нового автора. Добавляет нового автора в библиотеку. |
| 5 | `/authors/update_author/{author_id}` | `PUT` | `{"surname": "string", "name": "string", "patronymic": "string", "birth_year": 0, "death_year": 0}` | `{"id": 1, "surname": "string", "name": "string", ...}` | Изменить автора. Изменяет данные автора в библиотеке. |
| 6 | `/authors/delete_author/{author_id}` | `DELETE` | - | `{"detail": "string"}` | Удалить автора. Удаляет автора из библиотеки. Удаление невозможно, если существуют книги этого автора. |
| 7 | `/authors/delete_author/{author_id}/with_books` | `DELETE` | - | `{"detail": "string"}` | Удалить автора и все его книги каскадно. Удаляет автора и все книги, поступления и взятия, связанные с ним. |
| 8 | `/books/` | `GET` | - | `[{"id": 1, "title": "string", "author_id": 0, "amount": 0}, ...]` | Получить все книги. Возвращает список всех книг в библиотеке. |
| 9 | `/books/{book_id}` | `GET` | - | `{"id": 1, "title": "string", "author_id": 0, "amount": 0}` | Получить книгу по ID. Возвращает книгу с указанным ID в библиотеке. |
| 10 | `/books/new_book` | `POST` | `{"title": "string", "author_id": 0, "amount": 0}` | `{"id": 1, "title": "string", "author_id": 0, "amount": 0}` | Добавить книгу. Добавляет книгу в библиотеку. |
| 11 | `/books/update_book/{book_id}` | `PUT` | `{"title": "string", "author_id": 0, "amount": 0}` | `{"id": 1, "title": "string", "author_id": 0, "amount": 0}` | Изменить книгу. Изменяет данные книги в библиотеке. |
| 12 | `/books/delete_book/{book_id}` | `DELETE` | - | `{"detail": "string"}` | Удалить книгу. Удаляет книгу из библиотеки. |
| 13 | `/posts/` | `GET` | - | `[{"id": 1, "name": "string"}, ...]` | Получить все должности. Возвращает список всех должностей в библиотеке. |
| 14 | `/posts/{post_id}` | `GET` | - | `{"id": 1, "name": "string"}` | Получить должность по ID. Возвращает должность с указанным ID. |
| 15 | `/posts/new_post` | `POST` | `{"name": "string"}` | `{"id": 1, "name": "string"}` | Добавить должность. Добавляет новую должность в библиотеку. |
| 16 | `/posts/update_post/{post_id}` | `PUT` | `{"name": "string"}` | `{"id": 1, "name": "string"}` | Изменить должность. Изменяет данные должности в библиотеке. |
| 17 | `/posts/delete_post/{post_id}` | `DELETE` | - | `{"detail": "string"}` | Удалить должность. Удаляет должность из библиотеки. |
| 18 | `/employees/` | `GET` | - | `[{"id": 1, "surname": "string", "name": "string", ...}, ...]` | Получить всех сотрудников. Возвращает список всех сотрудников библиотеки. |
| 19 | `/employees/{employee_id}` | `GET` | - | `{"id": 1, "surname": "string", "name": "string", ...}` | Получить сотрудника по ID. Возвращает сотрудника с указанным ID. |
| 20 | `/employees/new_employee` | `POST` | `{"surname": "string", "name": "string", "patronymic": "string", "birthday": "2023-01-01", "post_id": 0, "login": "string", "password": "string"}` | `{"id": 1, "surname": "string", "name": "string", ...}` | Добавить сотрудника. Добавляет нового сотрудника в библиотеку. |
| 21 | `/employees/update_employee/{employee_id}` | `PUT` | `{"surname": "string", "name": "string", "patronymic": "string", "birthday": "2023-01-01", "post_id": 0, "login": "string", "password": "string"}` | `{"id": 1, "surname": "string", "name": "string", ...}` | Изменить сотрудника. Изменяет данные сотрудника в библиотеке. |
| 22 | `/employees/delete_employee/{employee_id}` | `DELETE` | - | `{"detail": "string"}` | Удалить сотрудника. Удаляет сотрудника из библиотеки. |
| 23 | `/users/` | `GET` | - | `[{"id": 1, "surname": "string", "name": "string", ...}, ...]` | Получить всех пользователей. Возвращает список всех пользователей. |
| 24 | `/users/{user_id}` | `GET` | - | `{"id": 1, "surname": "string", "name": "string", ...}` | Получить пользователя по ID. Возвращает пользователя с указанным ID. |
| 25 | `/users/new_user` | `POST` | `{"surname": "string", "name": "string", "patronymic": "string", "birthday": "2023-01-01", "registration_date": "2023-01-01"}` | `{"id": 1, "surname": "string", "name": "string", ...}` | Добавить пользователя. Добавляет нового пользователя. |
| 26 | `/users/update_user/{user_id}` | `PUT` | `{"surname": "string", "name": "string", "patronymic": "string", "birthday": "2023-01-01", "registration_date": "2023-01-01"}` | `{"id": 1, "surname": "string", "name": "string", ...}` | Изменить пользователя. Изменяет данные пользователя. |
| 27 | `/users/delete_user/{user_id}` | `DELETE` | - | `{"detail": "string"}` | Удалить пользователя. Удаляет пользователя. |
| 28 | `/book_incomings/` | `GET` | - | `[{"id": 1, "book_id": 0, "amount": 0, "incoming_date": "2023-01-01"}, ...]` | Получить все поступления книг. Возвращает список всех поступлений книг. |
| 29 | `/book_incomings/{incoming_id}` | `GET` | - | `{"id": 1, "book_id": 0, "amount": 0, "incoming_date": "2023-01-01"}` | Получить поступление по ID. Возвращает поступление с указанным ID. |
| 30 | `/book_incomings/new_incoming` | `POST` | `{"book_id": 0, "amount": 0, "incoming_date": "2023-01-01"}` | `{"id": 1, "book_id": 0, "amount": 0, "incoming_date": "2023-01-01"}` | Добавить поступление книги. Добавляет новое поступление книги. |
| 31 | `/book_incomings/update_incoming/{incoming_id}` | `PUT` | `{"book_id": 0, "amount": 0, "incoming_date": "2023-01-01"}` | `{"id": 1, "book_id": 0, "amount": 0, "incoming_date": "2023-01-01"}` | Изменить поступление книги. Изменяет данные поступления книги. |
| 32 | `/book_incomings/delete_incoming/{incoming_id}` | `DELETE` | - | `{"detail": "string"}` | Удалить поступление книги. Удаляет поступление книги. |
| 33 | `/taking_books/` | `GET` | - | `[{"id": 1, "book_id": 0, "user_id": 0, "employee_id": 0, "taking_date": "2023-01-01", "is_returned": true, "return_date": "2023-01-01"}, ...]` | Получить все взятия книг. Возвращает список всех взятий книг. |
| 34 | `/taking_books/{taking_id}` | `GET` | - | `{"id": 1, "book_id": 0, "user_id": 0, "employee_id": 0, "taking_date": "2023-01-01", "is_returned": true, "return_date": "2023-01-01"}` | Получить взятие книги по ID. Возвращает взятие книги с указанным ID. |
| 35 | `/taking_books/new_taking` | `POST` | `{"book_id": 0, "user_id": 0, "employee_id": 0, "taking_date": "2023-01-01", "is_returned": true, "return_date": "2023-01-01"}` | `{"id": 1, "book_id": 0, "user_id": 0, "employee_id": 0, "taking_date": "2023-01-01", "is_returned": true, "return_date": "2023-01-01"}` | Добавить взятие книги. Добавляет новое взятие книги пользователем. |
| 36 | `/taking_books/update_taking/{taking_id}` | `PUT` | `{"book_id": 0, "user_id": 0, "employee_id": 0, "taking_date": "2023-01-01", "is_returned": true, "return_date": "2023-01-01"}` | `{"id": 1, "book_id": 0, "user_id": 0, "employee_id": 0, "taking_date": "2023-01-01", "is_returned": true, "return_date": "2023-01-01"}` | Изменить взятие книги. Изменяет данные взятия книги. |
| 37 | `/taking_books/delete_taking/{taking_id}` | `DELETE` | - | `{"detail": "string"}` | Удалить взятие книги. Удаляет взятие книги. |
