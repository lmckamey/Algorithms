using System;
using System.IO;
using System.Linq

namespace KnapsackProblem
{

    struct knapsackItem
    {
        public string name;
        public int weight;
        public int value;
    }

    class Program
    {
        static void Main(string[] args)
        {

        }

        static void Run()
        {

        }

        static void OpenFile(string path)
        {
            string[] lines = File.ReadLines(path).ToArray();
            int knapsackSize = 0;
            int.TryParse(lines[0], out knapsackSize);

        }
    }
}
