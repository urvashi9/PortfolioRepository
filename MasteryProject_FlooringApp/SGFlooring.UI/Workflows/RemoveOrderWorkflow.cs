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
    public class RemoveOrderWorkflow
    {
        
        private int orderNumber;
        private DateTime _date;
        private Response<Order> order;
        OrderManager manager = new OrderManager();

        public RemoveOrderWorkflow()
        {
            
        }

        public RemoveOrderWorkflow(int ordNum, DateTime ordDate)
        {
            orderNumber = ordNum;
            _date = ordDate;
        }

        public void Execute()
        {
            orderNumber = UserUtilities.GetIntFromUser("Please enter the order number:", "Invalid entry. Make sure you are typing in a NUMBER.");
            _date = UserUtilities.GetDateFromUser("Please enter the order date (Local Format only): ", "\nThe date you specified was invalid.\nYou can learn about local time formats using the link below:\nhttps://en.wikipedia.org/wiki/Date_format_by_country\n");
            GetSingleOrder(orderNumber,_date);
            if(order != null)
                CheckIfSure();
        }

        public void CheckIfSure()
        {
            Console.WriteLine("\nAre you sure you want to delete this order?(Y/N)");
            string str = Console.ReadLine().ToUpper();
            if (str == "Y")
            {
                manager.RemoveOrder(orderNumber, _date);
                Console.WriteLine("\nOrder Successfully Deleted");
            }
            else
            {
                UserUtilities.PressKeyForContinue();
            }
        }

        public void GetSingleOrder(int orderNumber, DateTime date)
        {
            var orders = manager.DisplayAllOrders(date);
            var result = orders.Exists(o => o.OrderNumber == orderNumber && o.OrderDate == date);
            if (result)
            {
                Console.Clear();
                order = manager.ViewSingleOrder(orderNumber, date);
                OrdersScreen.PrintSingleOrder(order);
            }
            else
            {
                Console.WriteLine("\nOrder does not exist.");
            }
        }
    }
}
