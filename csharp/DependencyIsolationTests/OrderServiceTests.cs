using System.Collections.Generic;
using DependencyIsolation;
using NSubstitute;
using NUnit.Framework;

namespace DependencyIsolationTests
{
    public class OrderServiceTests
    {

        private OrderService target;
        private IOrderReader orderReader;
        private IBookDao bookDao;

        [SetUp]
        public void SetUp()
        {
            orderReader = Substitute.For<IOrderReader>();
            bookDao = Substitute.For<IBookDao>();
            target = new OrderService(orderReader, bookDao);
        }


        [Test]
        public void Test_SyncBookOrders_3_Orders_Only_2_book_order()
        {
            // Arrange
            orderReader.GetOrders().Returns(new List<Order>()
            {
                new Order() { Type = "Book" },
                new Order() { Type = "Book" },
                new Order() { Type = "Chair" }
            });

            // Act 
            target.SyncBookOrders();

            // Asset
            bookDao.Received(2).Insert(Arg.Any<Order>()); //應該要被 call insert 2次 型態要是 order
            bookDao.Received(2).Insert(Arg.Is<Order>(o => o.Type == "Book"));
            bookDao.Received(0).Insert(Arg.Is<Order>(o => o.Type != "Book"));
            //Assert.Fail();
        }

        [Test]
        public void Test_SyncBookOrders_3_Orders_Only_0_book_order()
        {
            orderReader.GetOrders().Returns(new List<Order>()
                {
                    new Order() { Type = "chair" },
                    new Order() { Type = "hat" },
                    new Order() { Type = "apple" }

                }
            );

            target.SyncBookOrders();

            bookDao.Received(0).Insert(Arg.Is<Order>(o=> o.Type=="book"));
            bookDao.Received(0).Insert(Arg.Is<Order>(o => o.Type != "book"));
            //bookDao.Received(0).Insert(Arg.Any<Order>());
        }

        [Test]
        public void Test_SyncBookOrders_0_Orders()
        {
            // Arrange
            orderReader.GetOrders().Returns(new List<Order>() { });

            // Act 
            target.SyncBookOrders();

            // Asset
            bookDao.Received(0).Insert(Arg.Any<Order>());

            //Assert.Fail();
        }

    }

}