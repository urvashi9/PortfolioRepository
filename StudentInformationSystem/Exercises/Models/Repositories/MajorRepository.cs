using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercises.Models.Repositories
{
    public class MajorRepository
    {
        private List<Major> _majors;
        private string connectionString = ConfigurationManager.ConnectionStrings["SIS"].ConnectionString;
        public MajorRepository()
        {
            GetAll();
            // sample data
            //_majors = new List<Major>();        

            //using (SqlConnection cn = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "Select * from Major";
            //    cmd.Connection = cn;
            //    cn.Open();
            //    using (SqlDataReader dr = cmd.ExecuteReader())
            //    {
            //        while (dr.Read())
            //        {
            //            Major major = new Major();
            //            major.MajorId = dr.GetInt32(0);
            //            major.MajorName = dr.GetString(1);
            //            _majors.Add(major);
            //        }
            //    }
            //}

            //{
            //    new Major { MajorId=1, MajorName="Art" },
            //    new Major { MajorId=2, MajorName="Business" },
            //    new Major { MajorId=3, MajorName="Computer Science" }
            //};
        }

        public IEnumerable<Major> GetAll()
        {
            _majors = new List<Major>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Major";
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Major major = new Major();
                        major.MajorId = dr.GetInt32(0);
                        major.MajorName = dr.GetString(1);
                        _majors.Add(major);
                    }
                }
                return _majors;
            }
        }

        public Major Get(int majorId)
        {
            return _majors.FirstOrDefault(c => c.MajorId == majorId);
        }

        public void Add(string majorName)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertMajor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@MajorName", majorName);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            GetAll();
            //major.MajorId = _majors.Max(c => c.MajorId) + 1;
        }

        public void Edit(Major major)
        {            

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateMajor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@MajorName", major.MajorName);
                cmd.Parameters.AddWithValue("@MajorID", major.MajorId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            GetAll();
        }

        public void Delete(int majorId)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteMajor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
               
                cmd.Parameters.AddWithValue("@MajorID", majorId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            GetAll();
        }
    }
}