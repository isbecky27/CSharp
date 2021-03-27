using NUnit.Framework;
using System;

namespace UnitTest.Assertion
{
	[TestFixture]
	public class AssertExceptionSample
	{
		[Test]
		public void Divide_positive()
		{
			var calculator = new Calculator();
			var actual = calculator.Divide(5, 2); // success

			// 執行這個東西的時候不應該出錯
            Assert.DoesNotThrow(() => { calculator.Divide(5, 2); });
			//Assert.Fail();
		}

		[Test]
		public void Divide_Zero()
		{
			var calculator = new Calculator();
			//var actual = calculator.Divide(5, 0); // fail

            Assert.Throws<YouShallNotPassException>(() => { calculator.Divide(5, 0);});
			//Assert.Fail();

			//how to assert expected exception?
			//never use try/catch in unit test
		}
	}

	public class Calculator
	{
		public decimal Divide(decimal first, decimal second)
		{
			if (second == 0)
			{
				throw new YouShallNotPassException();
			}
			return first / second;
		}
	}

	public class YouShallNotPassException : Exception
	{
	}
}