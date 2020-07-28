using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentInformation.Entity.Student;
using StudentInformation.BusinessLogic.Student;
using System.ComponentModel.DataAnnotations;
using Studentinformation.Utility;
namespace StudentInformation.Web.Models
{
    public class StudentModel
    {

        public IEnumerable<StudentsDetail> GetAllStudent()
        {
            List<StudentsDetail> studentsDetailList = new List<StudentsDetail>();
            StudentLogic studentLogicBL = new StudentLogic();
            return studentLogicBL.getStudentList();
        }
        public IEnumerable<StudentsDetail> GetStudentById(int id)
        {
            List<StudentsDetail> studentsDetailList = new List<StudentsDetail>();
            StudentLogic studentLogicBL = new StudentLogic();
            return studentLogicBL.GetStudentById(id);
        }

        public bool AddStudent(StudentModel sModel)
        {
            //TODO if user exist not insert
            StudentLogic studentLogicBL = new StudentLogic();
            StudentsDetail studentsDetailList = new StudentsDetail();
            studentsDetailList.UserName = sModel.UserName;
            //Encrypt Password
            var keyNew = EncryptUtility.GeneratePassword(10);
            var encryptPassword = EncryptUtility.EncodePassword(sModel.Password, keyNew);
            studentsDetailList.Password = encryptPassword;
            studentsDetailList.student_first_name = sModel.FirstName;
            studentsDetailList.student_last_name = sModel.LastName;
            studentsDetailList.student_middle_name = sModel.MiddleName;
            studentsDetailList.student_address1 = sModel.Address_Line1;
            studentsDetailList.student_city = sModel.City;
            studentsDetailList.student_country = sModel.Country;
            studentsDetailList.student_email = sModel.Email;
            studentsDetailList.student_graduation_year = sModel.GraduationYear;
            studentsDetailList.student_id = sModel.StudentId;
            studentsDetailList.is_international_student = sModel.isInternationStudent;
            studentsDetailList.date_created = DateTime.Now;
            return studentLogicBL.AddStudent(studentsDetailList);
            //return false;
        }

        public bool DeleteRegisteredStudent(int id)
        {
            StudentLogic studentLogicBL = new StudentLogic();
            return studentLogicBL.DeleteRegisteredStudent(id);
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, ErrorMessage = "Must be between 5 and 20 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address_Line1 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Range(5, 12)]
        public int GraduationYear { get; set; }

        public string StudentId { get; set; }

        public bool isInternationStudent { get; set; }

        public DateTime date_created { get; set; }

    }
}