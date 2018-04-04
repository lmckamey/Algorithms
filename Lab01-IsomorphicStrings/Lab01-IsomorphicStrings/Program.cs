using System;
using System.Collections.Generic;

namespace Lab01_IsomorphicStrings
{
    class Program
    {

        private static string[] strings;

        static List<String> isomorphicExactList = new List<string>();
        static List<String> isomorphicLooseList = new List<string>();
        static List<String> nonisomorphicList = new List<string>();

        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Please enter a file path: ");
            OpenFile(Console.ReadLine());
            printAllStringsInList();
        }

        static void OpenFile(string path)
        {
            strings = System.IO.File.ReadAllLines(path);  
        }

        static void printAllStringsInList()
        {
            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]);
            }
            
        }
    }
}
