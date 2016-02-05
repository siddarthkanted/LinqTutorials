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

        public Student(string studentName, string studentId, int studentPhysicsMark, int studentMathsMark, int studentAge)
        {
            StudentName = studentName;
            StudentId = studentId;
            StudentPhysicsMark = studentPhysicsMark;
            StudentMathsMark = studentMathsMark;
            StudentAge = studentAge;
        }
    }
}
