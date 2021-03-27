using DependencyIsolation;
using NUnit.Framework;

namespace DependencyIsolationTests
{
	public class OrderServiceTests
	{
		[Test]
		public void Test_SyncBookOrders_3_Orders_Only_2_book_order()
		{
			// hard to isolate dependency to unit test

			var target = new OrderService();
			//target.SyncBookOrders();
			Assert.Fail();
		}
	}
}