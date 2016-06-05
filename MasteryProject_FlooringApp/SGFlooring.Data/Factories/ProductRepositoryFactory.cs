using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;
using SGFlooring.Data.ProductRepo;
using SGFlooring.Data.StateRepo;

namespace SGFlooring.Data.Factories
{
    public class ProductRepositoryFactory
    {
        public static IProductRepository GetProductRepository()
        {
            var mode = ConfigurationManager.AppSettings["Mode"];
            switch (mode)
            {
                case "Test":
                    return new MockProductRepository();
                default:
                    return new ProductRepository();
            }
        }
    }
}
