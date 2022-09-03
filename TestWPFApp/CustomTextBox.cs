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
	/// Класс-наследник класса <see cref="TextBox"/>, позволяющий создавать текстовые поля для ввода чисел с точкой в качестве разделителя.
	/// </summary>
	public class CustomTextBox : TextBox
	{
		protected override void OnPreviewTextInput(TextCompositionEventArgs e)
		{
			base.OnPreviewTextInput(e);

			int value;
			if (!int.TryParse(e.Text, out value) && e.Text != "." && e.Text != "-")
			{
				e.Handled = true;
			}

			if (e.Text == "." && Text.Contains('.'))
			{
				e.Handled = true;
			}

			if (e.Text == "-" && Text.Length > 0)
			{
				if (CaretIndex != 0)
				{
					e.Handled = true;
				}
				else if (!Text.Contains('-'))
				{
					Text = "-" + Text;
					CaretIndex = 1;
					e.Handled = true;
				}
				else
				{
					e.Handled = true;
				}
			}

			// последовательность кода ниже важна

			if (int.TryParse(e.Text, out value))
			{
				int caretIndex = CaretIndex;
				Text = Text.Insert(CaretIndex, e.Text);
				CaretIndex = caretIndex + 1;
				e.Handled = true;
			}

			this.GetBindingExpression(CustomTextBox.TextProperty).UpdateSource();

			double alreadyEnteredValue;
			if (Double.TryParse(Text, out alreadyEnteredValue))
			{
				if (e.Text == "." && alreadyEnteredValue == (int)alreadyEnteredValue)
				{
					int caretIndex = CaretIndex;
					Text = alreadyEnteredValue.ToString();
					Text = Text.Insert(CaretIndex, ".");
					CaretIndex = caretIndex + 1;
					e.Handled = true;
				}
			}
		}

		protected override void OnPreviewKeyDown(KeyEventArgs e)
		{
			base.OnPreviewKeyDown(e);

			if (e.Key == Key.Space)
			{
				e.Handled = true;
			}

			if (e.Key == Key.Back && CaretIndex > 0)
			{
				int caretIndex = CaretIndex;

				Text = Text.Remove(CaretIndex - 1, 1);
				CaretIndex = caretIndex - 1;

				this.GetBindingExpression(CustomTextBox.TextProperty).UpdateSource();
				e.Handled = true;
			}
		}
	}
}
