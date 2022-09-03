using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media.TextFormatting;

namespace TestWPFApp
{
	/// <summary>
	/// Класс для описания модели в рамках паттерна MVVM.
	/// </summary>
	public class Function : INotifyPropertyChanged
	{
		/// <summary>
		/// Класс для описания объекта, содержащего заданные значения <b>x</b> и <b>y</b> и расчитанное по формуле значение <b>f(x, y)</b>.
		/// </summary>
		public class Calculations : INotifyPropertyChanged
		{
			private double? x, y, f;

			/// <summary>
			/// Хранит функцию, для которой осуществляются расчёты.
			/// </summary>
			public Function Function { get; set; }

			/// <summary>
			/// Значение аргумента <b>x</b>.
			/// </summary>
			public double? X
			{ 
				get { return x; }
				set
				{
					x = value;
					OnPropertyChanged("X");
					TryCalculateF();
				}
			}

			/// <summary>
			/// Значение аргумента <b>y</b>.
			/// </summary>
			public double? Y
			{
				get { return y; }
				set
				{
					y = value;
					OnPropertyChanged("Y");
					TryCalculateF();
				}
			}

			/// <summary>
			/// Значение функции <b>f(x, y)</b>.
			/// </summary>
			public double? F
			{
				get { return f; }
				set
				{
					f = value;
					OnPropertyChanged("F");
				}
			}

			public event PropertyChangedEventHandler? PropertyChanged;

			/// <summary>
			/// <para>Вызывается автоматически при изменении свойств <see cref="X"/>, <see cref="Y"/> или <see cref="F"/>.</para>
			/// <para>Метод необходим для осуществления привязки к соответствующим элементам управления в интерфейсе.</para>
			/// </summary>
			/// <param name="property"></param>
			public void OnPropertyChanged([CallerMemberName] string property = "")
			{
				if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
			}

			private void TryCalculateF()
			{
				if (X != null && Y != null)
				{
					F = Function.Formula((double)X, (double)Y, (double)Function.A, (double)Function.B, (double)Function.SelectedC);
				}
			}
		}

		private string? title;
		private string? description;
		private double? a;
		private double? b;
		private List<double>? coefficients; // c
		private double? selectedC;
		private List<Calculations>? values;

		private Func<double, double, double, double, double, double> formula;

		/// <summary>
		/// Наименование функции.
		/// </summary>
		public string? Title
		{
			get { return title; }
			set 
			{ 
				title = value;
				OnPropertyChanged("Title");
			}
		}

		/// <summary>
		/// Описание функции, любые краткие сведения.
		/// </summary>
		public string? Description
		{
			get { return description; }
			set
			{
				description = value;
				OnPropertyChanged("Description");
			}
		}

		/// <summary>
		/// Коэффициент <b>a</b>.
		/// </summary>
		public double? A
		{
			get { return a; }
			set
			{
				a = value;
				OnPropertyChanged("A");
				Values = new();
			}
		}

		/// <summary>
		/// Коэффициент <b>b</b>.
		/// </summary>
		public double? B
		{
			get { return b; }
			set
			{
				b = value;
				OnPropertyChanged("B");
				Values = new();
			}
		}

		/// <summary>
		/// Список коэффициентов <b>c</b>, доступных для данной функции.
		/// </summary>
		public List<double>? Coefficients
		{
			get { return coefficients; }
			set
			{
				coefficients = value;
				OnPropertyChanged("Coefficients");
			}
		}

		/// <summary>
		/// Текущий коэффициент <b>c</b>.
		/// </summary>
		public double? SelectedC
		{
			get { return selectedC; }
			set
			{
				selectedC = value;
				OnPropertyChanged("SelectedC");
				Values = new();
			}
		}

		/// <summary>
		/// Список объектов типа <see cref="Calculations"/>, содержащих аргументы <b>x</b> и <b>y</b> и
		/// посчитанное значение функции <b>f(x, y)</b> при заданных аргументах и постоянных коэффициентах <b>a</b>, <b>b</b> и <b>c</b>.
		/// </summary>
		public List<Calculations>? Values
		{
			get { return values; }
			set
			{
				values = value;
				OnPropertyChanged("Values");
			}
		}

		/// <summary>
		/// Хранит <see langword="delegate"/>-формулу для расчёта значения функции.
		/// </summary>
		public Func<double, double, double, double, double, double> Formula
		{
			get { return formula; }
			set { formula = value; }
		}

		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// <para>Вызывается автоматически при изменении свойств (названия, описания, коэффициентов) функции.</para>
		/// <para>Метод необходим для осуществления привязки к соответствующим элементам управления в интерфейсе.</para>
		/// </summary>
		/// <param name="property"></param>
		public void OnPropertyChanged([CallerMemberName]string property = "")
		{
			if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
	}
}
