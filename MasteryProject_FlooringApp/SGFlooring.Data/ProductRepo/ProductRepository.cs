using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;
using SGFlooring.Models;

namespace SGFlooring.Data.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private const string _filePath = @"DataFiles\Products.txt";

        public List<Product> GetProductInfo()
        {
            List<Product> results = new List<Product>();

            var rows = File.ReadAllLines(_filePath);

            for (int i = 1; i < rows.Length; i++)
            {
                var columns = rows[i].Split(',');

                var product = new Product(columns[0],decimal.Parse(columns[1]),decimal.Parse(columns[2]));

                results.Add(product);
            }

            return results;
        }

        public Product GetProduct(string productType)
        {
            List<Product> products = GetProductInfo();
            return products.FirstOrDefault(p => p.ProductType.ToUpper() == productType);
        }

        public decimal GetMaterialCost(string productType)
        {
            throw new NotImplementedException();
        }

        public decimal GetLaborCost(string productType)
        {
            throw new NotImplementedException();
        }
    }
}
