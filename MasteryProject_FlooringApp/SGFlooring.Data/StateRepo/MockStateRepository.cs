using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;
using SGFlooring.Models;

namespace SGFlooring.Data.StateRepo
{
    public class MockStateRepository : IStateRepository
    {
        private List<State> states;

        public MockStateRepository()
        {
            states = new List<State>();

            if (states.Count == 0)
            {
                states = new List<State>()
                {
                    new State() {StateAbbr = "AZ", StateName = "Arizona", TaxRate = 5.6m},
                    new State() {StateAbbr = "CA", StateName = "California", TaxRate = 7.5m},
                    new State() {StateAbbr = "TX", StateName = "Texas", TaxRate = 6.25m},
                    new State() {StateAbbr = "FL", StateName = "Florida", TaxRate = 6.00m},
                    new State() {StateAbbr = "MI", StateName = "Michigan", TaxRate = 6.00m},
                    new State() {StateAbbr = "NY", StateName = "New York", TaxRate = 4.00m},
                    new State() {StateAbbr = "IL", StateName = "Illinois", TaxRate = 6.25m},
                    new State() {StateAbbr = "OH", StateName = "Ohio", TaxRate = 5.75m},
                    new State() {StateAbbr = "NV", StateName = "Nevada", TaxRate = 6.85m},
                    new State() {StateAbbr = "WA", StateName = "Washington", TaxRate = 6.5m}
                };
            }
        }

        public void AddState(State state)
        {
            throw new NotImplementedException();
        }

        public State GetStateFromFullList(string stateName)
        {
            throw new NotImplementedException();
        }

        public List<State> GetFullStateList()
        {
            throw new NotImplementedException();
        }

        public List<State> GetAllStates()
        {
            return states;
        }

        public State GetState(string stateAbbr)
        {
            return states.FirstOrDefault(s => s.StateAbbr.ToUpper() == stateAbbr);
        }
    }
}
