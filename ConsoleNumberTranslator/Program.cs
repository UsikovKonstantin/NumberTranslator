using System;
using ClassLibraryNumberTranslator;
using System.Diagnostics;

namespace ConsoleNumberTranslator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Test");
            FromPto10Int_Test();
            From10toQInt_Test();
            FromPto10Frac_Test();
            From10toQFrac_Test();
            Console.WriteLine("All tests passed.");
            Console.ReadLine();
        }
        static void FromPto10Int_Test()
        {
            Debug.Assert(NumberTranslator.FromPto10Int("101", 2) == "5");
            Debug.Assert(NumberTranslator.FromPto10Int("10", 2) == "2");
            Console.WriteLine($"Tests for FromPto10Int passed.");
            
        }
        static void From10toQInt_Test()
        {
            Debug.Assert(NumberTranslator.From10toQInt("5", 2) == "101");
            Debug.Assert(NumberTranslator.From10toQInt("2", 2) == "10");
            Console.WriteLine($"Tests for From10toQInt passed.");
        }
        static void FromPto10Frac_Test()
        {
            Debug.Assert(NumberTranslator.FromPto10Frac("1101", 2) == "8125");
            Debug.Assert(NumberTranslator.FromPto10Frac("53", 8) == "671875");
            Console.WriteLine($"Tests for FromPto10Frac passed.");
        }
        static void From10toQFrac_Test()
        {
            Debug.Assert(NumberTranslator.From10toQFrac("8125", 2,10) == "1101");
            Debug.Assert(NumberTranslator.From10toQFrac("671875", 8,10) == "53");
            Console.WriteLine($"Tests for From10toQFrac passed.");
        }
    }
}
