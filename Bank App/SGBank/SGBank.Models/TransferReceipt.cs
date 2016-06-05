using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public class TransferReceipt
    {
        public int AccountNumber1 { get; set; }
        public int AccountNumber2 { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal NewBalanceInAccount1 { get; set; }
        public decimal NewBalanceInAccount2 { get; set; }
    }
}
