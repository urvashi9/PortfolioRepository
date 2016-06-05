using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class Product
    {
        public Product(string productType, decimal costPerSqft, decimal laborPerSqft)
        {
            this.ProductType = productType;
            this.CostPerSqft = costPerSqft;
            this.LaborCostPerSqft = laborPerSqft;
        }

        public Product()
        {
        }

        public string ProductType { get; set; }
        public decimal CostPerSqft { get; set; }
        public decimal LaborCostPerSqft { get; set; }
    }
}
