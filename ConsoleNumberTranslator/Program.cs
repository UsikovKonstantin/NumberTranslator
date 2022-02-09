﻿using System;
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
        }
        static void FromPto10Int_Test()
        {
            Debug.Assert(NumberTranslator.FromPto10Int("101", 2) == "5");
            Debug.Assert(NumberTranslator.FromPto10Int("10", 2) == "2");
        }
        static void From10toQInt_Test()
        {
            Debug.Assert(NumberTranslator.From10toQInt("5", 2) == "101");
            Debug.Assert(NumberTranslator.From10toQInt("2", 2) == "10");
        }
    }
}
