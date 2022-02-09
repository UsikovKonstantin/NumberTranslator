using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryNumberTranslator
{
    /// <summary>
    /// Класс для перевода вещественных чисел из одной системы счисления в другую
    /// </summary>
    public class NumberTranslator
    {
        public static string[] Splitter (string To_Split)
        {
            string[] arr = new string[2];
            To_Split = To_Split.Split(".");
            return arr;
        }
        public static long FromTo10_Left (string In_Bx)
        {

        } 
        public static string From10To_Left (long In_B10)
        {

        } 
        public static double FromTo10_Right(string In_Bx)
        {

        }
        public static string From10To_Right (long In_B10)
        {

        } 
        public static string Merger (string A, string B)
        {
            return A + "." + B;
        }
    }
}
