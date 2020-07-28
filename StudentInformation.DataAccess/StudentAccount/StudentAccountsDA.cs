using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using StudentInformation.Entity.Student;

namespace StudentInformation.DataAccess.StudentAccount
{
    public class StudentAccountsDA  //: IStudentAccounts
    {
        //Get all student
        public IEnumerable<StudentsDetail> getStudentList()
        {
            List<StudentsDetail> studentsDetailList = new List<StudentsDetail>();
            string conStr = ConfigurationManager.ConnectionStrings["studentConn"].ToString();
            using (var connection = new SqlConnection(conStr))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_getAllStudents";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentsDetail studentDetail = new StudentsDetail();
                            studentDetail.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : Null.NullInt;
                            studentDetail.UserName = (reader["UserName"] != DBNull.Value) ? Convert.ToString(reader["UserName"]) : String.Empty;
                            studentDetail.Password = (reader["Password"] != DBNull.Value) ? Convert.ToString(reader["Password"]) : String.Empty;
                            studentDetail.student_first_name = (reader["student_first_name"] != DBNull.Value) ? Convert.ToString(reader["student_first_name"]) : String.Empty;
                            studentDetail.student_middle_name = (reader["student_middle_name"] != DBNull.Value) ? Convert.ToString(reader["student_middle_name"]) : String.Empty;
                            studentDetail.student_last_name = (reader["student_last_name"] != DBNull.Value) ? Convert.ToString(reader["student_last_name"]) : String.Empty;
                            studentDetail.student_address1 = (reader["student_address1"] != DBNull.Value) ? Convert.ToString(reader["student_address1"]) : String.Empty;
                            studentDetail.student_city = (reader["student_city"] != DBNull.Value) ? Convert.ToString(reader["student_city"]) : String.Empty;
                            studentDetail.student_country = (reader["student_country"] != DBNull.Value) ? Convert.ToString(reader["student_country"]) : String.Empty;
                            studentDetail.student_email = (reader["student_email"] != DBNull.Value) ? Convert.ToString(reader["student_email"]) : String.Empty;
                            studentDetail.student_graduation_year = (reader["student_graduation_year"] != DBNull.Value) ? Convert.ToInt32(reader["student_graduation_year"]) : Null.NullInt;
                            studentDetail.student_id = (reader["student_id"] != DBNull.Value) ? Convert.ToString(reader["student_id"]) : String.Empty;
                            studentDetail.is_international_student = (reader["is_international_student"] != DBNull.Value) ? Convert.ToBoolean(reader["is_international_student"]) : false;
                            studentDetail.date_created=(reader["date_created"] != DBNull.Value) ? Convert.ToDateTime(reader["date_created"]) : Null.NullDateTime;
                            studentsDetailList.Add(studentDetail);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return studentsDetailList;
        }
        //Get student detail by id
        public IEnumerable<StudentsDetail> GetStudentById(int id)
        {
            List<StudentsDetail> studentsDetailList = new List<StudentsDetail>();
            string conStr = ConfigurationManager.ConnectionStrings["studentConn"].ToString();
            using (var connection = new SqlConnection(conStr))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_getStudentById";
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value =id }).SqlDbType = SqlDbType.Int;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StudentsDetail studentDetail = new StudentsDetail();
                            studentDetail.Id = (reader["Id"] != DBNull.Value) ? Convert.ToInt32(reader["Id"]) : Null.NullInt;
                            studentDetail.UserName = (reader["UserName"] != DBNull.Value) ? Convert.ToString(reader["UserName"]) : String.Empty;
                            studentDetail.Password = (reader["Password"] != DBNull.Value) ? Convert.ToString(reader["Password"]) : String.Empty;
                            studentDetail.student_first_name = (reader["student_first_name"] != DBNull.Value) ? Convert.ToString(reader["student_first_name"]) : String.Empty;
                            studentDetail.student_middle_name = (reader["student_middle_name"] != DBNull.Value) ? Convert.ToString(reader["student_middle_name"]) : String.Empty;
                            studentDetail.student_last_name = (reader["student_last_name"] != DBNull.Value) ? Convert.ToString(reader["student_last_name"]) : String.Empty;
                            studentDetail.student_address1 = (reader["student_address1"] != DBNull.Value) ? Convert.ToString(reader["student_address1"]) : String.Empty;
                            studentDetail.student_city = (reader["student_city"] != DBNull.Value) ? Convert.ToString(reader["student_city"]) : String.Empty;
                            studentDetail.student_country = (reader["student_country"] != DBNull.Value) ? Convert.ToString(reader["student_country"]) : String.Empty;
                            studentDetail.student_email = (reader["student_email"] != DBNull.Value) ? Convert.ToString(reader["student_email"]) : String.Empty;
                            studentDetail.student_graduation_year = (reader["student_graduation_year"] != DBNull.Value) ? Convert.ToInt32(reader["student_graduation_year"]) : Null.NullInt;
                            studentDetail.student_id = (reader["student_id"] != DBNull.Value) ? Convert.ToString(reader["student_id"]) : String.Empty;
                            studentDetail.is_international_student = (reader["is_international_student"] != DBNull.Value) ? Convert.ToBoolean(reader["is_international_student"]) : false;
                            studentDetail.date_created = (reader["date_created"] != DBNull.Value) ? Convert.ToDateTime(reader["date_created"]) : Null.NullDateTime;
                            studentsDetailList.Add(studentDetail);
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return studentsDetailList;
        }
        //Add New Student
        public bool AddStudent(StudentsDetail studentsDetail)
        {
            int rowsAffected = 0;
            bool returnValue = false;
            string constring = ConfigurationManager.ConnectionStrings["studentConn"].ToString();
            using (var connection = new SqlConnection(constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_insertStudentData";
                    



                    command.Parameters.Add(new SqlParameter { ParameterName = "@UserName", Value = studentsDetail.UserName }).SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Password", Value = studentsDetail.Password }).SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@student_first_name", Value = studentsDetail.student_first_name }).SqlDbType = SqlDbType.VarChar;
                    var param = new SqlParameter { ParameterName = "@student_middle_name", Value = studentsDetail.student_middle_name ?? string.Empty };
                    command.Parameters.Add(param);
                    command.Parameters.Add(new SqlParameter { ParameterName = "@student_last_name", Value = studentsDetail.student_last_name }).SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@student_address1", Value = studentsDetail.student_address1 }).SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@student_city", Value = studentsDetail.student_city }).SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@student_country", Value = studentsDetail.student_country }).SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@student_email", Value = studentsDetail.student_email }).SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@student_graduation_year", Value = studentsDetail.student_graduation_year }).SqlDbType = SqlDbType.Int;
                    //command.Parameters.Add(new SqlParameter { ParameterName = "@student_id", Value = studentsDetail.student_id }).SqlDbType = SqlDbType.VarChar;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@is_international_student", Value = studentsDetail.is_international_student }).SqlDbType = SqlDbType.Bit;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@date_created", Value = studentsDetail.date_created });

                    connection.Open();
                    rowsAffected += command.ExecuteNonQuery();
                }
            }
            if (rowsAffected > 0)
                returnValue = true;
            return returnValue;
        }
        //Delete student
        public bool DeleteRegisteredStudent(int id)
        {
            string constring = ConfigurationManager.ConnectionStrings["studentConn"].ToString();
            int rowsAffected = 0;
            bool returnValue = false;
            using (var connection = new SqlConnection(constring))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_deleteStudentById";
                    command.Parameters.Add(new SqlParameter { ParameterName = "@id", Value = id }).SqlDbType = SqlDbType.Int;
                    connection.Open();
                    rowsAffected += command.ExecuteNonQuery();
                }
            }
            if (rowsAffected > 0)
                returnValue = true;
            return returnValue;
        }
    }
}
public abstract class Null
{
    public static int NullInt
    {
        get { return int.MinValue; }
    }
    public static DateTime NullDateTime
    {
        get { return DateTime.MinValue; }
    }
}