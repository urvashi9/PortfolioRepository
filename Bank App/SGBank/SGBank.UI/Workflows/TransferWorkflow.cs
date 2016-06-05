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
    public class TransferWorkflow
    {
        public void Execute(Account myAccount, Account yourAccount)
        {
            decimal amount = UserPrompts.GetDecimalFromUser("Please provide a transfer amount:");

            var manager = new AccountManager();
            var response = manager.Transfer(amount, myAccount, yourAccount);

            if (response.Success)
            {
                AccountScreens.TransferDetails(response.Data);
            }
            else
            {
                AccountScreens.WorkflowErrorScreen(response.Message);
            }
        }
    }
}
