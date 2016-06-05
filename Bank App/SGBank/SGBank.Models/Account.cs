using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }

        public Account(int acctNum, string fName, string lName, decimal amount)
        {
            this.AccountNumber = acctNum;
            this.FirstName = fName;
            this.LastName = lName;
            this.Balance = amount;
        }

        public Account()
        {
            //empty constructor
        }
    }
}
