using System;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.UI.Utilities;

namespace SGFlooring.UI.Workflows
{
    public class DisplayOrdersWorkflow
    {
        private DateTime date;
        private int orderNumber;

        public DisplayOrdersWorkflow()
        { }

        public DisplayOrdersWorkflow(int ordNum,DateTime ordDate)
        {
            orderNumber = ordNum;
            date = ordDate;
        }


        public void Execute()
        {
            Console.Clear();           
            date = UserUtilities.GetDateFromUser("Please enter the date you would like to view all orders for (Local Format only): ", "\nThe date you specified was invalid.\nYou can learn about local time formats using the link below:\nhttps://en.wikipedia.org/wiki/Date_format_by_country\n");

            // instantiating new order manager to call the display orders method
            var manager = new OrderManager();
            var orders = manager.DisplayAllOrders(date);
            OrdersScreen.PrintAllOrderDetails(orders);
            ShowNewMenu();
        }


        // New menu display inside the display all orders workflow
        public void ShowNewMenu()
        {
            string input;
            do
            {
                Console.WriteLine("\nActions:");
                Console.WriteLine("=======================");
                Console.WriteLine("1. View an order");
                Console.WriteLine("2. Edit an order");
                Console.WriteLine("3. Remove an order");
                Console.WriteLine("(B) Back to Main Menu");
                input = UserUtilities.GetStringFromUser("\nEnter Your Choice: ");
                if (input == "B")
                {
                    break;
                }
                
                orderNumber = UserUtilities.GetIntFromUser("Please enter the order number: ",
                "Invalid entry. Make sure you entered a NUMBER.");
                ProcessChoice(input);
            } while (input!="3");
                      
        }

        public void ProcessChoice(string str)
        {
            switch (str)
            {
                case "1":
                    DisplaySingleOrder();
                    var singleOrderWorkflow = new DisplaySingleOrderWorkflow(orderNumber,date);
                    singleOrderWorkflow.ShowNewMenu(); 
                    break;
                case "2":                   
                    var editWorkflow = new UpdateOrderWorkflow(orderNumber,date);                    
                    editWorkflow.GetSingleOrder(orderNumber, date);
                    UserUtilities.PressKeyForContinue();                 
                    break;
                case "3":
                    var deleteWorkflow = new RemoveOrderWorkflow(orderNumber, date);                    
                    deleteWorkflow.GetSingleOrder(orderNumber, date);
                    deleteWorkflow.CheckIfSure();
                    UserUtilities.PressKeyForContinue();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        public void DisplaySingleOrder()
        {
            var manager = new OrderManager();
            var order = new Response<Order>();
            var orders = manager.DisplayAllOrders(date);
            
            order.Success = orders.Exists(o => o.OrderNumber == orderNumber);
            order = manager.ViewSingleOrder(orderNumber, date);
            if (order.Success)
            {
                Console.Clear();                
                OrdersScreen.PrintSingleOrder(order);
            }
            else
            {
                OrdersScreen.WorkflowErrorScreen(order.Message);
            }           
        }       
    }
}
