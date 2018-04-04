using System;
using System.Collections.Generic;

namespace Lab01_IsomorphicStrings
{
    struct Word
    {
        public string BaseString;
        public string LooseCode;
        public string ExactCode;
    }
    class Program
    {

        static List<Word> words = new List<Word>();

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
            string[] strings;
            strings = System.IO.File.ReadAllLines(path);

            PutWordsIntoList(strings);
        }

        static void PutWordsIntoList(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                Word w = new Word();
                w.BaseString = strings[i];
                words.Add(w);
            }
        }

        static void determineExactCode()
        {
            //determines the occurences of letters in exact order i.e Word: moo Code: 011 or Word: Sad Code: 012
        }
        static void determineLooseCode()
        {
            //determines the occurences of letters in assending order i.e Word: moo Code: 12 or Word: Sad Code: 111
            foreach (Word item in words)
            {
                int[] ints;
                char[] charactersInString;

            }

        }

        static void printAllStringsInList()
        {
            foreach (var item in words)
            {
                Console.WriteLine(item.BaseString);
            }
        }
    }
}
