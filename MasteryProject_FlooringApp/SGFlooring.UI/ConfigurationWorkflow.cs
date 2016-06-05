using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.UI.Utilities;

namespace SGFlooring.UI
{
    public class ConfigurationWorkflow
    {
        public void Execute()
        {
            ShowMenu();
        }

        public void ShowMenu()
        {
            string choice;
            bool b = false;
            do
            {
                Console.WriteLine("SG CORP FLOORING COMPANY");
                Console.WriteLine("\nWhat Mode Do You Want To Run Your Application In?");
                Console.WriteLine("\n1. Test(For testing and educational purposes)");
                Console.WriteLine("\n2. Prod(For production, default mode)");
                Console.WriteLine("\n(Q) to Quit");
                Console.WriteLine("\nEnter Choice: ");
                choice = UserUtilities.GetStringFromUser("\nPlease enter a choice: ");

                if (choice.ToUpper() == "Q")
                    break;
                else
                {
                    ProcessChoice(choice);
                    b = true;
                }            
            } while (!b);            
        }

        public void ProcessChoice(string str)
        {            
            switch (str)
            {
                case "1":
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["Mode"].Value = "Test";
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    break;
                default:
                    var config1 = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config1.AppSettings.Settings["Mode"].Value = "Prod";
                    config1.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    break;
            }
        }
    }
}
