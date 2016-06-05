using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.UI.Workflows;

namespace SGFlooring.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationWorkflow configWorkflow = new ConfigurationWorkflow();
            configWorkflow.Execute();
            MainMenuWorkflow mainMenu = new MainMenuWorkflow();
            mainMenu.Execute();
        }
    }
}