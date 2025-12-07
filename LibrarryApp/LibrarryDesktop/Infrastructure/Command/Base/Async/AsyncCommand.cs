using System.Windows.Input;

namespace LibrarryDesktop.Infrastructure.Command.Base.Async
{
    public abstract class AsyncCommand : ICommand
    {
        /// <summary>
        /// Абстрактный класс для асинхронной команды.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object? parameter);
        public abstract void Execute(object? parameter);
    }
}
