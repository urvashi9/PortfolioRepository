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
    public class DeleteAccountWorkflow
    {
        public void Execute()
        {
            int accountNumber =
                UserPrompts.GetIntFromUser("Please enter the account number for the account you want to delete: ");

           var manager = new AccountManager();
            manager.RemoveAccount(accountNumber);
            UserPrompts.PressKeyForContinue();
        }

    }

        
    }

