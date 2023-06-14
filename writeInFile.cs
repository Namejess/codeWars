using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeWars
{
    public class writeInFile
    {
        public static void WriteInFile()
        {
            string path = @"C:\Users\josep\source\repos\codeWars\codeWars\bin\Debug\test.txt";
            string[] lines = { "First line", "Second line", "Third line" };
            System.IO.File.WriteAllLines(path, lines);
        }

        public static void ReadFile()
        {
            string path = @"C:\Users\josep\source\repos\codeWars\codeWars\bin\Debug\test.txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
