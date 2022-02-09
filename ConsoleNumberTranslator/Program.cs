using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryNumberTranslator;

namespace ConsoleNumberTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberTranslator.From10toQFrac("0,5", 2, 10));
        }
    }
}
