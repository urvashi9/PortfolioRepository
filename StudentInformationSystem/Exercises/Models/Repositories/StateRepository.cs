using Exercises.Models.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Data;

namespace Exercises.Models.Repositories
{
    public class StateRepository
    {
        private List<State> _states;
        private string connectionString = ConfigurationManager.ConnectionStrings["SIS"].ConnectionString;
        public StateRepository()
        {
            GetAll();          
        }

        public IEnumerable<State> GetAll()
        {
            _states = new List<State>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from State";
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State state = new State();
                        state.StateId = dr.GetInt32(0);
                        state.StateAbbreviation = dr.GetString(1);
                        state.StateName = dr.GetString(2);
                        _states.Add(state);
                    }
                }
                return _states;
            }
        }

        public State Get(int stateId)
        {
            return _states.FirstOrDefault(c => c.StateId == stateId);
        }

        public State Get(string stateAbbr)
        {
            return _states.FirstOrDefault(c => c.StateAbbreviation == stateAbbr);
        }

        public void Add(State state)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertState";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@StateName", state.StateName);
                cmd.Parameters.AddWithValue("@StateAbbr", state.StateAbbreviation);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            GetAll();
        }

        public void Edit(State state)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateState";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@StateName", state.StateName);
                cmd.Parameters.AddWithValue("@StateAbbr", state.StateAbbreviation);
                cmd.Parameters.AddWithValue("@StateID", state.StateId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            GetAll();
        }

        public void Delete(int stateId)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteState";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@StateID", stateId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            GetAll();
        }
    }
}