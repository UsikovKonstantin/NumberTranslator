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
        /// <summary>
        /// Перевод целой части числа из системы с основанием P в систему с основанием 10
        /// Пример: FromPto10Int("101", 2) => "5"
        /// </summary>
        /// <param name="number"> целая часть числа </param>
        /// <param name="P"> исходная система счисления </param>
        /// <returns> десятичное число </returns>
        public static string FromPto10Int(string number, int P)
        {
            int degree = 0;
            double result = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                result += CharToInt(number[i]) * (int)Math.Pow(P, degree);
                degree++;
            }

            return result.ToString();
        }


        /// <summary>
        /// Перевод дробной части числа из системы с основанием P в систему с основанием 10
        /// Пример: FromPto10Frac("0,101", 2) => "0,625"
        /// </summary>
        /// <param name="number"> дробная часть числа </param>
        /// <param name="P"> исходная система счисления </param>
        /// <returns> десятичное число </returns>
        public static string FromPto10Frac(string number, int P)
        {
            int degree = 0;
            double result = 0;

            for (int i = 0; i < number.Length; i++)
            {
                degree--;
                result += CharToInt(number[i]) * Math.Pow(P, degree);
            }
            string output = result.ToString().Remove(0, 2);
            return output;
        }


        /// <summary>
        /// Перевод целой части числа из системы с основанием 10 в систему с основанием Q
        /// Пример: From10toQInt("16", 2) => "10000"
        /// </summary>
        /// <param name="number"> целая часть числа </param>
        /// <param name="Q"> нужная система счисления </param>
        /// <returns> число в системе с основанием Q </returns>
        public static string From10toQInt(string number, int Q)
        {
            string result = "";
            long x = long.Parse(number);
            while (x > 0)
            {
                result = IntToChar(x % Q) + result;
                x /= Q;
            }

            return result;
        }


        /// <summary>
        /// Перевод дробной части числа из системы с основанием 10 в систему с основанием Q
        /// Пример: From10toQFrac("0,5", 2, 10) => "0,1"
        /// </summary>
        /// <param name="number"> дробная часть числа </param>
        /// <param name="Q"> нужная система счисления </param>
        /// <param name="accuracy"> знаков после запятой </param>
        /// <returns> число в системе с основанием Q </returns>
        public static string From10toQFrac(string number, int Q, int accuracy)
        {
            string result = "";
            double x = double.Parse("0."+number);
            int count = 0;

            while (x != Math.Truncate((double)x) && count < accuracy)
            {
                x *= Q;
                result += IntToChar((long)Math.Truncate((double)x));
                x -= (long)Math.Truncate((double)x);
                count++;
            }
            return result;
        }


        // Переводит символ в число
        public static long CharToInt(char c)
        {
            if (Char.IsDigit(c))
            {
                return int.Parse(c.ToString());
            }
            else
            {
                return (int)c - 55;
            }
        }


        // Переводит число в символ
        public static char IntToChar(long n)
        {
            if (n < 10)
            {
                return (char)(n + 48);
            }
            else
            {
                return (char)(n + 55);
            }
        }
    }
}
