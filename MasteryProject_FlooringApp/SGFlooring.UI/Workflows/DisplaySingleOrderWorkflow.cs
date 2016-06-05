using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.Models;
using SGFlooring.UI.Utilities;

namespace SGFlooring.UI.Workflows
{
    public class DisplaySingleOrderWorkflow
    {
        private int orderNumber;
        private DateTime date;

        public DisplaySingleOrderWorkflow()
        {
            
        }

        public DisplaySingleOrderWorkflow(int ordrNum, DateTime ordDate)
        {
            orderNumber = ordrNum;
            date = ordDate;
        }

        public void Execute()
        {
            var manager = new OrderManager();  
            var order = new Response<Order>();         
            orderNumber = UserUtilities.GetIntFromUser("Please enter the order number:", "Invalid entry. Make sure you are typing in a NUMBER.");
            date =  UserUtilities.GetDateFromUser("Please enter the date you would like to view all orders for (Local Format only): ", "\nThe date you specified was invalid.\nYou can learn about local time formats using the link below:\nhttps://en.wikipedia.org/wiki/Date_format_by_country\n");
            var orders = manager.DisplayAllOrders(date);
            order.Success = orders.Exists(o => o.OrderNumber == orderNumber && o.OrderDate == date);
            order = manager.ViewSingleOrder(orderNumber, date);
            if (order.Success)
            {
                Console.Clear();                
                OrdersScreen.PrintSingleOrder(order);
                ShowNewMenu();
            }
            else
            {
                OrdersScreen.WorkflowErrorScreen(order.Message);
                UserUtilities.PressKeyForContinue();
            }
        }

        public void ShowNewMenu()
        {
            string input;
            do
            {
                Console.WriteLine("\nActions:");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Edit this order");
                Console.WriteLine("2. Remove this order");
                Console.WriteLine("(B) Back to Main Menu");

                input = UserUtilities.GetStringFromUser("\nEnter Choice: ");

                if (input.Substring(0, 1).ToUpper() == "B")
                    break;

                ProcessChoice(input);

            } while (input!="2");
        }

        public void ProcessChoice(string str)
        {
            switch (str)
            {
                case "1":
                    var editWorkflow = new UpdateOrderWorkflow(orderNumber,date);
                    editWorkflow.GetSingleOrder(orderNumber,date);
                    break;
                case "2":
                    var deleteWorkflow = new RemoveOrderWorkflow(orderNumber, date);
                    deleteWorkflow.GetSingleOrder(orderNumber,date);
                    deleteWorkflow.CheckIfSure();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
