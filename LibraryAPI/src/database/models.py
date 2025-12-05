from sqlalchemy import Column, Integer, String, Date, Boolean, ForeignKey, CheckConstraint
from sqlalchemy.orm import relationship
from sqlalchemy.orm import DeclarativeBase


class Base(DeclarativeBase): pass


class Author(Base):
    __tablename__ = 'authors'

    id = Column(Integer, primary_key=True, autoincrement=True)
    surname = Column(String(100), nullable=False)
    name = Column(String(100), nullable=False)
    patronymic = Column(String(100))
    birth_year = Column(Integer)
    death_year = Column(Integer)

    books = relationship("Book", back_populates="author")


class Book(Base):
    __tablename__ = 'books'

    id = Column(Integer, primary_key=True, autoincrement=True)
    title = Column(String(200), nullable=False)
    author_id = Column(Integer, ForeignKey('authors.id'), nullable=False)
    amount = Column(Integer, CheckConstraint('amount >= 0'), nullable=False)

    author = relationship("Author", back_populates="books")
    takings = relationship("TakingBook", back_populates="book")
    incoming_records = relationship("BookIncoming", back_populates="book")


class Post(Base):
    __tablename__ = 'posts'

    id = Column(Integer, primary_key=True, autoincrement=True)
    name = Column(String(100), nullable=False)

    employees = relationship("Employee", back_populates="post")


class Employee(Base):
    __tablename__ = 'employees'

    id = Column(Integer, primary_key=True, autoincrement=True)
    surname = Column(String(100), nullable=False)
    name = Column(String(100), nullable=False)
    patronymic = Column(String(100))
    birthday = Column(Date)
    post_id = Column(Integer, ForeignKey('posts.id'), nullable=False)
    login = Column(String(100), unique=True, nullable=False)
    password = Column(String(255), nullable=False)
    # допущение: пароли хешировать не будем

    post = relationship("Post", back_populates="employees")
    takings = relationship("TakingBook", back_populates="employee")


class User(Base):
    __tablename__ = 'users'

    id = Column(Integer, primary_key=True, autoincrement=True)
    surname = Column(String(100), nullable=False)
    name = Column(String(100), nullable=False)
    patronymic = Column(String(100))
    birthday = Column(Date)
    registration_date = Column(Date, nullable=False)

    takings = relationship("TakingBook", back_populates="user")


class BookIncoming(Base):
    __tablename__ = 'book_incomings'

    id = Column(Integer, primary_key=True, autoincrement=True)
    book_id = Column(Integer, ForeignKey('books.id'), nullable=False)
    amount = Column(Integer, CheckConstraint('amount > 0'), nullable=False)
    incoming_date = Column(Date, nullable=False)
    # допущение: за раз не придёт больше наименования книги

    book = relationship("Book", back_populates="incoming_records")


class TakingBook(Base):
    __tablename__ = 'taking_books'

    id = Column(Integer, primary_key=True, autoincrement=True)
    book_id = Column(Integer, ForeignKey('books.id'), nullable=False)
    user_id = Column(Integer, ForeignKey('users.id'), nullable=False)
    employee_id = Column(Integer, ForeignKey('employees.id'), nullable=False)
    taking_date = Column(Date, nullable=False)
    is_returned = Column(Boolean, default=False, nullable=False)
    return_date = Column(Date)

    book = relationship("Book", back_populates="takings")
    user = relationship("User", back_populates="takings")
    employee = relationship("Employee", back_populates="takings")
