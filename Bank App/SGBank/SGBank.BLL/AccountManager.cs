using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.BLL
{
    public class AccountManager
    {
        public Response<Account> GetAccount(int accountNumber)
        {
            var repo = new AccountRepository();
            var result = new Response<Account>();

            try
            {
                var account = repo.LoadAccount(accountNumber);

                if (account == null)
                {
                    result.Success = false;
                    result.Message = "Account was not found.";
                }
                else
                {
                    result.Success = true;
                    result.Data = account;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "There was an error. Please try again later.";
                
            }

            return result;
        }

        public Response<DepositReciept> Deposit(decimal amount, Account account)
        {
            var response = new Response<DepositReciept>();

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must provide a positive value.";
                }
                else
                {
                    account.Balance += amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);

                    response.Success = true;
                    response.Data = new DepositReciept();
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.DepositAmount = amount;
                    response.Data.NewBalance = account.Balance;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Account is no longer valid.";
                //log.logError(ex.Message);
            }

            return response;
        }

        public Response<WithdrawReceipt> Withdraw(decimal amount, Account account)
        {
            var response = new Response<WithdrawReceipt>();

            try
            {
                if (amount <= 0)
                {
                    response.Success = false;
                    response.Message = "Must provide a positive value.";
                }
                else if (amount > account.Balance)
                {
                    response.Success = false;
                    response.Message = "Withdrawl amount cannot be greater than account balance.";
                }
                else
                {
                    account.Balance -= amount;
                    var repo = new AccountRepository();
                    repo.UpdateAccount(account);

                    response.Success = true;
                    response.Data = new WithdrawReceipt();
                    response.Data.AccountNumber = account.AccountNumber;
                    response.Data.WithdrawAmount = amount;
                    response.Data.NewBalance = account.Balance;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Account is no longer valid.";
            }

            return response;
        }

        public Response<TransferReceipt> Transfer(decimal amount, Account myAccount, Account yourAccount)
        {
            var response = new Response<TransferReceipt>();
            
            
            try
            {

                if (myAccount.AccountNumber == yourAccount.AccountNumber)
                {
                    response.Success = false;
                    response.Message = "You cannot transfer the money from/to the same account.";
                    response.Data = null;
                }
                else if (amount > myAccount.Balance)
                {
                    response.Success = false;
                    response.Message = "You cannot transfer an amount greater than the current balance.";
                }
                else if(amount <=0)
                {
                    response.Success = false;
                    response.Message = "Must provide a positive value.";
                }
                else
                {
                    Response<WithdrawReceipt> responseWithdraw = Withdraw(amount, myAccount);
                    Response<DepositReciept> responseDeposit = Deposit(amount, yourAccount);
                    response.Data = new TransferReceipt();
                    response.Data.AccountNumber1 = responseWithdraw.Data.AccountNumber;
                    response.Data.AccountNumber2 = responseDeposit.Data.AccountNumber;
                    response.Data.TransferAmount = responseWithdraw.Data.WithdrawAmount;
                    response.Data.NewBalanceInAccount1 = responseWithdraw.Data.NewBalance;
                    response.Data.NewBalanceInAccount2 = responseDeposit.Data.NewBalance;
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Account is no longer valid.";
            }
           
            return response;
        }

        public Account CreateNewAccount(string fName, string lName, decimal amount)
        {
            Account newAccount = new Account();
            var repo = new AccountRepository();

            if (amount < 100.00m)
            {
                Console.WriteLine("The minimum deposit required to open an account is $100.00. Please try again."); 
            }
            else
            {
                
                newAccount.FirstName = fName;
                newAccount.LastName = lName;
                newAccount.Balance = amount;
                newAccount.AccountNumber = repo.CreateAccount(newAccount);
            }

            return newAccount;
        }

        public void RemoveAccount(int accountNumber)
        {
            var repo = new AccountRepository();
            var account = GetAccount(accountNumber);
            if (!account.Success)
            {
                Console.WriteLine("Account does not exist.");
            }
            else
            {
                if (account.Data.Balance > 0)
                {
                    Console.WriteLine("This account has a positive balance. Please withdraw the entire balance and then try again.");
                }
                else if (account.Data.Balance < 0)
                {
                    Console.WriteLine("This account has a negative balance, and cannot be deleted.");
                }
                else
                {
                    repo.DeleteAccount(accountNumber);
                    Console.WriteLine("Account successfully deleted.");
                }
            }                   
        }

        public void ShowAllAccounts(List<Account> accounts)
        {
            var repo = new AccountRepository();
            accounts = repo.GetAllAccounts();
            Console.WriteLine("All accounts are as shown below: ");
            Console.WriteLine("========================================");
            foreach (var account in accounts)
            {
                Console.WriteLine($"\nAccount Number: {account.AccountNumber}");
                Console.WriteLine($"Name : {account.FirstName} {account.LastName}");
                Console.WriteLine($"Balance : {account.Balance:C}");
            }
        }

        public Account GetMaxBalance(List<Account> accounts)
        {
            var repo = new AccountRepository();
            Account account = new Account();
            accounts = repo.GetAllAccounts();
            var result = accounts.OrderByDescending(i => i.Balance).First();
            Console.WriteLine("\n\nThe account with maximum balance is:\n");
            return account = repo.LoadAccount(result.AccountNumber);
        }

        public Account GetMinBalance(List<Account> accounts)
        {
            var repo = new AccountRepository();
            Account account = new Account();
            accounts = repo.GetAllAccounts();
            var result = accounts.OrderBy(i => i.Balance).First();
            Console.WriteLine("\n\nThe account with minimum balance is:\n");
            return account = repo.LoadAccount(result.AccountNumber);
        }
    }
}
