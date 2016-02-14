using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace LinqTutorialsConsoleApplication.Model
{
    public class Student
    {
        public string StudentName { get; set; }
        public string StudentId{ get; set; }
        public int StudentPhysicsMark{ get; set; }
        public int StudentMathsMark { get; set; }
        public int StudentAge { get; set; }
        public string StudentClass { get; set; }

        public Student(string studentName, string studentId, int studentPhysicsMark, int studentMathsMark, int studentAge, string studentClass)
        {
            StudentName = studentName;
            StudentId = studentId;
            StudentPhysicsMark = studentPhysicsMark;
            StudentMathsMark = studentMathsMark;
            StudentAge = studentAge;
            this.StudentClass = studentClass;
        }

        public static List<Student> GetStudentList()
        {
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student("sid", "3", 94, 100, 24, "3"));
            studentList.Add(new Student("pin", "12", 88, 88, 26, "4"));
            studentList.Add(new Student("rak", "22", 72, 68, 30, "5"));
            studentList.Add(new Student("dad", "19", 70, 100, 50, "3"));
            studentList.Add(new Student("mom", "5", 60, 50, 48,"6"));
            studentList.Add(new Student("sid", "1", 60, 50, 48,"3"));
            return studentList;
        }
    }
}
