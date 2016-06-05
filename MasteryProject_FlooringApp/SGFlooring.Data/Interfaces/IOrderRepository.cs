using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders(DateTime orderDate);
        Order LoadOrder(int orderNumber, DateTime orderDate);
        void UpdateOrder(Response<Order> order,DateTime date);
        void DeleteAnOrder(Order order,DateTime date);
        Order AddOrder(Response<Order> newOrder, DateTime date);
        int GetNextOrderNumberForDate(DateTime orderDate);
    }
}
