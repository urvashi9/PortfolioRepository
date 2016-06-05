using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;
using SGFlooring.Data.OrderRepo;
using SGFlooring.Data.StateRepo;

namespace SGFlooring.Data.Factories
{
    public class StateRepositoryFactory
    {
        public static IStateRepository GetStateRepository()
        {
            var mode = ConfigurationManager.AppSettings["Mode"];
            switch (mode)
            {
                case "Test":
                    return new MockStateRepository();
                default:
                    return new StateRepository();
            }
        }
    }
}
