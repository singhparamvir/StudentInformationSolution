using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformation.DataAccess.StudentAccount;
using StudentInformation.Entity.Student;

namespace StudentInformation.BusinessLogic.Student
{
   public class StudentLogic
    {
        StudentAccountsDA studentAccountsDA = new StudentAccountsDA();

        public IEnumerable<StudentsDetail> getStudentList()
        {
           return studentAccountsDA.getStudentList();
        }
        public IEnumerable<StudentsDetail> GetStudentById(int id)
        {
            return studentAccountsDA.GetStudentById(id);
        }
        public bool AddStudent(StudentsDetail studentsDetail)
        {
           bool returnVal= studentAccountsDA.AddStudent(studentsDetail);
           return returnVal;
        }
        public bool DeleteRegisteredStudent(int id)
        {
            bool returnVal = studentAccountsDA.DeleteRegisteredStudent(id);
            return returnVal;
        }
        
    }
}
