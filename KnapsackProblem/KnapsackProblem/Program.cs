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
        static List<KnapsackItem> currentKnapsack = new List<KnapsackItem>();

        static Dictionary<int, List<KnapsackItem>> solutions = new Dictionary<int, List<KnapsackItem>>();
        static int allotedweight;
        static int counter = 0;

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
            DetermineSolutions();
            CleanSolutions();
            PrintSolutions();
            DetermineBestSolution();
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


        static void DetermineSolutions()
        {
            currentKnapsack.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                currentKnapsack.Add(items[i]);
                var temp = currentKnapsack.Select(x => x).ToList();
                int value = 0;
                foreach (var item in temp)
                {
                    value += item.value;
                }
                if (!(solutions.ContainsValue(temp) && solutions.ContainsKey(value)))
                    solutions.Add(value, temp);
                for (int j = 0; j < items.Count; j++)
                {
                    if (!currentKnapsack.Contains(items[j]))
                        currentKnapsack.Add(items[j]);
                    temp = currentKnapsack.Select(x => x).ToList();
                    value = 0;
                    foreach (var item in temp)
                    {
                        value += item.value;
                    }

                    if (!solutions.ContainsKey(value))
                        solutions.Add(value, temp);
                }
                currentKnapsack.Clear();
            }
        }

        static void CleanSolutions()
        {
            Dictionary<int, List<KnapsackItem>> tempSolutions = new Dictionary<int, List<KnapsackItem>>();
            var keys = solutions.Keys;
            foreach (var key in keys)
            {
                int weight = 0;
                foreach (var item in solutions[key])
                {
                    weight += item.weight;
                }
                if (weight <= allotedweight)
                    tempSolutions.Add(key, solutions[key]);
            }

            solutions = tempSolutions;
        }

        static void DetermineBestSolution()
        {
            List<KnapsackItem> tempSolutions = new List<KnapsackItem>();
            int maxvalue = 0;
            var keys = solutions.Keys;
            foreach (var key in keys)
            {
                int value = 0;
                foreach (var item in solutions[key])
                {
                    value += item.value;
                }
                if (value > maxvalue)
                {
                    maxvalue = value;
                    tempSolutions = solutions[key];
                }
            }
            Console.WriteLine("\n\nBEST SOLUTION: ");
            int weight = 0;
            int totalValue = 0;
            foreach (var item in tempSolutions)
            {
                Console.WriteLine(item.name);
                weight += item.weight;
                totalValue += item.value;
            }
            Console.WriteLine("Value: " + totalValue);
            Console.WriteLine("Weight: " + weight);

        }

        static void PrintList()
        {

            Console.WriteLine("\n\n\nITEMS FOUND: ");
            foreach (var item in items)
            {
                Console.WriteLine(item.name + ", " + item.weight + ", " + item.value);
            }
            Console.WriteLine();
        }

        static void PrintSolutions()
        {
            Console.WriteLine("Total Solutions : " + solutions.Count);
        }



    }
}


