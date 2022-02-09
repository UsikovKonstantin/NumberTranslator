using ClassLibraryNumberTranslator;
using System.Diagnostics;

namespace ConsoleNumberTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test");
            Splitter_Test();
            Merger_Test();
        }
        static void Splitter_Test()
        {
            { 
                string[] arr1, arr2;
                arr1 = NumberTranslator.Splitter("125.74");
                arr2 = new string[] { "125", "74" };
                Debug.Assert(arr1[0] == arr2[0] && arr1[1] == arr2[1]);
            }
            {
                string[] arr1, arr2;
                arr1 = NumberTranslator.Splitter("125,74");
                arr2 = new string[] { "125", "74" };
                Debug.Assert(arr1[0] == arr2[0] && arr1[1] == arr2[1]);
            }
        }
        static void Merger_Test()
        {
            string[] arr = new string[] { "547", "214" };
            string str = NumberTranslator.Merger(arr[0], arr[1]);
            Debug.Assert(str == "547.214");
        }
    }
}
