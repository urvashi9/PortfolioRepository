using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGFlooring.Data.OrderRepo;
using SGFlooring.Models;

namespace SGFlooring.Tests
{
    [TestFixture]
    public class SGFlooringTests
    {
        private OrderRepository repo = new OrderRepository();

        [TestCase("5/18/2016",1)]
        public void CanLoadAllOrders(string date, int expected)
        {
            DateTime Date = DateTime.Parse(date);
            var orders = repo.GetAllOrders(Date);

            Assert.AreEqual(expected, orders.Count);
        }

        [TestCase(1, "5/18/2016", "URVASHI,ATODARIA")]
        public void CanLoadSingleOrder(int ordNum, string ordDate, string expected)
        {
            DateTime date = DateTime.Parse(ordDate);           
            var order = repo.LoadOrder(ordNum, date);

            Assert.AreEqual(expected,order.CustomerName);
        }

        [TestCase("ABCD", "MI", "WOOD", "5/18/2016", 500)]
        public void CanAddAccount(string name, string state, string productType, string date, int area)
        {
            DateTime Date = DateTime.Parse(date);
            var repo = new OrderRepository();
            var result = new Response<Order>();
            result.Data = new Order();
            result.Data.CustomerName = name;
            result.Data.ProductType = productType;
            result.Data.State = state;
            result.Data.Area = area;
            result.Data.OrderDate = Date;
            var order = repo.AddOrder(result, Date);
            
            Assert.AreEqual("ABCD",order.CustomerName);
            Assert.AreEqual(2,order.OrderNumber);
        }

        [TestCase(1,"5/18/2016","WOOD")]
        public void CanEditOrder(int ordNum, string date, string expected )
        {
            DateTime Date = DateTime.Parse(date);
            var orderToUpdate = new Response<Order>();
            orderToUpdate.Data = new Order();
            orderToUpdate.Data = repo.LoadOrder(ordNum, Date);
            orderToUpdate.Data.ProductType = "WOOD";
            
            repo.UpdateOrder(orderToUpdate,Date);

            var results = repo.GetAllOrders(Date);
            var result = results.First(o => o.OrderNumber == ordNum);
            Assert.AreEqual("WOOD",result.ProductType);
        }

        [TestCase(1,"5/18/2016","Deleted")]
        public void CanDeleteOrder(int ordNum, string ordDate,string expected)
        {
            DateTime date = DateTime.Parse(ordDate);
            var orderToDelete = new Order();
            orderToDelete = repo.LoadOrder(ordNum,date);

            repo.DeleteOrder(orderToDelete);
            var comparisonOrder = repo.LoadOrder(ordNum,date);

            Assert.AreEqual(Enum.GetName(typeof(OrderStatus),1),comparisonOrder.Status.ToString());
        }
    }
}
