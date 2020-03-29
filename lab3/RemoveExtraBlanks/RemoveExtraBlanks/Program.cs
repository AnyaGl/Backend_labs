using System;
using System.IO;
using System.Text;

namespace RemoveExtraBlanks
{
    public class RemoveExtraBlanksLib
    {
        public static string RemoveExtraBlanks(string line)
        {
            line  = line.Trim();
            string resultLine = "";
            bool foundFirstBlank = false;
            foreach (char ch in line)
            {
                if (ch == ' ' || ch == '\t')
                {
                    if (!foundFirstBlank)
                    {
                        resultLine += ch;
                        foundFirstBlank = true;
                    }
                }
                else
                {
                    resultLine += ch;
                    foundFirstBlank = false;
                }
            }
            return resultLine;
        }
    }
    public class Program
    {
        public static bool CopyFileWithRemoveExtraBlanks(string inputFileName, string outputFileName)
        {
            var srcEncoding = Encoding.UTF8;
            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Input file not found");
                return false;
            }
            using StreamReader input = new StreamReader(inputFileName, encoding: srcEncoding);
            try
            {
                using StreamWriter output = new StreamWriter(outputFileName, append: false, encoding: srcEncoding);
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    output.WriteLine(RemoveExtraBlanksLib.RemoveExtraBlanks(line));
                }
            }
            catch
            {
                Console.WriteLine("Invalid output file name");
                return false;
            }      
            return true;
        }
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid number of argumnets\n" +
                                  "Usage: RemoveExtraBlanks.exe <input file> <output file>");
                return 1;
            }
            string inputFileName = args[0];
            string outputFileName = args[1];

            if (!CopyFileWithRemoveExtraBlanks(inputFileName, outputFileName))
            {
                return 1;
            }

            return 0;
        }
    }
        
}
