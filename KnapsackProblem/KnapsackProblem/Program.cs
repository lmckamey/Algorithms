using System;
using System.IO;
using System.Linq;

namespace KnapsackProblem
{

    struct KnapsackItem
    {
        public string name;
        public int weight;
        public int value;
    }

    class Program
    {

        static KnapsackItem[] items;
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
            items = new KnapsackItem[knapsackSize];

            for (int i = 1; i < lines.Length; i++)
            {
                if(true/* string begins with */)
                {
                    lines[i].Split()
                }
            }

        }
    }
}
