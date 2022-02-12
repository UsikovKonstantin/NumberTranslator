using System;

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
            long result = 0;
            checked // По дефолту overflow игнорируется, checked позволяет считать это за exception
            {
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    result += CharToLong(number[i]) * (long)Math.Pow(P, degree);
                    degree++;
                }
            }
            return result.ToString();
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
            int degree = 0;
            double result = 0;
            for (int i = 0; i < number.Length; i++)
            {
                degree--;
                result += CharToLong(number[i]) * Math.Pow(P, degree);
            }
            return result.ToString();
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


        /// <summary>
        /// Перевод числа из системы с основанием P в систему с основанием Q
        /// Пример: FromPtoQ("A.F", 16, 2, 10) => "1010.1111"; FromPtoQ("5.5", 10, 2, 10) => "101.1"
        /// </summary>
        /// <param name="number"> число </param>
        /// <param name="P"> исходная система счисления </param>
        /// <param name="Q"> нужная система счисления </param>
        /// <param name="accuracy"> количество знаков после запятой </param>
        /// <returns> число в системе с основанием Q </returns>
        public static string FromPtoQ(string number, int P, int Q, int accuracy)
        {
            string[] input = number.Split('.', ',');
            string[] res = { "", "" };
            if (input[0][0] == '-') // Для отрицательных чисел 
            {
                input[0] = input[0].Remove(0, 1);
                res[0] += "-";
            }
            res[0] += From10toQInt(FromPto10Int(input[0], P), Q);

            if (input.Length == 2 && accuracy != 0 && double.Parse(FromPto10Frac(input[1], P)) != 0) // Когда есть нецелая часть (дробная)
            {
                res[1] = From10toQFrac(FromPto10Frac(input[1], P), Q, accuracy);
                if (res[1] == "")
                {
                    return $"{res[0]}.({LongToChar(Q - 1)})";
                }
                return $"{res[0]}.{res[1]}";
            }
            return $"{res[0]}";
        }
    }
}