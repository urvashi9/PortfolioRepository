using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;
using SGFlooring.Models;

namespace SGFlooring.Data.ProductRepo
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> products  = new List<Product>() {       
                    new Product() { ProductType = "Hardwood", CostPerSqft = 9.00m, LaborCostPerSqft = 6.5m},
                    new Product() { ProductType = "Laminate", CostPerSqft = 7.65m, LaborCostPerSqft = 6.65m},
                    new Product() { ProductType = "Vinyl Sheet", CostPerSqft = 4.5m, LaborCostPerSqft = 10.25m},
                    new Product() { ProductType = "Vinyl Tyle", CostPerSqft = 7.5m, LaborCostPerSqft = 10.00m},
                    new Product() { ProductType = "Luxury Vinyl", CostPerSqft = 12.00m, LaborCostPerSqft = 12.00m},
                    new Product() { ProductType = "Cork", CostPerSqft = 10.25m, LaborCostPerSqft = 7.75m},
                    new Product() { ProductType = "Ceramic Tile", CostPerSqft = 14.25m, LaborCostPerSqft = 15.75m},
                    new Product() { ProductType  = "Carpet", CostPerSqft = 12.00m, LaborCostPerSqft = 10.00m},
                    new Product() { ProductType = "Stone", CostPerSqft = 25.50m, LaborCostPerSqft = 10.00m}
                };
            
        public List<Product> GetProductInfo()
        {
            return products;
        }

        public Product GetProduct(string productType)
        {
            return products.FirstOrDefault(p => p.ProductType.ToUpper() == productType);
        }


        //public decimal GetMaterialCost(string productType)
        //{
        //    decimal materialCost = 0;
        //    foreach (var product in products)
        //    {
        //        if (product.ProductType == productType)
        //            materialCost = product.CostPerSqft;
        //    }
        //    return materialCost;
        //}

        //public decimal GetLaborCost(string productType)
        //{
        //    decimal laborCost = 0;
        //    foreach (var product in products)
        //    {
        //        if (product.ProductType == productType)
        //            laborCost = product.LaborCostPerSqft;
        //    }
        //    return laborCost;
        //}
    }
}
