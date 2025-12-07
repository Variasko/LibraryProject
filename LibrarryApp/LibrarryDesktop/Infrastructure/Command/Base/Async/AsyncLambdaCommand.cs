namespace LibrarryDesktop.Infrastructure.Command.Base.Async
{
    /// <summary>
     /// Асинхронная команда, реализующая шаблон Lambda.
     /// Принимает асинхронный метод Execute.
     /// </summary>
    public class LambdaAsyncCommand : AsyncCommand
    {
        private readonly Func<object, Task> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaAsyncCommand(Func<object, Task> execute, Func<object, bool> canExecute = null)
        {
            _Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _CanExecute = canExecute;
        }

        public override bool CanExecute(object? parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override async void Execute(object? parameter)
        {
            // Вызываем асинхронный метод и "забываем" о нём (fire-and-forget).
            // Обрати внимание на 'async void' - это допустимо только для событий и команд в UI.
            await _Execute(parameter);
        }
    }
}
