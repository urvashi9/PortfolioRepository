using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooring.Data.Factories;
using SGFlooring.Data.Interfaces;
using SGFlooring.Data.StateRepo;
using SGFlooring.Models;

namespace SGFlooring.BLL
{
    public class StateManager
    {
        private IStateRepository _repo;

        public StateManager()
        {
            _repo = StateRepositoryFactory.GetStateRepository();
        }

        private LogManager logManager = new LogManager();
        public List<State> GetAllStates()
        {
            return _repo.GetAllStates();
        }

        public Response<State> GetState(List<State> states, string Abbr)
        {
            var result = new Response<State>();
            result.Data = new State();
            try
            {
                var state = _repo.GetState(Abbr);

                if (state == null)
                {
                    result.Message = "We Do Not Service In The State Of " + Abbr +".";
                    result.Success = false;
                    logManager.ErrorLogs(DateTime.Now, result.Message);
                }
                else
                {
                    result.Success = true;
                    result.Data = state;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "There was an error. Please try again later.";
                logManager.ErrorLogs(DateTime.Now, result.Message);
            }
            return result;
        }

        public void AddState(string stateName)
        {
            var result = new Response<State>();
            result.Data = new State();
            var state = _repo.GetStateFromFullList(stateName);

            try
            {
                _repo.AddState(state);
            }
            catch (Exception)
            {
                result.Message = "The state you entered does not exist.";
                result.Success = false;
            }
        }     
    }
}
