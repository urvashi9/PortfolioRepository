using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.BLL;

namespace SGFlooring.UI.Utilities
{
    public class UserUtilities
    {
        public static int GetIntFromUser(string message, string errorMessage)
        {
            bool b = false;
            int n;
            do
            {
                Console.Write(message);
                string str = Console.ReadLine();
                b = int.TryParse(str, out n);
                if(!b)
                    Console.WriteLine(errorMessage);
                else
                    b = true;
            } while (!b);
            return n;
        }

        public static decimal GetDecimalFromUser(string message, string errorMessage)
        {
            bool b = false;
            decimal n;
            do
            {
                Console.Write(message);
                string str = Console.ReadLine();
                b = decimal.TryParse(str, out n);
                if (!b)
                    Console.WriteLine(errorMessage);
                else
                    b = true;
            } while (!b);
            return n;
        }

        public static DateTime GetDateFromUser(string message, string errorMessage)
        {
            bool b = false;
            DateTime n;
            do
            {             
                Console.Write(message);
                string str = Console.ReadLine();
                b = DateTime.TryParse(str, out n);
                if (!b)
                    Console.WriteLine(errorMessage);
                else
                    b = true;
            } while (!b);
            return n;
        }

        public static string GetStringFromUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine().ToUpper();
        }

        public static void PressKeyForContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void PrintStatesAndProducts()
        {
            var stateManager = new StateManager();
            var prodManager = new ProductManager();
            var states = stateManager.GetAllStates();
            OrdersScreen.PrintAllStates(states);
            var products = prodManager.GetAllProducts();
            OrdersScreen.PrintAllProducts(products);
        }
    }
}
