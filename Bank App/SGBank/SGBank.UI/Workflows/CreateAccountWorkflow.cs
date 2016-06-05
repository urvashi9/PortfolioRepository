using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.UI.Utilities;
using SGBank.BLL;
using SGBank.Models;


namespace SGBank.UI.Workflows
{
    public class CreateAccountWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            VerifyAmount();
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
        }

        public void VerifyAmount()
        {
            string yesOrNo = UserPrompts.GetStringFromUser("The minimum deposit for a new account is $100.00.\nPlease verify the customer can deposit at least this amount (Y/N)");
            if (yesOrNo.ToUpper() == "Y")
            {
                GetAccountInformation();
            }
            else
            {
                Console.WriteLine("Insufficient intitial deposit amount. Please try again later.");
            }

        }

        public void GetAccountInformation()
        {
            string fName = UserPrompts.GetStringFromUser("Please enter the first name for the account: ");
            string lName = UserPrompts.GetStringFromUser("Please enter the last name for the account: ");
            decimal amount = UserPrompts.GetDecimalFromUser("Please enter the initial deposit amount: ");
            AccountManager acctManager = new AccountManager();
            Account newAccount = acctManager.CreateNewAccount(fName, lName, amount);
            Console.Clear();
            Console.WriteLine("New Account Details: ");
            AccountScreens.PrintAccountDetails(newAccount);
        }
    }
}
