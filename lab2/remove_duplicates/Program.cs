using System;
using System.Linq;

namespace remove_duplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string sourceStr = args[0];
                string resultStr = new string(sourceStr.Distinct().ToArray());
                Console.Write(resultStr);
            }
            else
            {
                Console.WriteLine("Incorrect number of arguments!\nUsage remove_duplicates.exe < input string >");
            }
        }
    }
}
