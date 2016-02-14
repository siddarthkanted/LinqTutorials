using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqTutorialsConsoleApplication.Logic;

namespace LinqTutorialsConsoleApplication
{
    class Program
    {
        static void LearnLinq()
        {
            LearnLinq learnLinq = new LearnLinq();
            learnLinq.Grouping();
        }
        private static void LearnDelegates()
        {
            LearnDelegates learnDelegates = new LearnDelegates();
            learnDelegates.Print();
        }
        static void Main(string[] args)
        {
            //LearnDelegates();
            LearnLinq();
            Console.WriteLine("finished");
            Console.ReadKey();
        }
    }
}
