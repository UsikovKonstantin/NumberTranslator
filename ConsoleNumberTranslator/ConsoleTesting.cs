using System;
using System.Diagnostics;
using ClassLibraryNumberTranslator;

namespace ConsoleNumberTranslator
{
    class ConsoleTesting
    {
        static void Main()
        {
            Console.WriteLine("Test");
            FromPto10Int_Test();
            From10toQInt_Test();
            FromPto10Frac_Test();
            From10toQFrac_Test();
            FromPtoQInt_Test();
            FromPtoQFrac_Test();
            FromCharToInt_Test();
            FromIntToChar_Test();
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
            Debug.Assert(NumberTranslator.FromPto10Frac("1101", 2) == "0,8125");
            Debug.Assert(NumberTranslator.FromPto10Frac("53", 8) == "0,671875");
            Console.WriteLine("Tests for FromPto10Frac passed.");
        }

        static void From10toQFrac_Test()
        {
            Debug.Assert(NumberTranslator.From10toQFrac("0,8125", 2,10) == "1101");
            Debug.Assert(NumberTranslator.From10toQFrac("0,671875", 8,10) == "53");
            Console.WriteLine("Tests for From10toQFrac passed.");
        }
        
        static void FromPtoQInt_Test()
        {
            Debug.Assert(NumberTranslator.FromPtoQInt("101001", 2, 16) == "29");
            Debug.Assert(NumberTranslator.FromPtoQInt("1101", 2, 16) == "D");
            Console.WriteLine("Tests for FromPtoQInt passed.");
        }

        static void FromPtoQFrac_Test()
        {
            Debug.Assert(NumberTranslator.FromPtoQFrac("321312", 10, 8, 6) == "244406");
            Debug.Assert(NumberTranslator.FromPtoQFrac("123214", 8, 6, 6) == "055044");
            Console.WriteLine("Tests for FromPtoQFrac passed.");
        }

        static void FromCharToInt_Test()
        {
            Debug.Assert(NumberTranslator.FromCharToInt('F') == 15);
            Debug.Assert(NumberTranslator.FromCharToInt('f') == 15);
            Debug.Assert(NumberTranslator.FromCharToInt('Z') == 35);
            Debug.Assert(NumberTranslator.FromCharToInt('4') == 4);
            Console.WriteLine("Tests for FromCharToInt passed.");
        }

        static void FromIntToChar_Test()
        {
            Debug.Assert(NumberTranslator.FromIntToChar(15) == 'F');
            Debug.Assert(NumberTranslator.FromIntToChar(35) == 'Z');
            Debug.Assert(NumberTranslator.FromIntToChar(4) == '4');
            Debug.Assert(NumberTranslator.FromIntToChar(19) == 'J');
            Console.WriteLine("Tests for FromIntToChar passed.");
        }

    }
}