#pragma warning disable CS8629 // Тип значения, допускающего NULL, может быть NULL.
using TestWPFApp;

namespace FunctionsUnitTesting
{
	[TestClass]
	public class FunctionsCalculationTest
	{
		[TestMethod]
		public void TestFunction1()
		{
			// Arrange
			double x = 3, y = 4, a = 2, b = 7, c = -14;
			var function = new Function
			{
				A = a,
				B = b,
				SelectedC = c,
				Values = new(),
				Formula = delegate (double x, double y, double a, double b, double c)
				{
					return a * Math.Pow(x, 1) + b * Math.Pow(y, 0) + c;
				}
			};
			double expected = -1;

			// Act
			function.Values.Add(new Function.Calculations{ Function = function });
			function.Values[0].X = x;
			function.Values[0].Y = y;

			// Asset
			double actual = (double)function.Values[0].F;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TestFunction2()
		{
			// Arrange
			double x = 3, y = 4, a = 2, b = 7, c = -14;
			var function = new Function
			{
				A = a,
				B = b,
				SelectedC = c,
				Values = new(),
				Formula = delegate (double x, double y, double a, double b, double c)
				{
					return a * Math.Pow(x, 2) + b * Math.Pow(y, 1) + c;
				}
			};
			double expected = 32;

			// Act
			function.Values.Add(new Function.Calculations { Function = function });
			function.Values[0].X = x;
			function.Values[0].Y = y;

			// Asset
			double actual = (double)function.Values[0].F;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TestFunction3()
		{
			// Arrange
			double x = 3, y = 4, a = 2, b = 7, c = -14;
			var function = new Function
			{
				A = a,
				B = b,
				SelectedC = c,
				Values = new(),
				Formula = delegate (double x, double y, double a, double b, double c)
				{
					return a * Math.Pow(x, 3) + b * Math.Pow(y, 2) + c;
				}
			};
			double expected = 152;

			// Act
			function.Values.Add(new Function.Calculations { Function = function });
			function.Values[0].X = x;
			function.Values[0].Y = y;

			// Asset
			double actual = (double)function.Values[0].F;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TestFunction4()
		{
			// Arrange
			double x = 3, y = 4, a = 2, b = 7, c = -14;
			var function = new Function
			{
				A = a,
				B = b,
				SelectedC = c,
				Values = new(),
				Formula = delegate (double x, double y, double a, double b, double c)
				{
					return a * Math.Pow(x, 4) + b * Math.Pow(y, 3) + c;
				}
			};
			double expected = 596;

			// Act
			function.Values.Add(new Function.Calculations { Function = function });
			function.Values[0].X = x;
			function.Values[0].Y = y;

			// Asset
			double actual = (double)function.Values[0].F;
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void TestFunction5()
		{
			// Arrange
			double x = 3, y = 4, a = 2, b = 7, c = -14;
			var function = new Function
			{
				A = a,
				B = b,
				SelectedC = c,
				Values = new(),
				Formula = delegate (double x, double y, double a, double b, double c)
				{
					return a * Math.Pow(x, 5) + b * Math.Pow(y, 4) + c;
				}
			};
			double expected = 2264;

			// Act
			function.Values.Add(new Function.Calculations { Function = function });
			function.Values[0].X = x;
			function.Values[0].Y = y;

			// Asset
			double actual = (double)function.Values[0].F;
			Assert.AreEqual(expected, actual);
		}
	}
}
