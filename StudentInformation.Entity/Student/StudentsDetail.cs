using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace StudentInformation.Entity.Student
{
    public class StudentsDetail
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string student_first_name { get; set; }
        public string student_middle_name { get; set; }
        public string student_last_name { get; set; }
        public string student_address1 { get; set; }
        public string student_city { get; set; }
        public string student_country { get; set; }
        public string student_email { get; set; }
        public int student_graduation_year { get; set; }
        public string student_id { get; set; }
        public bool is_international_student { get; set; }
        public DateTime date_created { get; set; }
    }

}



