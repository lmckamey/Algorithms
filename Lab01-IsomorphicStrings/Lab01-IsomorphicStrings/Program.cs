using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        static Dictionary<string, List<Word>> isomorphicLooseList = new Dictionary<string, List<Word>>();
        static List<Word> nonisomorphicList = new List<Word>();

        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Please enter a file path: ");
            if (OpenFile(Console.ReadLine()))
            {
                Run();
            }
        }

        static void Run()
        {
            DetermineExactCode();
            DetermineLooseCode();
            DetermineExactIsomorphs();
            DetermineLooseIsomorphs();
            CleanNonIsomorphList();
            printLists();
        }

        static bool OpenFile(string path)
        {
            string[] strings;
            strings = System.IO.File.ReadAllLines(path);

            if (strings.Length > 0)
            {
                PutWordsIntoList(strings);
                return true;
            }
            return false;
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

            }

        }

        static void DetermineLooseCode()
        {
            //determines the occurences of letters in assending order i.e Word: moo Code: 12 or Word: Sad Code: 111
            Dictionary<char, char> LooseCode = new Dictionary<char, char>();
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
                List<Word> LooseIsos = new List<Word>();
                var query = words.Where(w => w.LooseCode == code);
                LooseIsos = query.ToList();
                if (LooseIsos.Count > 1)
                {
                    isomorphicLooseList.Add(code, LooseIsos);
                }
                else
                {
                    nonisomorphicList.Add(LooseIsos.First());
                }
            }
        }

        static void DetermineExactIsomorphs()
        {
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
                List<Word> ExactIsomorphs = new List<Word>();
                var query = words.Where(w => w.ExactCode == code);
                ExactIsomorphs = query.ToList();
                if (ExactIsomorphs.Count > 1)
                {
                    isomorphicExactList.Add(code, ExactIsomorphs);
                }
                else
                {
                    nonisomorphicList.Add(ExactIsomorphs.First());
                }
            }
        }

        static void CleanNonIsomorphList()
        {
            List<Word> tempList = new List<Word>();
            foreach (var item in nonisomorphicList)
            {
                if (!tempList.Contains(item))
                {
                    tempList.Add(item);
                }
                if(isomorphicExactList.ContainsKey(item.ExactCode) || isomorphicLooseList.ContainsKey(item.LooseCode))
                {
                    tempList.Remove(item);
                }
            }
            nonisomorphicList = tempList;

        }

        static void printLists()
        {
            StringBuilder sBuilder = new StringBuilder();

            sBuilder.Append("\nEXACT ISOMORPHS\n\n");
            if (isomorphicExactList.Count != 0)
            {
                List<string> codes = isomorphicExactList.Keys.ToList();
                foreach (var c in codes)
                {
                    sBuilder.Append(c + ": ");
                    var thingy = isomorphicExactList[c];
                    foreach (Word w in thingy)
                    {
                        sBuilder.Append(w.BaseString + "   ");
                    }
                    sBuilder.Append("\n");
                }
            }
            sBuilder.Append("\nLOOSE ISOMORPHS\n\n");
            if (isomorphicLooseList.Count != 0)
            {
                List<string> codes = isomorphicLooseList.Keys.ToList();
                foreach (var c in codes)
                {
                    sBuilder.Append(c + ": ");
                    foreach (var w in isomorphicLooseList[c])
                    {
                        sBuilder.Append(w.BaseString + "   ");
                    }
                    sBuilder.Append("\n");
                }
            }

            sBuilder.Append("\nNONISOMORPHS: \n\n");
            foreach (Word w in nonisomorphicList)
            {
                sBuilder.Append(w.BaseString + "   ");
            }
            string[] lines = sBuilder.ToString().Split('\n');
            System.IO.File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\OutPut.txt", lines);
        }

    }
}
