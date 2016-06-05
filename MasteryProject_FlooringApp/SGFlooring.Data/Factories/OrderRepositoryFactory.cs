using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;
using SGFlooring.Data.OrderRepo;

namespace SGFlooring.Data
{
    public class OrderRepositoryFactory
    {
        public static IOrderRepository GetOrderRepository()
        {
            var mode = ConfigurationManager.AppSettings["Mode"];
            switch (mode)
            {
                case "Test":
                    return new MockOrderRepository();
                default:
                    return new OrderRepository();
            }
        }
    }
}
