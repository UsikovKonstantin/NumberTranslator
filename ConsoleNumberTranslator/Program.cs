using System;
using System.Diagnostics;
using ClassLibraryNumberTranslator;

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
            CharToLong_Test();
            LongToChar_Test();
            FromPtoQ_Test();
            Console.WriteLine("All tests passed.");
            Console.ReadLine();
        }

        static void FromPto10Int_Test()
        {
            Debug.Assert(NumberTranslator.FromPto10Int("101", 2) == "5");
            Debug.Assert(NumberTranslator.FromPto10Int("10", 2) == "2");
            Console.WriteLine("Tests for FromPto10Int passed.");
            
        }

        static void From10toQInt_Test()
        {
            Debug.Assert(NumberTranslator.From10toQInt("5", 2) == "101");
            Debug.Assert(NumberTranslator.From10toQInt("2", 2) == "10");
            Console.WriteLine("Tests for From10toQInt passed.");
        }

        static void FromPto10Frac_Test()
        {
            Debug.Assert(NumberTranslator.FromPto10Frac("1101", 2) == "0.8125");
            Debug.Assert(NumberTranslator.FromPto10Frac("53", 8) == "0.671875");
            Console.WriteLine("Tests for FromPto10Frac passed.");
        }

        static void From10toQFrac_Test()
        {
            Debug.Assert(NumberTranslator.From10toQFrac("0.8125", 2,10) == "1101");
            Debug.Assert(NumberTranslator.From10toQFrac("0.671875", 8,10) == "53");
            Console.WriteLine("Tests for From10toQFrac passed.");
        }

        static void CharToLong_Test()
        {
            Debug.Assert(NumberTranslator.CharToLong('F') == 15);
            Debug.Assert(NumberTranslator.CharToLong('f') == 15);
            Debug.Assert(NumberTranslator.CharToLong('Z') == 35);
            Debug.Assert(NumberTranslator.CharToLong('4') == 4);
            Console.WriteLine("Tests for CharToLong passed.");
        }

        static void LongToChar_Test()
        {
            Debug.Assert(NumberTranslator.LongToChar(15) == 'F');
            Debug.Assert(NumberTranslator.LongToChar(35) == 'Z');
            Debug.Assert(NumberTranslator.LongToChar(4) == '4');
            Console.WriteLine("Tests for LongToChar passed.");
        }

        static void FromPtoQ_Test()
        {
            Debug.Assert(NumberTranslator.FromPtoQ("A.F", 16, 2, 10) == "1010.1111");
            Debug.Assert(NumberTranslator.FromPtoQ("5.5", 10, 2, 10) == "101.1");
            Console.WriteLine("Tests for FromPtoQ passed.");
        }
    }
}