using NUnit.Framework;
using System;
using System.Collections.Generic;
using ExpectedObjects;

namespace UnitTest.Assertion
{
	[TestFixture]
	public class AssertionTests
	{
		private CustomerRepo _customerRepo;

		[SetUp] // 每跑一次測試 都會重新 new 過
		public void Setup()
		{
			_customerRepo = new CustomerRepo();
		}

		[Test]
		public void CompareCustomer()
		{
			// Arrange 準備測試資料 幫 Repo 做準備 準備一個假的 repo 然後要做假資料

			// Act 實際去拿資料
            var actual = _customerRepo.Get();
			// Assert 把拿到的東西做檢查
            var expect = new Customer()
            {
                Id = 2,
                Age = 18,
                Birthday = new DateTime(1990, 1, 26)
            };
			// 物件跟物件直接比較是不行的 要實作IEquatable介面
			Assert.AreEqual(expect, actual);
			//Assert.Fail();
			//how to assert customer?
		}

		[Test]
		public void CompareCustomerList()
		{
			var actual = _customerRepo.GetAll();

            var expect = new List<Customer>()
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
                }
			};

            Assert.AreEqual(expect, actual);
            //CollectionAssert.AreEqual(expect, actual); 比較嚴謹
            //Assert.Fail();
			//how to assert customers?
		}

		[Test]
		public void CompareComposedCustomer()
		{
			var actual = _customerRepo.GetComposedCustomer();
			var expect = new Customer
            {
                Age = 30,
                Id = 11,
                Birthday = new DateTime(1999, 9, 9),
                Order = new Order { Id = 19, Price = 91 },
            };
			// 比較物件 有error出現的時候 可以比較容易debug
			expect.ToExpectedObject().ShouldEqual(actual);
            //Assert.AreEqual(expect, actual);
			//Assert.Fail();
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
            
			Assert.AreEqual(expected.Birthday, actual.Birthday);
            Assert.AreEqual(expected.Order.Price, actual.Order.Price);
			//Assert.Fail();

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

	public class Order : IEquatable<Order>
	{
		public int Id { get; set; }
		public int Price { get; set; }

        public bool Equals(Order other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Price == other.Price; 
		}

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Order) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ Price;
            }
        }
    }

	public class Customer: IEquatable<Customer>
	{
		public int Id { get; set; }
		public int Age { get; set; }
		public DateTime Birthday { get; set; }
		public Order Order { get; set; }

        public bool Equals(Customer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Age == other.Age && Birthday.Equals(other.Birthday) && Equals(Order, other.Order);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Age;
                hashCode = (hashCode * 397) ^ Birthday.GetHashCode();
                hashCode = (hashCode * 397) ^ (Order != null ? Order.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}