using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;
using SGFlooring.Data.ProductRepo;
using SGFlooring.Data.StateRepo;
using SGFlooring.Models;

namespace SGFlooring.Data.OrderRepo
{
    public class MockOrderRepository : IOrderRepository
    {
        private static List<Order> orders = new List<Order>()
                {
                    new Order() {OrderNumber = 1, CustomerName = "Alfreds Futterkiste", State = "MI", TaxRate = 6.00m, Area = 90.75m, ProductType = "Hardwood", CostPerSqft = 9.00m, LaborCostPerSqft = 6.5m, TotalMaterialCost = 90.75m*9.00m, TotalLaborCost = 90.75m*6.5m, TotalTax = ((90.75m*9.00m)+(90.75m*6.5m))*0.06m, TotalCost = ((90.75m*9.00m)+(90.75m*6.5m))*0.06m + 90.75m*9.00m + 90.75m*6.5m, Status = OrderStatus.Active, OrderDate = new DateTime(2016,5,17)},
                    new Order() {OrderNumber = 2, CustomerName = "Antonio Moreno Taquería", State = "AZ", TaxRate = 5.6m, Area = 110m, ProductType = "Cork", CostPerSqft = 10.25m, LaborCostPerSqft = 7.75m, TotalMaterialCost = 10.25m*110m, TotalLaborCost = 7.75m*110m, TotalTax = (10.25m*110m + 7.75m*110m)*0.056m, TotalCost = (10.25m*110m + 7.75m*110m)*0.056m + 10.25m*110m + 7.75m*110m, Status = OrderStatus.Active, OrderDate = new DateTime(2016,5,17)}
                };

        public MockOrderRepository()
        {
            var stateRepo = new MockStateRepository();
            var prodRepo = new MockProductRepository();
        }

        public List<Order> GetAllOrders(DateTime orderDate)
        {
            return orders.Where(o => o.OrderDate == orderDate).ToList();
        }

        public int GetNextOrderNumberForDate(DateTime orderDate)
        {
            return orders.Where(o => o.OrderDate == orderDate).Max(o => o.OrderNumber) + 1;
        }

        public Order LoadOrder(int orderNumber, DateTime orderDate)
        {
            return orders.FirstOrDefault(o => o.OrderNumber == orderNumber && o.OrderDate == orderDate);
        }

        public Order AddOrder(Response<Order> newOrder, DateTime date)
        {            
            orders.Add(newOrder.Data);
            return newOrder.Data;
        }

        public void UpdateOrder(Response<Order> order,DateTime date)
        {
            var orderToUpdate = orders.First(o => o.OrderNumber == order.Data.OrderNumber);
            orderToUpdate.CustomerName = order.Data.CustomerName;
            orderToUpdate.State = order.Data.State;
            orderToUpdate.TaxRate = order.Data.TaxRate;
            orderToUpdate.ProductType = order.Data.ProductType;
            orderToUpdate.Area = order.Data.Area;
            orderToUpdate.CostPerSqft = order.Data.CostPerSqft;
            orderToUpdate.LaborCostPerSqft = order.Data.LaborCostPerSqft;
            orderToUpdate.TotalMaterialCost = orderToUpdate.TotalMaterialCost;
            orderToUpdate.TotalLaborCost = orderToUpdate.TotalLaborCost;
            orderToUpdate.TotalTax = order.Data.TotalTax;
            orderToUpdate.TotalCost = order.Data.TotalCost;
            orderToUpdate.OrderDate = order.Data.OrderDate;
            orderToUpdate.Status = OrderStatus.Modified;
        }
    

        public List<Order> GenerateNewList(Order newOrder, DateTime date)
        {
            throw new NotImplementedException();
        }

        

        public void DeleteAnOrder(Order order, DateTime date)
        {
            var orderToDelete = orders.First(o => o.OrderNumber == order.OrderNumber && o.OrderDate == date);
            orderToDelete.Status = OrderStatus.Deleted;
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }

    }
}
