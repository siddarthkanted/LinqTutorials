using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqTutorialsConsoleApplication.Model;

namespace LinqTutorialsConsoleApplication.Logic
{
    /*
     * An object can be passed as argument to a function. Provided the datatype mentioned in the argument is same as the datatype of object.
     * 
     * In delegates, you can pass function as argument. Provided the datatype mentioned in the argument is same as the datatype of function.
     * 
     * Datatype of a function is its return type and its arguments.
     * 
     */
    public class LearnDelegates
    {

        private delegate bool StudentBoolDelegate(Student student);

        private void PrintStudents(Student[] students, StudentBoolDelegate studentBoolDelegate)
        {
            foreach (var student in students)
            {
                if (studentBoolDelegate(student))
                {
                    Console.WriteLine(student.StudentName);
                }
            }
        }

        public void Print()
        {
            Student[] students = new Student[]
            {
                new Student("sid", "s1", 100, 100,23, "3"),
                  new Student("pin", "p1", 99, 99,25, "4"),
                    new Student("rak", "r1", 98, 100,29, "5")
            };

            Console.WriteLine("====student who scored 100 in math========");
            //print students who scored 100 in math
            StudentBoolDelegate studentBoolDelegate = delegate(Student student) { return student.StudentMathsMark == 100; };
            PrintStudents(students, studentBoolDelegate);

            Console.WriteLine("====student who scored 100 in physics========");
            //print students who scored 100 in physics
            studentBoolDelegate = delegate(Student student) { return student.StudentPhysicsMark == 100; };
            PrintStudents(students, studentBoolDelegate);

        }
    }
}
