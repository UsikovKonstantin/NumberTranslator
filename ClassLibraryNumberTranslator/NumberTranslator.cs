using System;

namespace ClassLibraryNumberTranslator
{
    /// <summary>
    /// Класс для перевода вещественных чисел из одной системы счисления в другую
    /// </summary>
    public class NumberTranslator
    {
        static string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
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
            long result = FromCharToInt(coef[0]);
            checked
            {
                for (int i = 1; i < coef.Length; i++)
                {
                    result = result * x + FromCharToInt(coef[i]);
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
                result = FromIntToChar((int)(x % Q)) + result;
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

            double result = FromCharToInt(coef[0]);
            for (int i = 1; i < coef.Length; i++)
            {
                result = result / x + FromCharToInt(coef[i]);
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
                result += FromIntToChar((int)Math.Truncate(x));
                x -= (long)Math.Truncate(x);
                count++;
            }
            return result;
        }


        /// <summary>
        /// Перевод символа в число
        /// Примеры: 
        /// </summary>
        /// <param name="c"> символ </param>
        /// <returns> число </returns>
        public static int FromCharToInt (char c)
        {
            return digits.IndexOf(char.ToUpper(c));
        }
        


        /// <summary>
        /// Перевод числа в символ
        /// Примеры:
        /// </summary>
        /// <param name="n"> число </param>
        /// <returns> символ </returns>
        public static char FromIntToChar (int n)
        {
            return digits[n];
        }
       

        /// <summary>
        /// Перевод целой части числа
        /// </summary>
        /// <param name="number"> целая часть </param>
        /// <param name="P"> исходное основание </param>
        /// <param name="Q"> нужное основание </param>
        /// <returns> переведённая целая часть </returns>
        public static string FromPtoQInt(string number, int P, int Q)
        {
            return From10toQInt(FromPto10Int(number, P), Q);
        }

        /// <summary>
        /// Перевод дробной части числа
        /// </summary>
        /// <param name="number"> дробная часть </param>
        /// <param name="P"> исходное основание </param>
        /// <param name="Q"> нужное основание </param>
        /// <param name="acc"> количество знаков после запятой </param>
        /// <returns> переведённая дробная часть </returns>
        public static string FromPtoQFrac(string number, int P, int Q, int acc)
        {
            return From10toQFrac(FromPto10Frac(number, P), Q, acc);
        }
    }
}