﻿using System;

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
            // По дефолту overflow игнорируется, checked позволяет считать это за exception
            checked
            {
                return GornerInt(number.ToCharArray(), P).ToString();
            }
        }


        /// <summary>
        /// Алгоритм Горнера
        /// </summary>
        /// <param name="coef"> массив коэффициентов </param>
        /// <param name="x"> заданное значение переменной </param>
        /// <returns> значение многочлена </returns>
        static long GornerInt(char[] coef, long x)
        {
            long result = CharToLong(coef[0]);
            checked
            {
                for (int i = 1; i < coef.Length; i++)
                {
                    result = result * x + CharToLong(coef[i]);
                }
            }
            return result;
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
            if (x == 0)
            {
                result = "0";
            }
            while (x > 0)
            {
                result = LongToChar(x % Q) + result;
                x /= Q;
            }
            return result;
        }


        /// <summary>
        /// Перевод дробной части числа из системы с основанием P в систему с основанием 10
        /// Пример: FromPto10Frac("101", 2) => "0,625"
        /// </summary>
        /// <param name="number"> дробная часть числа </param>
        /// <param name="P"> исходная система счисления </param>
        /// <returns> десятичное число </returns>
        public static string FromPto10Frac(string number, int P)
        {
            return GornerFrac(number.ToCharArray(), P).ToString();
        }


        /// <summary>
        /// Алгоритм Горнера для вещественной части
        /// </summary>
        /// <param name="coef"> массив коэффициентов </param>
        /// <param name="x"> заданное значение переменной </param>
        /// <returns> значение многочлена </returns>
        static double GornerFrac(char[] coef, long x)
        {
            Array.Reverse(coef);
            Array.Resize(ref coef, coef.Length + 1);
            coef[coef.Length - 1] = '0';

            double result = CharToLong(coef[0]);
            for (int i = 1; i < coef.Length; i++)
            {
                result = result / x + CharToLong(coef[i]);
            }
            return result;
        }


        /// <summary>
        /// Перевод дробной части числа из системы с основанием 10 в систему с основанием Q
        /// Пример: From10toQFrac("0,5", 2, 10) => "1"
        /// </summary>
        /// <param name="number"> дробная часть числа </param>
        /// <param name="Q"> нужная система счисления </param>
        /// <param name="accuracy"> знаков после запятой </param>
        /// <returns> дробная часть в системе с основанием Q </returns>
        public static string From10toQFrac(string number, int Q, int accuracy)
        {
            string result = "";
            double x = double.Parse(number);
            int count = 0;
            while (x != Math.Truncate(x) && count < accuracy)
            {
                x *= Q;
                result += LongToChar((long)Math.Truncate(x));
                x -= (long)Math.Truncate(x);
                count++;
            }
            return result;
        }


        /// <summary>
        /// Перевод символа в число
        /// Примеры: CharToLong('7') => 7; CharToLong('f') => 15; CharToLong('F') => 15
        /// </summary>
        /// <param name="c"> символ </param>
        /// <returns> число </returns>
        public static long CharToLong(char c)
        {
            return char.IsDigit(c) ? int.Parse(c.ToString()) : char.ToUpper(c) - 55;
        }


        /// <summary>
        /// Перевод числа в символ
        /// Примеры: LongToChar(7) => '7'; LongToChar(15) => 'F'
        /// </summary>
        /// <param name="n"> число </param>
        /// <returns> символ </returns>
        public static char LongToChar(long n)
        {
            return n < 10 ? (char)(n + 48) : (char)(n + 55);
        }



    }
}