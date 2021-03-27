using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest.Assertion
{
	[TestFixture]
	public class AssertionTests
	{
		private CustomerRepo _customerRepo;

		[SetUp]
		public void Setup()
		{
			_customerRepo = new CustomerRepo();
		}

		[Test]
		public void CompareCustomer()
		{
			var actual = _customerRepo.Get();

			Assert.Fail();
			//how to assert customer?
		}

		[Test]
		public void CompareCustomerList()
		{
			var actual = _customerRepo.GetAll();

			Assert.Fail();
			//how to assert customers?
		}

		[Test]
		public void CompareComposedCustomer()
		{
			var actual = _customerRepo.GetComposedCustomer();

			Assert.Fail();
			//how to assert composed customer?
		}

		[Test]
		public void PartialCompare_Customer_Birthday_And_Order_Price()
		{
			var actual = _customerRepo.GetComposedCustomer();

			var expected = new Customer
			{
				Birthday = new DateTime(1999, 9, 9),
				Order = new Order { Price = 91 },
			};

			Assert.Fail();

			//how to assert actual is equal to expected?
		}
	}

	public class CustomerRepo
	{
		public Customer Get()
		{
			return new Customer
			{
				Id = 2,
				Age = 18,
				Birthday = new DateTime(1990, 1, 26)
			};
		}

		public List<Customer> GetAll()
		{
			return new List<Customer>
			{
				new Customer
				{
					Id = 3,
					Age = 20,
					Birthday = new DateTime(1993, 1, 2)
				},

				new Customer
				{
					Id = 4,
					Age = 21,
					Birthday = new DateTime(1993, 1, 3)
				},
			};
		}

		public Customer GetComposedCustomer()
		{
			return new Customer
			{
				Age = 30,
				Id = 11,
				Birthday = new DateTime(1999, 9, 9),
				Order = new Order { Id = 19, Price = 91 },
			};
		}
	}

	public class Order
	{
		public int Id { get; set; }
		public int Price { get; set; }
	}

	public class Customer
	{
		public int Id { get; set; }
		public int Age { get; set; }
		public DateTime Birthday { get; set; }
		public Order Order { get; set; }
	}
}