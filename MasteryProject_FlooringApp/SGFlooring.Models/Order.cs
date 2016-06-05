using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class Order
    {
        public Order(int orderNum, DateTime orderDate, string customerName, string state, decimal taxRate, string productType, decimal area, decimal costPerSqft, decimal laborPerSqft, decimal totalMaterialCost, decimal totalLaborCost, decimal totalTax, decimal totalCost, string status)
        {
            this.OrderNumber = orderNum;
            this.OrderDate = orderDate;
            this.CustomerName = customerName;
            this.State = state;
            this.TaxRate = taxRate;
            this.ProductType = productType;
            this.Area = area;
            this.CostPerSqft = costPerSqft;
            this.LaborCostPerSqft = laborPerSqft;
            this.TotalMaterialCost = totalMaterialCost;
            this.TotalLaborCost = totalLaborCost;
            this.TotalTax = totalTax;
            this.TotalCost = totalCost;
            this.Status = (OrderStatus) Enum.Parse(typeof(OrderStatus), status);
        }

        public Order()
        {

        }

        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSqft { get; set; }
        public decimal LaborCostPerSqft { get; set; }
        public decimal TotalMaterialCost { get; set; }
        public decimal TotalLaborCost { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalCost { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    $"{OrderNumber},{OrderDate},\"{CustomerName}\",{State},{TaxRate},{ProductType},{Area},{CostPerSqft},{LaborCostPerSqft},{TotalMaterialCost},{TotalLaborCost},{TotalTax},{TotalCost},{Enum.GetName(typeof(OrderStatus),Status)}");
        }
    }
}
