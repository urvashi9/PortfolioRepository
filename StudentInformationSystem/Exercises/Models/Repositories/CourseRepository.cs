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
    public class CourseRepository
    {
        private List<Course> _courses;
        private string connectionString = ConfigurationManager.ConnectionStrings["SIS"].ConnectionString;
        public CourseRepository()
        {
            GetAll();
        }

        public IEnumerable<Course> GetAll()
        {
            _courses = new List<Course>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Course";
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Course course = new Course();
                        course.CourseId = dr.GetInt32(0);
                        course.CourseName = dr.GetString(1);                       
                        _courses.Add(course);
                    }
                }
                return _courses;
            }
        }

        public Course Get(int courseId)
        {
            return _courses.FirstOrDefault(c => c.CourseId == courseId);
        }

        public void Add(string courseName)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertCourse";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@CourseName", courseName);               
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            GetAll();
        }

        public void Edit(Course course)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateCourse";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@CourseID", course.CourseId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            GetAll();
        }

        public void Delete(int courseId)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteCourse";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@CourseID", courseId);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            GetAll();
        }
    }
}