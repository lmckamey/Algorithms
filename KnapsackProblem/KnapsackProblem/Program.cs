using System;
using System.Collections.Generic;
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

        static List<KnapsackItem> items = new List<KnapsackItem>();
        static List<KnapsackItem> solution = new List<KnapsackItem>();

        static List<List<KnapsackItem>> solutions = new List<List<KnapsackItem>>();
        static int allotedweight;

        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            Console.WriteLine("Welcome to the knapsack Simulator!");
            Console.WriteLine("Please enter a file path: ");
            OpenFile(Console.ReadLine());
            PrintList();
            Console.WriteLine(DeterminSolutions(items.Count - 1));
        }

        static void OpenFile(string path)
        {
            string[] lines = File.ReadLines(path).ToArray();
            int knapsackSize = 0;
            int.TryParse(lines[0], out knapsackSize);
            allotedweight = knapsackSize;
            for (int i = 2; i < lines.Length - 1; i++)
            {
                if (lines[i].Trim() == "")
                    break;
                populateItemsArray(lines[i].Trim());
            }

        }
        static void populateItemsArray(string raw)
        {
            KnapsackItem item = new KnapsackItem();
            string[] split = raw.Split(",");
            item.name = split[0];
            int.TryParse(split[1], out item.weight);
            int.TryParse(split[2], out item.value);
            items.Add(item);
        }


        static int DeterminSolutions(int index)
        {
            int result = 0;
            if(solution.Contains(items[index]))
            {

            }
            if (index == 0 || allotedweight == 0)
                result = 0;
            else if (items[index].weight > allotedweight)
            {
                result = DeterminSolutions(index - 1);
            }
            else
            {
                int temp = DeterminSolutions(index - 1);
                allotedweight -= items[index].weight;
                int temp2 = items[index].value + DeterminSolutions(index - 1);
                result = Math.Max(temp, temp2);
            }
            return result;
        }
        static void PrintList()
        {
            Console.WriteLine("ITEMS FOUND: ");
            foreach (var item in items)
            {
                Console.WriteLine(item.name + ", " + item.weight + ", " + item.value);
            }

            //Console.WriteLine("Solution");
            //foreach (var item in solution)
            //{
            //    Console.WriteLine(item.name);
            //}
            //Console.WriteLine("Solutions");
            //foreach (var item in solutions)
            //{
            //    foreach (var item2 in item)
            //    {
            //        Console.WriteLine(item2.name);
            //    }
            //}
        }



    }
}


