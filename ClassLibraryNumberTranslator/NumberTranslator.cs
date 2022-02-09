namespace ClassLibraryNumberTranslator
{
    /// <summary>
    /// Класс для перевода вещественных чисел из одной системы счисления в другую
    /// </summary>
    public class NumberTranslator
    {
        /// <summary>
        /// Splits the string
        /// </summary>
        /// <param name="To_Split">String to be split</param>
        /// <returns>Array of strings</returns>
        public static string[] Splitter(string To_Split)
        {
            string[] arr;
            arr = To_Split.Split('.');
            return arr;
        }
        public static long FromTo10_Left(string In_Bx)
        {
            return 0;
        }
        public static string From10To_Left(long In_B10)
        {
            return null;
        }
        public static double FromTo10_Right(string In_Bx)
        {
            return 0;
        }
        public static string From10To_Right(long In_B10)
        {
            return null;
        }
        /// <summary>
        /// Merges 2 strings and adds a dot in between
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static string Merger(string A, string B)
        {
            return A + "." + B;
        }
    }
}
