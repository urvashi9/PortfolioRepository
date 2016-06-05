using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductInfo();
        Product GetProduct(string productType);
        //decimal GetMaterialCost(string productType);
        //decimal GetLaborCost(string productType);
    }
}
