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


        static List<List<string>> mazeInfo = new List<List<string>>();
        static List<Node> currentMaze = new List<Node>();
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            string[] rawFileInfo = null;
            ParseFileData(ref rawFileInfo);
            populateMazeInfo(rawFileInfo);

            PrintMazeInfo();

            GenerateMaze(0);
        }

        static bool ParseFileData(ref string[] lines)
        {
            string path = "";
            while (path == null || path == "")
            {
                path = PromptForString("Please Enter a file Path");
            }
            string[] rawFileStrings = File.ReadAllLines(path);
            for (int i = 0; i < rawFileStrings.Length; i++)
            {
                if (rawFileStrings[i] != "")
                    if (rawFileStrings[i][0] == '/')
                        rawFileStrings[i] = "";
            }
            lines = rawFileStrings;
            return (rawFileStrings != null);
        }

        static void populateMazeInfo(string[] rawFileInfo)
        {
            List<String> info = new List<string>();
            for (int i = 0; i < rawFileInfo.Length; i++)
            {
                if (rawFileInfo[i] != "")
                {
                    info.Add(rawFileInfo[i]);
                }
                else
                {
                    if (info.Count != 0)
                    {
                        mazeInfo.Add(new List<string>(info));
                        info.Clear();
                    }
                }
            }
        }

        static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        static void PrintMazeInfo()
        {

            for (int i = 0; i < mazeInfo.Count; i++)
            {
                Console.WriteLine("MAZEINFO " + i + ":");
                foreach (var item in mazeInfo[i])
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static void GenerateMaze(int index)
        {
            GenerateNode(mazeInfo[index][0]);
            List<string> tempList = mazeInfo[index];
            for (int i = 1; i < tempList.Count; i++)
            {
                var query = tempList[i].Where(c => c != ',');
                var thingy = query.ToList();

                var query2 = currentMaze.Where(n => n.name == thingy[0].ToString());
                Node first = query2.First();

                List<Node> tempNeighbors = new List<Node>();
                for (int j = 1; j < thingy.Count; j++)
                {
                    var query3 = currentMaze.Where(n => n.name == thingy[j].ToString());
                    Node first2 = query2.First();
                    tempNeighbors.Add(first2);
                }
                first.neighbors = tempNeighbors;
            }

            foreach (var item in currentMaze)
            {
                Console.WriteLine("Name: " + item.name);
                Console.WriteLine("num Of Neighbors: " + item.neighbors.Count);
            }
        }

        static void GenerateNode(string nodeInfo)
        {
            var query = nodeInfo.Where(c => c != ',');
            var thingy = query.ToList();
            foreach (var item in thingy)
            {
                Node tempNode = new Node();
                tempNode.name = item.ToString();
                tempNode.neighbors = new List<Node>();
                currentMaze.Add(tempNode);
            }
        }

        static void BreadthFirstSearch(Node startingNode)
        {
        }
    }
}
