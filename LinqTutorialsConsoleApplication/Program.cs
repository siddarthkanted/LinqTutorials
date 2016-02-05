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
        private static void LearnDelegates()
        {
            LearnDelegates learnDelegates = new LearnDelegates();
            learnDelegates.Print();
        }
        static void Main(string[] args)
        {
            LearnDelegates();
            Console.WriteLine("finished");
            Console.ReadKey();
        }
    }
}
