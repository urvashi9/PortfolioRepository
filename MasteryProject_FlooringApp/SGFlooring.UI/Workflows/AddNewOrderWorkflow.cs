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
    public class AddNewOrderWorkflow
    {
        private string name,state,productType;
        private decimal area;
        private DateTime orderDate;
        OrderManager manager = new OrderManager();
        Response<Order> newOrder = new Response<Order>();

        public void Execute()
        {
            Console.Clear();
            UserUtilities.PrintStatesAndProducts();
            
            GetNewOrderInformation();           
            newOrder = manager.AddNewOrder(name, state, productType, area, orderDate);
            if (newOrder.Success)
            {
                Console.WriteLine();
                OrdersScreen.PrintSingleOrder(newOrder);
                AskForConfirmation();
                Console.WriteLine(newOrder.Message);
                ShowNewMenu();
            }
            else
            {
                OrdersScreen.WorkflowErrorScreen(newOrder.Message);
            }
            
        }

        public void AskForConfirmation()
        {
            string YesNo;
            bool b;
            do
            {
                YesNo = UserUtilities.GetStringFromUser("\nDo You Want To Save The Order?(Y/N) ").ToUpper();
                if (YesNo == "N")
                    b = false;
                    break;
            } while (b);
            
            switch (YesNo)
            {
                case "Y":
                    manager.SaveOrder(newOrder);
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice");
                    break;

            }
        }

        public void GetNewOrderInformation()
        {           
            name = UserUtilities.GetStringFromUser("\n\nEnter The Name Of The Customer: ");
            state =
                UserUtilities.GetStringFromUser(
                    "Enter The Abbreviated State Name(Refer The Above List For The Correct Abbreviation Of Your State Name): ");
            productType =
                UserUtilities.GetStringFromUser(
                    "Enter The Name Of The Product You Want(See Full List Of Product Above): ");
            area = UserUtilities.GetDecimalFromUser("Enter The Area Of The Room For Floor Installation(sqft): ",
                "Please Enter A Valid Area.");
            orderDate = UserUtilities.GetDateFromUser("Enter The Order Date: ", "\nEnter A Valid Date");
        }

        public void ShowNewMenu()
        {
            do
            {
                Console.WriteLine("\nActions:");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Edit this order");
                Console.WriteLine("2. Remove this order");
                Console.WriteLine("(B) Back to Main Menu");

                string input = UserUtilities.GetStringFromUser("\nEnter Choice: ");


                if (input.Substring(0, 1).ToUpper() == "B")
                    break;

                ProcessChoice(input);

            } while (true);
        }

        public void ProcessChoice(string str)
        {
            switch (str)
            {
                case "1":
                    var editWorkflow = new UpdateOrderWorkflow(newOrder.Data.OrderNumber,orderDate);
                    editWorkflow.GetSingleOrder(newOrder.Data.OrderNumber, orderDate);
                    break;
                case "2":
                    var deleteWorkflow = new RemoveOrderWorkflow(newOrder.Data.OrderNumber, orderDate);
                    deleteWorkflow.GetSingleOrder(newOrder.Data.OrderNumber, orderDate);
                    deleteWorkflow.CheckIfSure();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
