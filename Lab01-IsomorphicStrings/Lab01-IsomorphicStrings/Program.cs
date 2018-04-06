using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01_IsomorphicStrings
{
    class Word
    {
        public string BaseString;
        public string LooseCode;
        public string ExactCode;
    }

    struct CodeChar
    {
        public char baseChar;
        public char value;
    }

    class Program
    {

        static List<Word> words = new List<Word>();

        static Dictionary<string, List<Word>> isomorphicExactList = new Dictionary<string, List<Word>>();
        static Dictionary<string, List<Word>> isomorphicLooseList = new Dictionary<string,List<Word>>();
        static List<Word> nonisomorphicList = new List<Word>();

        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Please enter a file path: ");
            OpenFile(Console.ReadLine());
            PrintAllStringsInList();

            Console.WriteLine("EXACT CODE\n\n");
            DetermineExactCode();
            Console.WriteLine("LOOSE CODE\n\n");
            DetermineLooseCode();
            Console.WriteLine("DETERMINE EXACTS ISOS\n\n");
            DetermineExactIsomorphs();
            Console.WriteLine("DETERMINE LOOSE ISOS\n\n");
            DetermineLooseIsomorphs();
            CleanNonIsomorphList();
            printLists();
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

        static void DetermineExactCode()
        {
            //determines the occurences of letters in exact order i.e Word: moo Code: 011 or Word: Sad Code: 012
            List<CodeChar> ExactCode = new List<CodeChar>();

            foreach (Word item in words)
            {
                char index = '0';
                string temp = item.BaseString;
                char[] tempChars = temp.ToCharArray();

                List<char> charactersInString = new List<char>();

                foreach (Char c in tempChars)
                {
                    if (charactersInString.Contains(c))
                    {
                        var query = ExactCode.Where(c2 => c2.baseChar == c);
                        var thingy = query.First();
                        CodeChar cChar = new CodeChar();
                        cChar.baseChar = c;
                        cChar.value = thingy.value;
                        ExactCode.Add(cChar);
                    }
                    else
                    {
                        charactersInString.Add(c);
                        CodeChar cChar = new CodeChar();
                        cChar.baseChar = c;
                        cChar.value = index;
                        ExactCode.Add(cChar);
                        index++;
                    }

                }

                char[] chars = new char[ExactCode.Count];
                int idex = 0;
                foreach (CodeChar item2 in ExactCode)
                {
                    chars[idex] = item2.value;
                    idex++;
                }
                item.ExactCode = new string(chars);
                ExactCode.Clear();
                Console.WriteLine(item.BaseString + " :" + item.ExactCode);

            }

        }

        static void DetermineLooseCode()
        {
            Dictionary<char, char> LooseCode = new Dictionary<char, char>();
            //determines the occurences of letters in assending order i.e Word: moo Code: 12 or Word: Sad Code: 111
            foreach (Word item in words)
            {

                string temp = item.BaseString;
                char[] tempChars = temp.ToCharArray();

                List<char> charcode = new List<char>();
                List<char> charactersInString = new List<char>();

                foreach (Char c in tempChars)
                {
                    if (charactersInString.Contains(c))
                    {
                        LooseCode[c]++;
                    }
                    else
                    {
                        charactersInString.Add(c);
                        LooseCode.Add(c, '1');
                    }

                }
                var keys = LooseCode.Keys;
                char[] chars = new char[keys.Count];
                int idex = 0;
                foreach (var item2 in keys)
                {
                    chars[idex] = LooseCode[item2];
                    idex++;
                }

                Array.Sort(chars);
                item.LooseCode = new string(chars);
                LooseCode.Clear();
                Console.WriteLine(item.LooseCode + " : " + item.BaseString);
            }

        }

        static void PrintAllStringsInList()
        {
            foreach (var item in words)
            {
                Console.WriteLine(item.BaseString);
            }
        }

        static void DetermineLooseIsomorphs()
        {
            List<Word> LooseIsos = new List<Word>();
            List<string> codes = new List<string>();
            foreach (var item in words)
            {
                if (!codes.Contains(item.LooseCode))
                {
                    codes.Add(item.LooseCode);
                }
            }
            foreach (var code in codes)
            {
                var query = words.Where(w => w.LooseCode == code);
                LooseIsos = query.ToList();
                Console.WriteLine("LISTING OF THINGS");
                foreach (var item in LooseIsos)
                {
                    Console.WriteLine(item.BaseString + " : " + item.LooseCode);
                }
                if (LooseIsos.Count > 1)
                {
                    isomorphicLooseList.Add(code, LooseIsos);
                    LooseIsos.Clear();
                }
                else
                {
                    nonisomorphicList.Add(LooseIsos.First());
                    LooseIsos.Clear();
                }
            }

            Console.WriteLine("NUM OF NONISOMORPHS: " + nonisomorphicList.Count);


        }

        static void DetermineExactIsomorphs()
        {
            List<Word> ExactIsomorphs = new List<Word>();
            List<string> codes = new List<string>();
            foreach (var item in words)
            {
                if (!codes.Contains(item.ExactCode))
                {
                    codes.Add(item.ExactCode);
                }
            }
            foreach (var code in codes)
            {
                var query = words.Where(w => w.ExactCode == code);
                ExactIsomorphs = query.ToList();
                Console.WriteLine("LISTING OF THINGS");
                foreach (var item in ExactIsomorphs)
                {
                    Console.WriteLine(item.BaseString + " : " + item.ExactCode);
                }
                if (ExactIsomorphs.Count > 1)
                {
                    isomorphicExactList.Add(code, ExactIsomorphs);
                    ExactIsomorphs.Clear();
                }
                else
                {
                    nonisomorphicList.Add(ExactIsomorphs.First());
                    ExactIsomorphs.Clear();
                }
            }
            
            Console.WriteLine("NUM OF NONISOMORPHS: " + nonisomorphicList.Count);

        }

        static void CleanNonIsomorphList()
        {
            List<Word> tempList = new List<Word>();
            foreach (var item in nonisomorphicList)
            {
                
                if(!tempList.Contains(item))
                {
                    tempList.Add(item);
                }
            }
            nonisomorphicList = tempList;

            Console.WriteLine("NONISOMORPHS: \n");
            foreach (Word w in nonisomorphicList)
            {
                Console.WriteLine(w.BaseString + ": Exact Code: "+ w.ExactCode +  " Loose Code :" + w.LooseCode);
            }
        }

        static void printLists()
        {
            Console.WriteLine("EXACT ISOMORPHS");
            if(isomorphicExactList.Count != 0)
            {
                List<string> codes = isomorphicExactList.Keys.ToList();
                foreach (var c in codes)
                {
                    Console.WriteLine("CODE: "+ c);
                    var thingy = isomorphicExactList[c];
                    foreach (Word w in thingy)
                    {
                        Console.WriteLine(w.BaseString);
                    }
                }
            }
            Console.WriteLine("LOOSE ISOMORPHS");
            if (isomorphicLooseList.Count != 0)
            {
                List<string> codes = isomorphicLooseList.Keys.ToList();
                foreach (var c in codes)
                {
                    Console.WriteLine("CODE: " + c);
                    foreach (var w in isomorphicLooseList[c])
                    {
                        Console.WriteLine(w.BaseString);
                    }
                }
            }
        }

    }
}
