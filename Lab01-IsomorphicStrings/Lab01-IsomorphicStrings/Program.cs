using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01_IsomorphicStrings
{
    class Word
    {
        public string BaseString;
        public Dictionary<char, char> LooseCode = new Dictionary<char, char>();
        public List<CodeChar> ExactCode = new List<CodeChar>();
    }

    struct CodeChar
    {
       public char baseChar;
       public char value;
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
            //Console.WriteLine("Welcome!");
            //Console.WriteLine("Please enter a file path: ");
            //OpenFile(Console.ReadLine());
            //printAllStringsInList();

            //determineExactCode();
            Word test = new Word();
            test.BaseString = "fred";
            testMethod(test);

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
            foreach (Word item in words)
            {
                char index = '0';
                string temp = item.BaseString;
                char[] tempChars = temp.ToCharArray();

                List<char> charcode = new List<char>();
                List<char> charactersInString = new List<char>();

                foreach (Char c in tempChars)
                {
                    Console.WriteLine(c);
                    if (charactersInString.Contains(c))
                    {
                        var query = item.ExactCode.Where(c2 => c2.baseChar == c);
                        var thingy = query.First();
                        CodeChar cChar = new CodeChar();
                        cChar.baseChar = c;
                        cChar.value = thingy.value;
                        item.ExactCode.Add(cChar);
                    }
                    else
                    {
                        charactersInString.Add(c);
                        CodeChar cChar = new CodeChar();
                        cChar.baseChar = c;
                        cChar.value = index;
                        item.ExactCode.Add(cChar);
                        index++;
                    }

                }

                foreach (CodeChar item2 in item.ExactCode)
                {
                    Console.Write(item2.value);
                }
                Console.WriteLine();

            }

        }

        static void testMethod(Word item)
        {
            string temp = item.BaseString;
            char[] tempChars = temp.ToCharArray();

            List<char> charcode = new List<char>();
            List<char> charactersInString = new List<char>();

            foreach (Char c in tempChars)
            {
                Console.WriteLine(c);
                if (charactersInString.Contains(c))
                {
                    item.LooseCode[c]++;
                }
                else
                {
                    charactersInString.Add(c);
                    item.LooseCode.Add(c, '1');
                }

            }
            var keys = item.LooseCode.Keys;
            foreach (var item2 in keys)
            {
                Console.Write(item.LooseCode[item2]);
            }
            Console.WriteLine();
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
