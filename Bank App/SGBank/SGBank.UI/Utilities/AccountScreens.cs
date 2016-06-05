using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.UI.Utilities
{
    public static class AccountScreens
    {
        public static void PrintAccountDetails(Account account)
        {
            //Console.Clear();
            Console.WriteLine("Account Information");
            Console.WriteLine("===============================");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Name: {account.FirstName} {account.LastName}");
            Console.WriteLine($"Account Balance: {account.Balance:c}");
        }

        public static void WorkflowErrorScreen(string message)
        {
            Console.Clear();
            Console.WriteLine("An error occured. {0}", message);
            UserPrompts.PressKeyForContinue();
        }

        public static void DepositDetails(DepositReciept reciept)
        {
            Console.Clear();
            Console.WriteLine("Deposited {0:c} to account {1}.", 
                reciept.DepositAmount,
                reciept.AccountNumber);
            Console.WriteLine("New Balance is {0:c}", reciept.NewBalance);
            UserPrompts.PressKeyForContinue();
        }

        public static void WithdrawDetails(WithdrawReceipt reciept)
        {
            Console.Clear();
            Console.WriteLine("Withdrew {0:c} from account {1}.",
                reciept.WithdrawAmount,
                reciept.AccountNumber);
            Console.WriteLine("New Balance is {0:c}", reciept.NewBalance);
            UserPrompts.PressKeyForContinue();
        }

        public static void TransferDetails(TransferReceipt receipt)
        {
            Console.Clear();
            Console.WriteLine($"You transferred {receipt.TransferAmount:C} from account number {receipt.AccountNumber1} to account number {receipt.AccountNumber2}");
            Console.WriteLine($"Account Number {receipt.AccountNumber1} : New Balance {receipt.NewBalanceInAccount1:C}\nAccount Number {receipt.AccountNumber2} : New Balance {receipt.NewBalanceInAccount2:C} ");
            UserPrompts.PressKeyForContinue();
        }
    }
}
