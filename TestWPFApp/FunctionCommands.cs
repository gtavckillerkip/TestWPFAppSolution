using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.TextFormatting;

namespace TestWPFApp
{
	/// <summary>
	/// Класс для создания собственных, нестандартных команд.
	/// </summary>
	public class FunctionCommand : ICommand
	{
		private Action<object?> execute;
		private Func<object?, bool>? canExecute;

		public FunctionCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
		{
			this.execute = execute;
			this.canExecute = canExecute;
		}

		public event EventHandler? CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object? parameter)
		{
			return this.canExecute == null || this.canExecute(parameter);
		}

		public void Execute(object? parameter)
		{
			this.execute(parameter);
		}
	}
}
