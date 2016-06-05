using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;

namespace SGFlooring.UI.Utilities
{
    public class OrdersScreen
    {
        public static void PrintAllOrderDetails(List<Order> orders)
        {
            Console.WriteLine($"All the orders for the date are as follows: ");
            foreach (var order in orders)
            {
                Console.WriteLine("===================================================");
                Console.WriteLine($"Order Number: {order.OrderNumber}\t\tDate : {order.OrderDate}");
                Console.WriteLine($"Order Status: {order.Status}");
                Console.WriteLine($"Customer Name : {order.CustomerName}");
                Console.WriteLine($"State : {order.State}");
                Console.WriteLine($"Product Type : {order.ProductType}");
                Console.WriteLine($"Area : {order.Area} sqft");
                Console.WriteLine($"Total Material Cost : {order.TotalMaterialCost:C} @ {order.CostPerSqft:C} per sqft");
                Console.WriteLine($"Total Labor Cost : {order.TotalLaborCost:C} @ {order.LaborCostPerSqft:C} per sqft");
                Console.WriteLine($"Total Tax : {order.TotalTax:C} @ {order.TaxRate}% on the total cost of {order.TotalLaborCost + order.TotalMaterialCost:C} as per the {order.State} State Law");
                Console.WriteLine($"Total Amount : {order.TotalCost:C}");
            }
        }

        public static void WorkflowErrorScreen(string message)
        {
            Console.Clear();
            Console.WriteLine("An error occured. {0}", message);
            UserUtilities.PressKeyForContinue();
        }

        public static void PrintSingleOrder(Response<Order> order)
        {
            if (order.Data != null)
            {
                Console.WriteLine("Order Details are as below: ");
                Console.WriteLine("===================================================");
                Console.WriteLine($"Order Number: {order.Data.OrderNumber}\t\tDate : {order.Data.OrderDate}");
                Console.WriteLine($"Order Status: {order.Data.Status}");
                Console.WriteLine($"Customer Name : {order.Data.CustomerName}");
                Console.WriteLine($"State : {order.Data.State}");
                Console.WriteLine($"Product Type : {order.Data.ProductType}");
                Console.WriteLine($"Area : {order.Data.Area} sqft");
                Console.WriteLine(
                    $"Total Material Cost : {order.Data.TotalMaterialCost:C} @ {order.Data.CostPerSqft:C} per sqft");
                Console.WriteLine(
                    $"Total Labor Cost : {order.Data.TotalLaborCost:C} @ {order.Data.LaborCostPerSqft:C} per sqft");
                Console.WriteLine(
                    $"Total Tax : {order.Data.TotalTax:C} @ {order.Data.TaxRate:C} on the total cost of {order.Data.TotalLaborCost + order.Data.TotalMaterialCost:C} as per the {order.Data.State} State Law");
                Console.WriteLine($"Total Amount : {order.Data.TotalCost:C}");
            }
            else
            {
                Console.WriteLine($"{order.Message}");
            }
            
        }

        public static void PrintAllStates(List<State> states)
        {
            Console.WriteLine("List of States we service in: ");
            Console.WriteLine("=================================");
            foreach (var state in states)
            {
                Console.Write($"{state.StateAbbr} : {state.StateName}\t\t");
            }
        }

        public static void PrintAllProducts(List<Product> products)
        {
            Console.WriteLine("\n\nList of Products you can choose from: ");
            Console.WriteLine("=================================");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductType} : {product.CostPerSqft:C}/sqft");
            }
        }        
    }
}
