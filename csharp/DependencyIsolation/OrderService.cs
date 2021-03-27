using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DependencyIsolation
{
    public interface IOrderReader
    {
        List<Order> GetOrders();
    }

    public class OrderReader : IOrderReader
    {
        private string _filePath = @"C:\temp\testOrders.csv";

        public List<Order> GetOrders()
        {
            // parse csv file to get orders
            var result = new List<Order>();

            // directly depend on File I/O
            using (StreamReader sr = new StreamReader(this._filePath, Encoding.UTF8))
            {
                int rowCount = 0;

                while (sr.Peek() > -1)
                {
                    rowCount++;

                    var content = sr.ReadLine();

                    // Skip CSV header line
                    if (rowCount > 1)
                    {
                        string[] line = content.Trim().Split(',');

                        result.Add(this.Mapping(line));
                    }
                }
            }

            return result;
        }

        private Order Mapping(string[] line)
        {
            var result = new Order
            {
                ProductName = line[0],
                Type = line[1],
                Price = Convert.ToInt32(line[2]),
                CustomerName = line[3]
            };

            return result;
        }
    }

    public class OrderService
	{
        private readonly IOrderReader _orderReader;
        private readonly IBookDao _bookDao;

        public OrderService(IOrderReader orderReader, IBookDao bookDao)
        {
            _orderReader = orderReader;
            _bookDao = bookDao;
        }

        public void SyncBookOrders()
		{
			var orders = _orderReader.GetOrders(); // 抓 order 

			// only get orders of book
			var ordersOfBook = orders.Where(x => x.Type == "Book"); // 過濾到只能是書

            foreach (var order in ordersOfBook)
			{
				_bookDao.Insert(order);
			}
		}
    }

	public class Order
	{
		public string Type { get; set; }

		public int Price { get; set; }

		public string ProductName { get; set; }

		public string CustomerName { get; set; }
	}

    public interface IBookDao
    {
        void Insert(Order order);
    }

    public class BookDao : IBookDao
    {
		public void Insert(Order order)
		{
			throw new NotImplementedException();
		}
	}
}