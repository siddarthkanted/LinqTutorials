using LinqTutorialsConsoleApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTutorialsConsoleApplication.Logic
{
    public class LearnLinq
    {
        List<Student> studentList = Student.GetStudentList();
        /// <summary>
        /// There are 2 types of queries. Method queries and Sql type queries.
        /// List, Set implement IEnumerable class.
        /// Linq is added as Extension methods in IEnumerable. So whoever implements IEnumerable will have Linq.
        /// </summary>
        public void typeOfQueries()
        {
            Console.WriteLine("=======lamda queries====");
            studentList.ForEach(s => Console.WriteLine(s.StudentName));

            Console.WriteLine("=======method queries====");
            Console.WriteLine(from student in studentList select student.StudentName);

        }

        /// <summary>
        /// concatenate all of the elements in the list.
        /// 1. concat element 1 and element 2. this produce result1.
        /// 2. concat result1 and element 3. this produce result2.
        /// 3. concat result3 and element 4. this produce result3.
        /// 4. continue the same way.
        /// Aggregate deals with joinning all the elements. Other Aggregate funtion supported in linq are sum, count, min, max, average.
        /// </summary>
        public void Aggregate()
        {
            //print sid,pin,rak
            string names = studentList.Select(s => s.StudentName).Aggregate((a, b) => a + "," + b);
            Console.WriteLine(names);
        }

        /// <summary>
        /// where is used as restriction operation. eleminate some elements form the list.
        /// where accepts a function with input T and returns boolean.
        /// where also accepts a function with input T and index, return boolean
        /// </summary>

        public void Restriction()
        {
            //print elements at even index in the list.
            List<Student> filteredStudentList = studentList.Where((s, i) => i % 2 == 0).ToList();
            filteredStudentList.ForEach(s => Console.WriteLine(s.StudentName));
        }

        /// <summary>
        /// Projections are select queries.
        /// Select in sql allows select columns from db.
        /// Select in linq allow select attributes from object.
        /// 2 types of select - select and selectMany
        /// consider class is class student { List<string> subjectList}
        /// select would return list<list<string>>
        /// select many would return list<string>
        /// They both are same, in case of selecting collection from object, select returns collection<collection>
        /// selectmany returns collection.
        /// </summary>
        public void Projections()
        {
            List<string> nameList = studentList.Select(s => s.StudentName).ToList();
            nameList.ForEach(x => Console.WriteLine(x));
        }

        /// <summary>
        /// Ordering is used for sort.
        /// OrderBy is primary sort. Thenby does secondary sort.
        /// consider list as {(a,2), (a,1), (c,1), (b,2)} => (name,id)
        /// orderby on name => {(a,2), (a,1), (b,2), (c,1)}
        /// thenby on id => {(a,1), (a,2), (b,2), (c,1)}
        /// thenby should be used after orderby.
        /// thenby sorts the values which are equal in orderby
        /// </summary>
        public void Ordering()
        {
            var result = studentList.OrderBy(x => x.StudentName).ThenBy(x => x.StudentId).Select(x => new { x.StudentName, x.StudentId }).ToList();
            result.ForEach(x => Console.WriteLine(x.StudentId+","+x.StudentName));
        }

        /// <summary>
        /// take n take the first n elements.
        /// skip n skip the first n elements.
        /// takewhile keep on taking till you find an element where the condition is false.
        /// skipwhile keep on skiping till you find an element where the condition is false.
        /// Partioning keeps flowing continuous.
        /// </summary>
        public void Partioning()
        {
            studentList.SkipWhile(x => x.StudentMathsMark == 100).ToList().ForEach(x => Console.WriteLine(x.StudentName));
        }
    }
}
