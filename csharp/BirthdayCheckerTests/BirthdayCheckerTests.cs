using NUnit.Framework;

namespace BirthdayCheckerTests
{
	[TestFixture]
	public class BirthdayCheckerTests
	{
		private BirthdayChecker.BirthdayChecker _birthdayChecker;

		[SetUp]
		public void Setup()
		{
			_birthdayChecker = new BirthdayChecker.BirthdayChecker();
		}

		[Test]
		public void Today_is_birthday()
		{
			Assert.Fail();
		}

		[Test]
		public void Today_is_not_birthday()
		{
			Assert.Fail();
		}
	}
}