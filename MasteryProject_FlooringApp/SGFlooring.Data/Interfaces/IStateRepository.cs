using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Models;

namespace SGFlooring.Data.Interfaces
{
    public interface IStateRepository
    {
        void AddState(State state);
        State GetStateFromFullList(string stateName);
        List<State> GetFullStateList();
        List<State> GetAllStates();
        State GetState(string stateAbbr);
    }
}
