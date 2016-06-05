using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SGFlooring.Data.Interfaces;
using SGFlooring.Models;
using Microsoft.VisualBasic.FileIO;

namespace SGFlooring.Data.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private string _folderPath = @"DataFiles\Orders\";


        // Reading all lines from the text file and putting them in a list
        public List<Order> GetAllOrders(DateTime orderDate)
        {
            string fileName = $"Orders_{orderDate.Month}{orderDate.Day}{orderDate.Year}.txt";
            var filePath = $@"{_folderPath}{fileName}";

            List<Order> results = new List<Order>();
            if (!File.Exists(filePath))
            {
                return results;
            }
            else
            {
                var lines = File.ReadAllLines(filePath);
                for (int i = 1; i < lines.Length; i++)
                {
                    TextFieldParser parser = new TextFieldParser(new StringReader(lines[i]));
                    parser.HasFieldsEnclosedInQuotes = true;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        var columns = parser.ReadFields();
                        
                        if(columns.Length != 0)
                        {
                          
                            
                                var order = new Order(int.Parse(columns[0]), DateTime.Parse(columns[1]), columns[2],
                                    columns[3], decimal.Parse(columns[4]), columns[5], decimal.Parse(columns[6]),
                                    decimal.Parse(columns[7]), decimal.Parse(columns[8]), decimal.Parse(columns[9]),
                                    decimal.Parse(columns[10]), decimal.Parse(columns[11]), decimal.Parse(columns[12]),
                                    columns[13]);
                                results.Add(order);                           
                        }

                    }
                }
                return results;
            }
        }

        // Reading a single order from the text file
        public Order LoadOrder(int orderNumber, DateTime orderDate)
        {
            List<Order> orders = GetAllOrders(orderDate);
            return orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
        }

        // overwiting the text file with updated information
        private void OverwriteFile(List<Order> orders, DateTime date)
        {
            string fileName = $"Orders_{date.Month}{date.Day}{date.Year}.txt";
            var filePath = $@"{_folderPath}{fileName}";
            File.Delete(filePath);

            using (var sr = File.CreateText(filePath))
            {
                sr.WriteLine(
                    "Order Number,Order Date, Customer Name, State, Tax Rate, Product Type, Area, Cost Per Square Foot, Labor Per Square Foot, Total Material Cost, Total Labor Cost, Total Cost, Status");
                
                foreach (var order in orders)
                {
                    sr.WriteLine(order.ToString());
                }
            }
        }

        // updating the informtaion in a particular order and overwriting the text file
        public void UpdateOrder(Response<Order> order, DateTime date)
        {
            List<Order> existingOrders = GetAllOrders(date);
            //var orderToUpdate = LoadOrder(order.Data.OrderNumber, date);
            var orderToUpdate = existingOrders.First(o => o.OrderNumber == order.Data.OrderNumber);
            
            if (date != order.Data.OrderDate)
            {
                existingOrders.Remove(orderToUpdate);
                OverwriteFile(existingOrders, date);
                orderToUpdate.Status = OrderStatus.Modified;
                AddOrder(order, order.Data.OrderDate);
            }
            else
            {
                orderToUpdate.Status = OrderStatus.Modified;
                orderToUpdate.Area = order.Data.Area;
                orderToUpdate.CustomerName = order.Data.CustomerName;
                orderToUpdate.ProductType = order.Data.ProductType;
                orderToUpdate.State = order.Data.State;
                orderToUpdate.OrderNumber = order.Data.OrderNumber;
                orderToUpdate.OrderDate = order.Data.OrderDate;
                orderToUpdate.CostPerSqft = order.Data.CostPerSqft;
                orderToUpdate.LaborCostPerSqft = order.Data.LaborCostPerSqft;
                orderToUpdate.TaxRate = order.Data.TaxRate;
                orderToUpdate.TotalCost = order.Data.TotalCost;
                orderToUpdate.TotalLaborCost = order.Data.TotalLaborCost;
                orderToUpdate.TotalMaterialCost = order.Data.TotalMaterialCost;
                orderToUpdate.TotalTax = order.Data.TotalTax;
                OverwriteFile(existingOrders, date);
                
            }
        }

        public void DeleteAnOrder(Order order, DateTime date)
        {
            List<Order> allOrders = GetAllOrders(date);
            //var orderToUpdate = LoadOrder(order.Data.OrderNumber, date);
            var orderToDelete = allOrders.First(o => o.OrderNumber == order.OrderNumber);
            allOrders.Remove(orderToDelete);
            OverwriteFile(allOrders,date);
            orderToDelete.Status = OrderStatus.Deleted;
            AddDeletedOrder(orderToDelete);
        }
            
        // deleting an order by changing the status of the order to deleted
        public void DeleteOrder(Order order)
        {
            //var orderToDelete = LoadOrder(order.OrderNumber,order.OrderDate);           
            var orders = GetAllOrders(order.OrderDate);
            var orderToDelete = orders.First(o => o.OrderNumber == order.OrderNumber);
            orderToDelete.Status = OrderStatus.Deleted;
            OverwriteFile(orders,orderToDelete.OrderDate);
        }        


        public Order AddDeletedOrder(Order newOrder)
        {
            
            var filePath = @"DataFiles\DeletedOrders.txt";            

            if (!File.Exists(filePath))
            {
                using (StreamWriter sr = File.CreateText(filePath))
                {
                    sr.WriteLine(
                    "Order Number,Order Date, Customer Name, State, Tax Rate, Product Type, Area, Cost Per Square Foot, Labor Per Square Foot, Total Material Cost, Total Labor Cost, Total Cost, Status");
                    sr.WriteLine(newOrder.ToString());
                }
            }
            else
            {
 
                using (StreamWriter sr = File.AppendText(filePath))
                {
                    sr.WriteLine(newOrder.ToString());
                }

            }

            return newOrder;
        }

        // Adding a new order in the text file based on the user inputs
        public Order AddOrder(Response<Order> newOrder, DateTime date)
        {
            string fileName = $"Orders_{date.Month}{date.Day}{date.Year}.txt";
            var filePath = $"{_folderPath}{fileName}";

            List<Order> existingOrders = GetAllOrders(date);
            existingOrders.Add(newOrder.Data);

            if (!File.Exists(filePath))
            {
                using (StreamWriter sr = File.CreateText(filePath))
                {
                    sr.WriteLine(
                    "Order Number,Order Date, Customer Name, State, Tax Rate, Product Type, Area, Cost Per Square Foot, Labor Per Square Foot, Total Material Cost, Total Labor Cost, Total Cost, Status");
                    sr.WriteLine(newOrder.Data.ToString());
                }
            }
            else
            {
                newOrder.Data.OrderNumber = GetNextOrderNumberForDate(date);
                using (StreamWriter sr = File.AppendText(filePath))
                {                    
                    sr.WriteLine(newOrder.Data.ToString());
                }
             
            }

            return newOrder.Data;
        }

        // Generating a new order number for adding orders
        public int GetNextOrderNumberForDate(DateTime orderDate)
        {
            List<Order> orders = GetAllOrders(orderDate);
            return orders.Count + 1;
        }
    }
}
