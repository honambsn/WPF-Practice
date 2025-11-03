using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Chess.Login_SignUp.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        //fields
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteAction;

        // constructors
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }
        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }

        // Events
        //public event EventHandler? CanExecuteChanged;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        // methods
        public bool CanExecute(object? parameter)
        {
            //throw new NotImplementedException();
            return _canExecuteAction == null ? true : _canExecuteAction(parameter);
        }

        public void Execute(object? parameter)
        {
            //throw new NotImplementedException();
            _executeAction(parameter);
        }

        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
    }
}
