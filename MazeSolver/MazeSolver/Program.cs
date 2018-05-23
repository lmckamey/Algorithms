using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    class Program
    {
        public class Node
        {
            public string name;
            public List<Node> neighbors;
        }


        static string[] rawFileStrings;


        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            ParseFileData();

            foreach (var item in rawFileStrings)
            {
                Console.WriteLine(item);
            }
        }

        static bool ParseFileData()
        {
            string path = "";
            while (path == null || path == "")
            {
                path = PromptForString("Please Enter a file Path");
            }
            rawFileStrings = File.ReadAllLines(path);
            for (int i = 0; i < rawFileStrings.Length; i++)
            {
                if (rawFileStrings[i] != "")
                    if (rawFileStrings[i][0] == '/')
                        rawFileStrings[i] = "";
            }
            return (rawFileStrings != null);
        }

        static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }
}
