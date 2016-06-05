using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        [Test]
        public void CanLoadAllAccounts()
        {
            var repo = new AccountRepository();
            var accounts = repo.GetAllAccounts();

            Assert.AreEqual(4,accounts.Count);
        }

        [TestCase(1, "Mary")]
        [TestCase(2, "Bob")]
        public void CanLoadSpecificAccount(int accountNumber, string expected)
        {
            var repo = new AccountRepository();
            var account = repo.LoadAccount(accountNumber);

            Assert.AreEqual(expected, account.FirstName);
        }

        [Test]
        public void UpdateAccountSucceeds()
        {
            var repo = new AccountRepository();
            var accountToUpdate = repo.LoadAccount(1);
            accountToUpdate.Balance = 500.00m;
            repo.UpdateAccount(accountToUpdate);

            var result = repo.LoadAccount(1);
            Assert.AreEqual(500.00m, result.Balance);
        }

        [TestCase("Blast", "ThickNeck", 200.00)]
        [TestCase("Brock", "BeefChest", 500.00)]
        public void CreateAccountSucceeds(string fName, string lName, decimal amount)
        {
            var repo = new AccountRepository();
            var accountToCreate = new Account (0, fName, lName, amount);
            
            var results = repo.CreateAccount(accountToCreate);
            accountToCreate.AccountNumber = results;
            var comparisonAccount = repo.LoadAccount(results);

            Assert.AreEqual(accountToCreate.AccountNumber, comparisonAccount.AccountNumber);
            Assert.AreEqual(accountToCreate.FirstName, comparisonAccount.FirstName);
            Assert.AreEqual(accountToCreate.LastName, comparisonAccount.LastName);
            Assert.AreEqual(accountToCreate.Balance, comparisonAccount.Balance);
        }

        [TestCase(4)]
        [TestCase(2)]
        public void DeleteAccountSucceeds(int acctNum)
        {
            var repo = new AccountRepository();
            var accountToDelete = new Account();
            accountToDelete = repo.LoadAccount(acctNum);

            repo.DeleteAccount(acctNum);
            var comparisonAccount = repo.LoadAccount(acctNum);

            Assert.IsNull(comparisonAccount);
        }
    }
}
