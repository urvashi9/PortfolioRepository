using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Exercises.Models.Repositories
{
    public static class InsertData
    {
        public static void InsertDataIntoDatabase()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["SIS"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmdCheck = new SqlCommand();
                cmdCheck.CommandText = "Select count(MajorID) from Major";
                cmdCheck.Connection = cn;
                cn.Open();
                if ((int)cmdCheck.ExecuteScalar() == 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "Insert into Major(MajorName) values ('Art'),('Business'),('Computer Science')";
                    cmd.ExecuteNonQuery();
                }

                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "Select count(MajorID) from Major;" +
                //                  "Insert into Major(MajorName) values ('Art'),('Business'),('Computer Science');";
                //cmd.Connection = cn;
                //cn.Open();
                //if ((int)cmd.ExecuteScalar() == 0)
                //    cmd.ExecuteNonQuery();

                cmdCheck.CommandText = "Select count(StateID) from State";
                if ((int)cmdCheck.ExecuteScalar() == 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Insert into State(StateName,StateAbbreviation) values ('Kentucky','KY'),('Minnesota','MN'),('Ohio','OH')";
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }

                cmdCheck.CommandText = "Select count(CourseID) from Course";
                if ((int)cmdCheck.ExecuteScalar() == 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Insert into Course(CourseName) values ('Art History'),('Accounting 101'),('Biology 101'),('Business Law'),('C# Fundamentals'),('Economics 101'),('Java Fundamentals'),('Photography')";
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }

                cmdCheck.CommandText = "Select count(AddressID) from Address";
                if ((int)cmdCheck.ExecuteScalar() == 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Insert into Address(Street1,Street2,City,StateID,PostalCode) values ('123 Main Street',null,'Akron',3,'44311'),('422 Oak Street','Apartment 305 A','Mineapolis',2,'55401')";
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }

                cmdCheck.CommandText = "Select count(StudentID) from Student";
                if ((int)cmdCheck.ExecuteScalar() == 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Insert into Student(FirstName,LastName,GPA,AddressID,MajorID) values ('John','Doe',2.50,1,1),('Jane','Wicks',3.50,2,2)";
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }

                cmdCheck.CommandText = "Select count(StudentID) from StudentCourse";
                if ((int)cmdCheck.ExecuteScalar() == 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Insert into StudentCourse(StudentID,CourseID) values (1,1),(1,8),(2,2),(2,4),(2,6)";
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}