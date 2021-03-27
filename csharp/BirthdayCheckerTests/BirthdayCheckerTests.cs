using NUnit.Framework;
using System;

namespace BirthdayCheckerTests
{
	[TestFixture]
	public class BirthdayCheckerTests
	{
        private MockBirthdayChecker _birthdayChecker;//BirthdayChecker.BirthdayChecker _birthdayChecker;

        [SetUp]
		public void Setup()
        {
            _birthdayChecker = new MockBirthdayChecker(); //BirthdayChecker.BirthdayChecker();

        }

		[Test]
		public void Today_is_birthday()
        {
            _birthdayChecker.SetToday(new DateTime(1999, 10, 10));
            Assert.IsTrue(_birthdayChecker.IsBirthday());
			//Assert.Fail();
		}

		[Test]
		public void Today_is_not_birthday()
		{
            // Arrange
            _birthdayChecker.SetToday(new DateTime(1999, 10, 13));
            // Act
            var actual = _birthdayChecker.IsBirthday();
            // Assert
            Assert.IsFalse(actual);
            //Assert.Fail();
        }
	}

    public class MockBirthdayChecker : BirthdayChecker.BirthdayChecker
    {
        private DateTime _today;

        protected override DateTime Today()
        {
            return _today;
        }

        public void SetToday(DateTime today)
        {
            _today = today;
        }
    }
}