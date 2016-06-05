using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;


namespace SGBank.Data
{
    public class AccountRepository
    {
        private const string _filePath = @"DataFiles\Bank.txt";

        public List<Account> GetAllAccounts()
        {
            List<Account> results = new List<Account>();

            var rows = File.ReadAllLines(_filePath);

            for (int i = 1; i < rows.Length; i++)
            {
                var columns = rows[i].Split(',');

                var account = new Account(int.Parse(columns[0]), columns[1], columns[2], decimal.Parse(columns[3]));
                
                results.Add(account);
            }

            return results;
        }

        public Account LoadAccount(int accountNumber)
        {
            List<Account> accounts = GetAllAccounts();
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void UpdateAccount(Account account)
        {
            var accounts = GetAllAccounts();

            var accountToUpdate = accounts
                .First(a => a.AccountNumber == account.AccountNumber);

            accountToUpdate.FirstName = account.FirstName;
            accountToUpdate.LastName = account.LastName;
            accountToUpdate.Balance = account.Balance;

            OverwriteFile(accounts);
        }

        private void OverwriteFile(List<Account> accounts)
        {
            File.Delete(_filePath);

            using (var writer = File.CreateText(_filePath))
            {
                writer.WriteLine("AccountNumber,FirstName,LastName,Balance");
                foreach (var account in accounts)
                {
                    writer.WriteLine("{0},{1},{2},{3}",
                        account.AccountNumber,
                        account.FirstName,
                        account.LastName,
                        account.Balance);
                }
            }
        }

        public int CreateAccount(Account newAccount)
        {
            List<Account> existingAccounts = GetAllAccounts();
            newAccount.AccountNumber = existingAccounts.Max(i => i.AccountNumber) + 1;
            existingAccounts.Add(newAccount);
            OverwriteFile(existingAccounts);
            return newAccount.AccountNumber;
        }

        public void DeleteAccount(int accountNumber)
        {
            List<Account> accounts = GetAllAccounts();
            Account removeAccount = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            accounts.Remove(removeAccount);
            OverwriteFile(accounts);
        }

        public void ShowAllAccount(List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.AccountNumber} : {account.FirstName} {account.LastName} : {account.Balance}");
            }
        }
    }
}
