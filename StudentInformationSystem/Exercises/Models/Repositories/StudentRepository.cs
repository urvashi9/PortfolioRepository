using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace Exercises.Models.Repositories
{
    public class StudentRepository
    {
        private List<Student> _students;
        private string connectionString = ConfigurationManager.ConnectionStrings["SIS"].ConnectionString;

        public StudentRepository()
        {
            GetAll();
        }

        public IEnumerable<Student> GetAll()
        {
            _students = new List<Student>();

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Student";
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Student student = new Student();
                        student.StudentId = dr.GetInt32(0);
                        student.FirstName = dr.GetString(1);
                        student.LastName = dr.GetString(2);
                        student.GPA = dr.GetDecimal(3);
                        if (!dr.IsDBNull(4))
                            student.Address = GetAdress(dr.GetInt32(4));                      
                        var repo = new MajorRepository();
                        student.Major = repo.Get(dr.GetInt32(5));

                        using (SqlConnection cnCourse = new SqlConnection(connectionString))
                        {
                            SqlCommand cmdStudentCourse = new SqlCommand();
                            cmdStudentCourse.CommandText = "GetCourseByStudentID";
                            cmdStudentCourse.CommandType = CommandType.StoredProcedure;
                            cmdStudentCourse.Connection = cnCourse;
                            cnCourse.Open();
                            cmdStudentCourse.Parameters.AddWithValue("@StudentID", student.StudentId);
                            using (SqlDataReader courseReader = cmdStudentCourse.ExecuteReader())
                            {
                                student.Courses = new List<Course>();
                                while (courseReader.Read())
                                {
                                    var course = new Course();
                                    course.CourseId = courseReader.GetInt32(0);
                                    course.CourseName = courseReader.GetString(1);
                                    student.Courses.Add(course);
                                }
                            }
                        }
                            
                            _students.Add(student);
                    }
                }
                return _students;
            }
        }

        private Address GetAdress(int AddressID)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Address Where AddressID =" + AddressID.ToString();
                cmd.Connection = cn;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Address address = new Address();
                        address.AddressId = dr.GetInt32(0);
                        address.Street1 = dr.GetString(1);
                        if (!dr.IsDBNull(2))
                            address.Street2 = dr.GetString(2);                     
                        address.City = dr.GetString(3);
                        var stateRepo = new StateRepository();
                        address.State = stateRepo.Get(dr.GetInt32(4));
                        address.PostalCode = dr.GetString(5);

                        return address;
                    }
                }
                return null;
            }
        }

        public Student Get(int studentId)
        {
            return _students.FirstOrDefault(s => s.StudentId == studentId);
        }

        public void Add(Student student)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@GPA", student.GPA);
                cmd.Parameters.AddWithValue("@MajorID", student.Major.MajorId);

                cn.Open();
                student.StudentId = (int)cmd.ExecuteScalar();
                

                foreach (var course in student.Courses)
                {
                    SqlCommand cmdStudentCourse = new SqlCommand();
                    cmdStudentCourse.CommandText = "InsertStudentCourse";
                    cmdStudentCourse.CommandType = CommandType.StoredProcedure;
                    cmdStudentCourse.Connection = cn;
                    cmdStudentCourse.Parameters.AddWithValue("@StudentID", student.StudentId);
                    cmdStudentCourse.Parameters.AddWithValue("@CourseID", course.CourseId);
                    cmdStudentCourse.ExecuteNonQuery();
                }
            }
            GetAll();
        }

        public void Edit(Student student)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@GPA", student.GPA);
                cmd.Parameters.AddWithValue("@MajorID", student.Major.MajorId);
                if (student.Address != null)
                    cmd.Parameters.AddWithValue("@AddressID", student.Address.AddressId);
                else
                    cmd.Parameters.AddWithValue("@AddressID", DBNull.Value);

                cn.Open();
                cmd.ExecuteNonQuery();
                SqlCommand cmdDeleteStudentCourse = new SqlCommand();
                cmdDeleteStudentCourse.CommandText = "DeleteStudentCourseByStudentID";
                cmdDeleteStudentCourse.CommandType = CommandType.StoredProcedure;
                cmdDeleteStudentCourse.Connection = cn;
                cmdDeleteStudentCourse.Parameters.AddWithValue("@StudentID", student.StudentId);
                cmdDeleteStudentCourse.ExecuteNonQuery();


                foreach (var course in student.Courses)
                {
                    SqlCommand cmdStudentCourse = new SqlCommand();
                    cmdStudentCourse.CommandText = "InsertStudentCourse";
                    cmdStudentCourse.CommandType = CommandType.StoredProcedure;
                    cmdStudentCourse.Connection = cn;
                    cmdStudentCourse.Parameters.AddWithValue("@StudentID", student.StudentId);
                    cmdStudentCourse.Parameters.AddWithValue("@CourseID", course.CourseId);
                    cmdStudentCourse.ExecuteNonQuery();
                }
            }
            GetAll();
        }

        public void EditAddress(Student student)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                var stateRepo = new StateRepository();
                student.Address.State = stateRepo.Get(student.Address.State.StateAbbreviation);
                SqlCommand cmd = new SqlCommand();
                if (student.Address.AddressId == 0)
                    cmd.CommandText = "AddAddress";
                else
                {
                    cmd.CommandText = "UpdateAddress";
                    cmd.Parameters.AddWithValue("@AddressID", student.Address.AddressId);
                }
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;
           
                cmd.Parameters.AddWithValue("@Street1", student.Address.Street1);
                if (student.Address.Street2 != null)
                    cmd.Parameters.AddWithValue("@Street2", student.Address.Street2);
                else
                    cmd.Parameters.AddWithValue("@Street2", DBNull.Value);
                cmd.Parameters.AddWithValue("@City", student.Address.City);
                cmd.Parameters.AddWithValue("@StateID", student.Address.State.StateId);
                cmd.Parameters.AddWithValue("@PostalCode", student.Address.PostalCode);

                cn.Open();
                if (cmd.CommandText != "AddAddress")              
                    cmd.ExecuteNonQuery();               
                else
                {
                    student.Address.AddressId = (int)cmd.ExecuteScalar();
                    SqlCommand cmdStudentAddress = new SqlCommand();
                    cmdStudentAddress.CommandText = "UpdateAddressForStudent";
                    cmdStudentAddress.CommandType = CommandType.StoredProcedure;
                    cmdStudentAddress.Connection = cn;
                    cmdStudentAddress.Parameters.AddWithValue("@StudentID", student.StudentId);
                    cmdStudentAddress.Parameters.AddWithValue("@AddressID", student.Address.AddressId);
                    cmdStudentAddress.ExecuteNonQuery();
                }
            }
            GetAll();
        }

        public void Delete(int studentId)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteStudent";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@StudentID", studentId);
                var student = Get(studentId);
                cn.Open();                
                cmd.ExecuteNonQuery();
                if (student.Address != null)
                {
                    SqlCommand cmdDelete = new SqlCommand();

                    cmdDelete.CommandText = "DeleteAddress";
                    cmdDelete.CommandType = CommandType.StoredProcedure;
                    cmdDelete.Parameters.AddWithValue("@AddressID", student.Address.AddressId);
                    cmdDelete.Connection = cn;
                    cmdDelete.ExecuteNonQuery();
                }                              
            }
            GetAll();
        }
    }
}