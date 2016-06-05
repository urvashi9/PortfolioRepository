using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class ReportWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            DisplayReportMenu();
        }

        private void DisplayReportMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("REPORTS MENU: ");
                Console.WriteLine("\n1. Show a list of all accounts");
                Console.WriteLine("2. Show account with the highest balance");
                Console.WriteLine("3. Show account with the lowest balance");
                Console.WriteLine("\n(Q) to return to main menu");

                string input = UserPrompts.GetStringFromUser("\nEnter Choice: ");

                if (input.Substring(0, 1).ToUpper() == "Q")
                    break;

                ProcessChoice(input);

            } while (true);
        }

        private void ProcessChoice(string choice)
        {
            var accounts = new List<Account>();
            var manager = new AccountManager();
            var account = new Account();

            switch (choice)
            {
                case "1":
                    manager.ShowAllAccounts(accounts);
                    Console.WriteLine();
                    UserPrompts.PressKeyForContinue();
                    break;
                case "2":
                    manager = new AccountManager();
                    account = manager.GetMaxBalance(accounts);
                    AccountScreens.PrintAccountDetails(account);
                    Console.WriteLine();
                    UserPrompts.PressKeyForContinue();
                    break;
                case "3":
                    account = manager.GetMinBalance(accounts);
                    AccountScreens.PrintAccountDetails(account);
                    Console.WriteLine();
                    UserPrompts.PressKeyForContinue();
                    break;
            }
        }
    }
}
