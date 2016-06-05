using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.BLL;
using SGFlooring.UI.Utilities;

namespace SGFlooring.UI.StateProductWorkflows
{
    public class AddStateWorkflow
    {
        public void Execute()
        {
            do
            {
                string newState = UserUtilities.GetStringFromUser("Enter the abbreviation of the state you want to add: ");
                string input = UserUtilities.GetStringFromUser("Are you sure you want to add this state? (Y/N): ");
                if (input.ToUpper() == "Y")
                {
                    var manager = new StateManager();
                    manager.AddState(newState);
                }
                string back = UserUtilities.GetStringFromUser("Press B to go back to main menu!");
                if (back.ToUpper() == "B")
                    break;
            } while (true);
            
                
            
        }
    }
}
