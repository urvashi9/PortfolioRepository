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
    public class UpdateOrderWorkflow
    {
        private string name, state, productType;
        private decimal area;
        private int _orderNumber;
        private DateTime date;
        private Order UpdatedInfoOrder;
        OrderManager manager = new OrderManager();
        Response<Order> order = new Response<Order>();
        Response<Order> newOrder = new Response<Order>();

        public UpdateOrderWorkflow()
        {
            
        }

        public UpdateOrderWorkflow(int ordNum, DateTime ordDate)
        {
            _orderNumber = ordNum;
            date = ordDate;
        }

        public void Execute()
        {
            _orderNumber = UserUtilities.GetIntFromUser("Please enter the order number:",
                "Invalid entry. Make sure you are typing in a NUMBER.");
            date =
                UserUtilities.GetDateFromUser(
                    "Please enter the order date (Local Format only): ",
                    "\nThe date you specified was invalid.\nYou can learn about local time formats using the link below:\nhttps://en.wikipedia.org/wiki/Date_format_by_country\n");
            GetSingleOrder(_orderNumber,date);
        }

        public Order GetUpdatedInformation(Order order)
        {
            UserUtilities.PrintStatesAndProducts();
            order.CustomerName = UserUtilities.GetStringFromUser("\nEnter The Name Of The Customer: ");
            order.State =
                UserUtilities.GetStringFromUser(
                    "Enter The Abbreviated State Name(Refer The Above List For The Correct Abbreviation Of Your State Name): ");
            order.ProductType =
                UserUtilities.GetStringFromUser(
                    "Enter The Name Of The Product You Want(See Full List Of Product Above): ");
            order.Area = UserUtilities.GetDecimalFromUser("Enter The Area Of The Room For Floor Installation(sqft): ",
                "Please Enter A Valid Area.");
            order.OrderDate = UserUtilities.GetDateFromUser("Enter The Order Date: ", "\nEnter A Valid Date");
            return order;
        }

        public void GetSingleOrder(int orderNumber,DateTime date)
        {         
            var orders = manager.DisplayAllOrders(date);
            order.Success = orders.Exists(o => o.OrderNumber == orderNumber && o.OrderDate == date);
            order = manager.ViewSingleOrder(orderNumber, date);
            _orderNumber = orderNumber;
            if (order.Success)
            {
                Console.Clear();
                OrdersScreen.PrintSingleOrder(order);
                Console.WriteLine();
                UpdatedInfoOrder = GetUpdatedInformation(order.Data);
                AskForConfirmation();
            }
            else
            {
                OrdersScreen.WorkflowErrorScreen(order.Message);
            }
        }


        public void AskForConfirmation()
        {
            string YesNo;
            bool b = false;
            do
            {
                YesNo = UserUtilities.GetStringFromUser("\nDo You Want To Save The Order?(Y/N) ").ToUpper();
                if (YesNo == "N")
                {
                    b = false;
                    Console.WriteLine("\nOrder Not Updated!");
                    UserUtilities.PressKeyForContinue();
                    break;
                }
                else
                {
                    switch (YesNo)
                    {
                        case "Y":
                            Console.Clear();
                            newOrder = manager.UpdateOrder(UpdatedInfoOrder,date);
                            Console.WriteLine();
                            OrdersScreen.PrintSingleOrder(newOrder);                            
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice");                           
                            break;
                    }
                }
                
            } while (b);         
        }
    }
}
