using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestWPFApp
{
	/// <summary>
	/// Класс для описания модели представления в рамках паттерна MVVM.
	/// </summary>
	public class FunctionViewModel : INotifyPropertyChanged
	{
		private Function? selectedFunction;

		/// <summary>
		/// Список математических функций, с которыми программа производит расчёты.
		/// </summary>
		public ObservableCollection<Function> Functions { get; set; }

		private FunctionCommand? addValuesRowCommand;
		/// <summary>
		/// Команда для добавления очередного набора значений аргументов и значения функции.
		/// </summary>
		public FunctionCommand? AddValuesRowCommand
		{
			get
			{
				return addValuesRowCommand ?? (addValuesRowCommand = new FunctionCommand(obj =>
				{
					if (selectedFunction?.A != null && selectedFunction?.B != null && selectedFunction?.SelectedC != null)
					{
						selectedFunction?.Values?.Add(new Function.Calculations
						{
							Function = selectedFunction,
						});
					}
					((MainWindow)App.Current.MainWindow).valuesList.Items.Refresh();
				}));
			}
		}

		/// <summary>
		/// <para>Текущая функция.</para>
		/// <para>Изменения коэффициентов или аргументов сохраняются в свойствах только выбранной функции.</para>
		/// </summary>
		public Function? SelectedFunction
		{
			get { return selectedFunction; }
			set
			{
				selectedFunction = value;
				OnPropertyChanged("SelectedFunction");
			}
		}

		public FunctionViewModel()
		{
			Functions = new ObservableCollection<Function>
			{
				new Function
				{
					Title = "Линейная",
					Description = "f(x, y) = ax^1 + by^0 + c",
					Coefficients = new List<double> { 1, 2, 3, 4, 5 },
					Values = new List<Function.Calculations>(),
					Formula = delegate(double x, double y, double a, double b, double c)
					{
						return a * Math.Pow(x, 1) + b * Math.Pow(y, 0) + c;
					}
				},
				new Function
				{
					Title = "Квадратичная",
					Description = "f(x, y) = ax^2 + by^1 + c",
					Coefficients = new List<double> { 10, 20, 30, 40, 50 },
					Values = new List<Function.Calculations>(),
					Formula = delegate(double x, double y, double a, double b, double c)
					{
						return a * Math.Pow(x, 2) + b * Math.Pow(y, 1) + c;
					},
				},
				new Function
				{
					Title = "Кубическая",
					Description = "f(x, y) = ax^3 + by^2 + c",
					Coefficients = new List<double> { 100, 200, 300, 400, 500 },
					Values = new List<Function.Calculations>(),
					Formula = delegate(double x, double y, double a, double b, double c)
					{
						return a * Math.Pow(x, 3) + b * Math.Pow(y, 2) + c;
					},
				},
				new Function
				{
					Title = "4-ой степени",
					Description = "f(x, y) = ax^4 + by^3 + c",
					Coefficients = new List<double> { 1000, 2000, 3000, 4000, 5000 },
					Values = new List<Function.Calculations>(),
					Formula = delegate(double x, double y, double a, double b, double c)
					{
						return a * Math.Pow(x, 4) + b * Math.Pow(y, 3) + c;
					},
				},
				new Function
				{
					Title = "5-ой степени",
					Description = "f(x, y) = ax^5 + by^4 + c",
					Coefficients = new List<double> { 10000, 20000, 30000, 40000, 50000 },
					Values = new List<Function.Calculations>(),
					Formula = delegate(double x, double y, double a, double b, double c)
					{
						return a * Math.Pow(x, 5) + b * Math.Pow(y, 4) + c;
					},
				},
			};
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// <para>Вызывается автоматически при изменении свойств (<see langword="Property"/>).</para>
		/// <para>Метод необходим для осуществления привязки к соответствующим элементам управления в интерфейсе.</para>
		/// </summary>
		/// <param name="property"></param>
		public void OnPropertyChanged([CallerMemberName]string property = "")
		{
			if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
	}
}
