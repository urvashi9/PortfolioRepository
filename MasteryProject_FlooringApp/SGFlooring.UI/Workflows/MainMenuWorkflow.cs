using System;
using SGFlooring.UI.StateProductWorkflows;
using SGFlooring.UI.Utilities;

namespace SGFlooring.UI.Workflows
{
    public class MainMenuWorkflow
    {
        public void Execute()
        {
            
            string choice;
            do
            {
                // Main Menu Display
                Console.Clear();
                Console.WriteLine("SG Corp Flooring Company");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. View Single Order");
                Console.WriteLine("3. Add an Order");
                Console.WriteLine("4. Edit an Order");
                Console.WriteLine("5. Remove an Order");
                Console.WriteLine("6. Add a State");
                Console.WriteLine("(Q) Quit");

                choice = UserUtilities.GetStringFromUser("\nPlease enter a choice: ");

                if (choice.ToUpper() == "Q")
                    break;
                else
                    ProcessChoice(choice);
                Console.ReadKey();
            } while (true);
        }

        public void ProcessChoice(string choice)
        {
            // instantiating different workflows based on user input
            switch (choice)
            {
                case "1":
                    var displayWorkflow = new DisplayOrdersWorkflow();
                    displayWorkflow.Execute();
                    break;
                case "2":
                    var displaySingleWorkflow = new DisplaySingleOrderWorkflow();
                    displaySingleWorkflow.Execute();
                    break;
                case "3":
                    var addOrderWorkflow = new AddNewOrderWorkflow();
                    addOrderWorkflow.Execute();
                    break;
                case "4":
                    var updateOrderWorkflow = new UpdateOrderWorkflow();
                    updateOrderWorkflow.Execute();
                    break;
                case "5":
                    var removeOrderWorkflow = new RemoveOrderWorkflow();
                    removeOrderWorkflow.Execute();
                    break;
                case "6":
                    var addStateWorkflow = new AddStateWorkflow();
                    addStateWorkflow.Execute();
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice!");
                    break;
            }
        }
    }
}
