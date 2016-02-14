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
        /// 
        /// application is pagination. there are 4 pages display 3 students in each page.
        /// list.skip(pageNumber*3).take(3);
        /// pageNumber 0 => list.skip(0*3).take(3)
        /// pageNumber 1 => list.skip(1*3).take(3)
        /// </summary>
        public void Partioning()
        {
            studentList.SkipWhile(x => x.StudentMathsMark == 100).ToList().ForEach(x => Console.WriteLine(x.StudentName));
        }

        /// <summary>
        /// 1. ToList => convert the result to list.
        /// 2. ToArray =>
        /// 3. ToDictionary => if 1 argumeent. The argument is key and object is value. If 2 argument 1st argument key 2nd argument value.
        /// 4. ToLookup => same as dictionary. In dictionary the keys should be unique. In Look up keys need not be unique. Lookup is similary to adjacency list.
        /// 5. Cast => convert all the values in result to another data type. if any value does not get converted then throw exception.  
        /// 6. Type => same as cast. if any value does not get converted then dont throw exception instead ignore it.
        /// 7. IEnumerable=>
        /// 8. IQueryable=>
        /// 
        /// If you do studentDBIEnumerable.where(s.name.equals("sid")) then the sql query will be select * from studentDB.
        /// the matching with "sid" wont be done in db, it would be done in c#. so db has to pass all the records to c#.
        /// 
        /// In studentDBIQueryable.where(s.name.equals("sid")) sql query is select * from studentDB where name=="sid".
        /// the matching with "sid" is done in db. so db has to pass only records that match "sid" to c#.
        /// 
        /// For performance, whenever dealing with db use IQueryable as it will pass less records from db to c#.
        /// </summary>
        public void Conversion()
        {
            Lookup<string, Student> lookup = (Lookup<string,Student>)studentList.ToLookup(x => x.StudentName, x=>x);
            lookup["sid"].ToList().ForEach(x => Console.WriteLine(x.StudentId));
        }

        /// <summary>
        /// question => Find the count of students studying in IT Department
        /// answer => group studentList on department=="it" then do a count on it.
        /// </summary>
        public void Grouping()
        {
            //group by single key
            List<IGrouping<string, Student>> group = studentList.GroupBy(x => x.StudentClass).ToList();
            group.ForEach(x => Console.WriteLine(x.Key + ".." +x.ToList().Select(a=>a.StudentName).Aggregate((a,b) => agg(a,b))));

            //group by multiple key
            var mulgroup = studentList.GroupBy(x => new { x.StudentClass, x.StudentName }).ToList();
            mulgroup.ForEach(x => Console.WriteLine(x.Key + ".." + x.ToList().Select(a => a.StudentName).Aggregate((a, b) => agg(a, b))));

        }

        public string agg(string a, string b)
        {
            return a + ".." + b;
        }

        /// <summary>
        ///  A={(1,A), (2,B), (3,C)} P={(1,P), (2,Q), (4,R)}
        ///  inner join {(1,A,P), (2,B,Q)}
        ///  left outer {(1,A,P), (2,B,Q), (3,C, NULL)}
        ///  right outer {(1,A,P), (2,B,Q), (4,NULL,R)}
        ///  full outer {(1,A,P), (2,B,Q), (3,C, NULL), (4,NULL,R)}
        ///  cartesian or cross over {(1,A,P),(1,A,Q),(1,A,R) 
        ///                           (2,B,P),(2,B,Q),(2,B,R)
        ///                           (3,C,P), (3,C,Q),(3,C,R)}
        /// </summary>
        public void joins()
        {
            List<Tuple<int, string>> AList = new List<Tuple<int, string>>
            {
                new Tuple<int, string>(1,"A"),
                new Tuple<int, string>(2,"B"),
                new Tuple<int, string>(3,"C"),
            };

            List<Tuple<int, string>> PList = new List<Tuple<int, string>>
            {
                new Tuple<int, string>(1,"P"),
                new Tuple<int, string>(2,"Q"),
                new Tuple<int, string>(4,"R"),
            };

            
            Console.WriteLine("==========inner join=====");
            Enumerable.Join(PList, AList, b => b.Item1, a => a.Item1, (b, a) => new Tuple<int, string, int, string>(a.Item1, a.Item2, b.Item1, b.Item2)).ToList().ForEach(x=>Console.WriteLine(x.Item1+".."+x.Item2+".."+x.Item3+".."+x.Item4));

            Console.WriteLine("==========cartesian =====");
            Enumerable.Join(PList, AList, b => true, a => true, (b, a) => new Tuple<int, string, int, string>(a.Item1, a.Item2, b.Item1, b.Item2)).ToList().ForEach(x => Console.WriteLine(x.Item1 + ".." + x.Item2 + ".." + x.Item3 + ".." + x.Item4));

            //if the outer is PList then it becomes right outer join
            //if the outer is AList then it becomes left outer join
            Console.WriteLine("==========outer join =====");
            Enumerable.GroupJoin(AList, PList, b => b.Item1, a => a.Item1, (b, a) => new Tuple<string, int, string>(String.Join(String.Empty, a.ToList().Select(x => x.Item2)), b.Item1, b.Item2)).ToList().ForEach(x => Console.WriteLine(x.Item1 + ".." + x.Item2 + ".." + x.Item3 + ".."));
        }
    }
}
