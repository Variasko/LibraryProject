namespace LibrarryDesktop.Infrastructure.API
{
    /// <summary>
    /// Содержит константы URL-путей к эндпоинтам API.
    /// </summary>
    public static class Routers
    {
        public static class Database
        {
            public const string InitDatabase = "/database/init_database";
        }

        public static class Authors
        {
            public const string GetAuthors = "/authors/";
            public const string GetAuthorById = "/authors/{0}"; // {0} - placeholder для author_id
            public const string CreateAuthor = "/authors/new_author";
            public const string UpdateAuthor = "/authors/update_author/{0}"; // {0} - placeholder для author_id
            public const string DeleteAuthor = "/authors/delete_author/{0}"; // {0} - placeholder для author_id
            public const string DeleteAuthorWithBooks = "/authors/delete_author/{0}/with_books"; // {0} - placeholder для author_id
        }

        public static class Auth
        {
            public const string Authorization = "/auth/";
        }

        public static class Books
        {
            public const string GetBooks = "/books/";
            public const string GetBookById = "/books/{0}"; // {0} - placeholder для book_id
            public const string CreateBook = "/books/new_book";
            public const string UpdateBook = "/books/update_book/{0}"; // {0} - placeholder для book_id
            public const string DeleteBook = "/books/delete_book/{0}"; // {0} - placeholder для book_id
        }

        public static class Posts
        {
            public const string GetPosts = "/posts/";
            public const string GetPostById = "/posts/{0}"; // {0} - placeholder для post_id
            public const string CreatePost = "/posts/new_post";
            public const string UpdatePost = "/posts/update_post/{0}"; // {0} - placeholder для post_id
            public const string DeletePost = "/posts/delete_post/{0}"; // {0} - placeholder для post_id
        }

        public static class Employees
        {
            public const string GetEmployees = "/employees/";
            public const string GetEmployeeById = "/employees/{0}"; // {0} - placeholder для employee_id
            public const string CreateEmployee = "/employees/new_employee";
            public const string UpdateEmployee = "/employees/update_employee/{0}"; // {0} - placeholder для employee_id
            public const string DeleteEmployee = "/employees/delete_employee/{0}"; // {0} - placeholder для employee_id
        }

        public static class Users
        {
            public const string GetUsers = "/users/";
            public const string GetUserById = "/users/{0}"; // {0} - placeholder для user_id
            public const string CreateUser = "/users/new_user";
            public const string UpdateUser = "/users/update_user/{0}"; // {0} - placeholder для user_id
            public const string DeleteUser = "/users/delete_user/{0}"; // {0} - placeholder для user_id
        }

        public static class BookIncomings
        {
            public const string GetBookIncomings = "/book_incomings/";
            public const string GetBookIncomingById = "/book_incomings/{0}"; // {0} - placeholder для incoming_id
            public const string CreateBookIncoming = "/book_incomings/new_incoming";
            public const string UpdateBookIncoming = "/book_incomings/update_incoming/{0}"; // {0} - placeholder для incoming_id
            public const string DeleteBookIncoming = "/book_incomings/delete_incoming/{0}"; // {0} - placeholder для incoming_id
        }

        public static class TakingBooks
        {
            public const string GetTakingBooks = "/taking_books/";
            public const string GetTakingBookById = "/taking_books/{0}"; // {0} - placeholder для taking_id
            public const string CreateTakingBook = "/taking_books/new_taking";
            public const string UpdateTakingBook = "/taking_books/update_taking/{0}"; // {0} - placeholder для taking_id
            public const string DeleteTakingBook = "/taking_books/delete_taking/{0}"; // {0} - placeholder для taking_id
        }
    }
}
