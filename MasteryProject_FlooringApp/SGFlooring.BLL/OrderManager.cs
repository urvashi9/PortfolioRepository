using System;
using System.Collections.Generic;
using SGFlooring.Data;
using SGFlooring.Data.Interfaces;
using SGFlooring.Models;

namespace SGFlooring.BLL
{
    public class OrderManager
    {
        private IOrderRepository _repo;       

        public OrderManager()
        {
            _repo = OrderRepositoryFactory.GetOrderRepository();
        }

        LogManager logManager = new LogManager();
        public List<Order> DisplayAllOrders(DateTime orderDate)
        {
            return _repo.GetAllOrders(orderDate);
        }

        public Response<Order> ViewSingleOrder(int orderNumber, DateTime orderDate)
        {
            var result = new Response<Order>();
            
            try
            {
                var order = _repo.LoadOrder(orderNumber, orderDate);

                if (order == null)
                {
                    result.Message = "Order Not Found. Recheck the order number and then try again.";
                    result.Success = false;
                    logManager.ErrorLogs(DateTime.Now, result.Message);
                }
                else
                {
                    result.Success = true;
                    result.Data = order;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "There was an error. Please try again later.";
                logManager.ErrorLogs(DateTime.Now, result.Message);
            }
            return result;
        }

        public Response<Order> AddNewOrder(string name, string state, string productType, decimal area, DateTime orderDate)
        {
            var newOrder = new Response<Order>();
            var stateManager = new StateManager();
            var productManager = new ProductManager();
            var prodList = productManager.GetAllProducts();
            var stateList = stateManager.GetAllStates();
            try
            {
                if (stateList.Exists(s => s.StateAbbr.ToUpper() == state) && prodList.Exists(p => p.ProductType.ToUpper() == productType))
                {
                    newOrder.Success = true;
                    newOrder.Data = new Order();   
                    newOrder.Data.OrderDate = orderDate;
                    newOrder.Data.CustomerName = name;
                    newOrder.Data.State = state;
                    newOrder.Data.TaxRate = stateManager.GetState(stateList,state).Data.TaxRate;
                    newOrder.Data.Area = area;
                    newOrder.Data.ProductType = productType;
                    newOrder.Data.CostPerSqft = productManager.GetProduct(prodList,productType).Data.CostPerSqft;
                    newOrder.Data.LaborCostPerSqft =
                        productManager.GetProduct(prodList, productType).Data.LaborCostPerSqft;
                    newOrder.Data.TotalMaterialCost = newOrder.Data.Area * newOrder.Data.CostPerSqft;
                    newOrder.Data.TotalLaborCost = newOrder.Data.Area * newOrder.Data.LaborCostPerSqft;
                    decimal total = newOrder.Data.TotalLaborCost + newOrder.Data.TotalMaterialCost;
                    newOrder.Data.TotalTax = total * newOrder.Data.TaxRate / 100;
                    newOrder.Data.TotalCost = total + newOrder.Data.TotalTax;
                    newOrder.Data.Status = OrderStatus.Active;
                    newOrder.Data.OrderNumber = _repo.GetNextOrderNumberForDate(orderDate);
                    newOrder.Message = "Order Added Successfully!";
                }
                else if (!stateList.Exists(s => s.StateAbbr.ToUpper() == state) && prodList.Exists(p => p.ProductType.ToUpper() == productType))
                {
                    newOrder.Message = "\nWe do not service in the state of " + state + ".";
                    newOrder.Success = false;
                    logManager.ErrorLogs(DateTime.Now, newOrder.Message);

                }
                else if (stateList.Exists(s => s.StateAbbr.ToUpper() == state) && !prodList.Exists(p => p.ProductType.ToUpper() == productType))
                {
                    newOrder.Message = "\nThe product you want does not exist.";
                    newOrder.Success = false;
                    logManager.ErrorLogs(DateTime.Now, newOrder.Message);
                }
            }
            catch (Exception ex)
            {
                newOrder.Success = false;
                newOrder.Message = "There was an error. Please try again later.";
                logManager.ErrorLogs(DateTime.Now, newOrder.Message);
            }
            return newOrder;
        }

        public void SaveOrder(Response<Order> order)
        {
            try
            {
                _repo.AddOrder(order, order.Data.OrderDate);
                order.Success = true;
            }
            catch (Exception ex)
            {
                order.Message = "There was an error. Please try again.";
                order.Success = false;
                logManager.ErrorLogs(DateTime.Now, order.Message);
            }
        }


        public Response<Order> UpdateOrder(Order newOrder, DateTime oldDate)
        {
            var order = new Response<Order>();
            var stateManager = new StateManager();
            var productManager = new ProductManager();
            var prodList = productManager.GetAllProducts();
            var stateList = stateManager.GetAllStates();
            try
            {
                if (stateList.Exists(s => s.StateAbbr.ToUpper() == newOrder.State) && prodList.Exists(p => p.ProductType.ToUpper() == newOrder.ProductType))
                {
                    order.Data = new Order();
                    order.Data.OrderNumber = newOrder.OrderNumber;
                    order.Data.OrderDate = newOrder.OrderDate;
                    order.Data.CustomerName = newOrder.CustomerName;
                    order.Data.State = newOrder.State;
                    order.Data.TaxRate = stateManager.GetState(stateList,newOrder.State).Data.TaxRate;
                    order.Data.Area = newOrder.Area;
                    order.Data.ProductType = newOrder.ProductType;
                    order.Data.CostPerSqft = productManager.GetProduct(prodList, newOrder.ProductType).Data.CostPerSqft;
                    order.Data.LaborCostPerSqft =
                        productManager.GetProduct(prodList, newOrder.ProductType).Data.LaborCostPerSqft;
                    order.Data.TotalMaterialCost = order.Data.Area * order.Data.CostPerSqft;
                    order.Data.TotalLaborCost = order.Data.Area * order.Data.LaborCostPerSqft;
                    decimal total = order.Data.TotalLaborCost + order.Data.TotalMaterialCost;
                    order.Data.TotalTax = total * order.Data.TaxRate / 100;
                    order.Data.TotalCost = total + order.Data.TotalTax;
                    order.Data.Status = OrderStatus.Modified;
                    _repo.UpdateOrder(order, oldDate);
                    order.Message = "Order updated successfully!";
                    order.Success = true;
                }
                else if (!stateList.Exists(s => s.StateAbbr.ToUpper() == newOrder.State) && prodList.Exists(p => p.ProductType.ToUpper() == newOrder.ProductType))
                {
                    
                    order.Message = stateManager.GetState(stateList, newOrder.State).Message;
                    order.Success = false;
                    logManager.ErrorLogs(DateTime.Now, order.Message);
                }
                else if (stateList.Exists(s => s.StateAbbr.ToUpper() == newOrder.State) && !prodList.Exists(p => p.ProductType.ToUpper() == newOrder.ProductType))
                {
                    order.Message = productManager.GetProduct(prodList, newOrder.ProductType).Message; 
                    order.Success = false;
                    logManager.ErrorLogs(DateTime.Now, order.Message);
                }
            }                   
            catch (Exception ex)
            {
                order.Success = false;
                order.Message = "There was an error. Please try again later.";
                logManager.ErrorLogs(DateTime.Now, order.Message);
            }
            return order;
        }

        public void RemoveOrder(int orderNumber, DateTime orderDate)
        {            
                Order order = _repo.LoadOrder(orderNumber, orderDate);
                _repo.DeleteAnOrder(order,orderDate);
        }


    }
}
