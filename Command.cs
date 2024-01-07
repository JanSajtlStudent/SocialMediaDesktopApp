using System;
using System.Windows.Input;

namespace Social_Media
{
    public class Command : ICommand
    {
        private Action<object> action;
        private Predicate<object> canExecute {  get; set; }

        public Command(Action<object> action, Predicate<object> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            try
            {
                action?.Invoke(parameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}