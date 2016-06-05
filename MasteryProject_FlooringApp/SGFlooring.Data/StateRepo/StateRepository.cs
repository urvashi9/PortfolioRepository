using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Interfaces;
using SGFlooring.Models;

namespace SGFlooring.Data.StateRepo
{
    public class StateRepository : IStateRepository
    {
        private const string _filePath = @"DataFiles\States.txt";
        private const string filePathAllStates = @"DataFiles\FullStateList.txt";

        public List<State> GetAllStates()
        {
            List<State> results = new List<State>();

            var rows = File.ReadAllLines(_filePath);

            for (int i = 1; i < rows.Length; i++)
            {
                var columns = rows[i].Split(',');

                var state = new State(columns[0],columns[1],decimal.Parse(columns[2]));

                results.Add(state);
            }

            return results;
        }

        public State GetState(string stateAbbr)
        {
            List<State> states = GetAllStates();
            return states.FirstOrDefault(s => s.StateAbbr.ToUpper() == stateAbbr);
        }

        public List<State> GetFullStateList()
        {
            List<State> results = new List<State>();

            var rows = File.ReadAllLines(filePathAllStates);

            for (int i = 1; i < rows.Length; i++)
            {
                var columns = rows[i].Split(',');

                var state = new State(columns[0], columns[1], decimal.Parse(columns[2]));

                results.Add(state);
            }

            return results;
        }
        public State GetStateFromFullList(string stateName)
        {
            var allStates = GetFullStateList();
            return allStates.FirstOrDefault(s => s.StateAbbr.ToUpper() == stateName.ToUpper() || s.StateName.ToUpper() == stateName.ToUpper());
        }

        public void AddState(State state)
        {
            var StateToAdd = GetStateFromFullList(state.StateName);
            var states = GetAllStates();
            if (StateToAdd != null)
            {
                StateToAdd.StateName = state.StateName;
                StateToAdd.StateAbbr = state.StateAbbr;
                StateToAdd.TaxRate = state.TaxRate;
                states.Add(StateToAdd);
                OverwriteFile(states);
            }           
        }

        public void OverwriteFile(List<State> states)
        {           
            File.Delete(_filePath);

            using (var sr = File.CreateText(_filePath))
            {
                sr.WriteLine(
                    "StateAbbreviation, StateName, TaxRate");

                foreach (var state in states)
                {
                    sr.WriteLine(state.ToString());
                }
            }
        }
    }
}
