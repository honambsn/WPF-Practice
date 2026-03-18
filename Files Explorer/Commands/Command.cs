using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Files_Explorer.Commands
{
	internal class Command : ICommand
	{
		private readonly Action _action;

		public Command(Action action)
		{
			_action = action;
		}

		#region Implementation of ICommand

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_action();
		}

		public event EventHandler CanExecuteChanged
		{
			add { }
			remove { }
		}

		#endregion
	}
}
