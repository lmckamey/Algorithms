using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkArchitect
{
    class Program
    {
        public class Node
        {
            public string name;
            public Dictionary<Node, int> neighbors;
        }


        static List<List<string>> mazeInfo = new List<List<string>>();
        static List<List<Node>> solutions = new List<List<Node>>();
        static List<Node> currentMaze = new List<Node>();
        static Node endNode;
        static Node startNode;
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


            //for (int i = 0; i < mazeInfo.Count; i++)
            ////for (int i = 0; i < 1; i++)
            //{
            //    List<Node> path = new List<Node>();
            //    GenerateMaze(i);
            //    //PrintCurrentMaze();
            //    List<Node> solution = new List<Node>();
            //    if (solutions.Count != 0)
            //    {
            //        solution = solutions[0];
            //    }
            //    foreach (var item in solutions)
            //    {
            //        if ((item.Count) < solution.Count)
            //        {
            //            solution = item;
            //        }
            //    }
            //    PrintSingeSolution(solution);
            //    startNode = null;
            //    endNode = null;
            //    solutions.Clear();
            //}

        }
        static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
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
            }
            if (info.Count != 0)
            {
                mazeInfo.Add(new List<string>(info));
                info.Clear();
            }
        }
        static void GenerateMaze(int index)
        {
            GenerateNode(mazeInfo[index][0]);
            List<string> tempList = mazeInfo[index];
            for (int i = 2; i < tempList.Count; i++)
            {
                var query = tempList[i].Where(c => c != ',');
                var thingy = query.ToList();

                var query2 = currentMaze.Where(n => n.name == thingy[0].ToString());
                Node first = query2.First();


                Dictionary<Node, int> tempNeighbors = new Dictionary<Node, int>();
                for (int j = 1; j < thingy.Count; j++)
                {
                    var query3 = currentMaze.Where(n => n.name == thingy[j].ToString());
                    Node first2 = query3.First();
                }
                first.neighbors = tempNeighbors;
            }

            var pathQuery = tempList[1].Where(c => c != ',').ToList();
            startNode = currentMaze.Where(n => n.name == pathQuery[0].ToString()).First();
            endNode = currentMaze.Where(n => n.name == pathQuery[1].ToString()).First();


        }
        static void GenerateNode(string nodeInfo)
        {
            string[] array = nodeInfo.Split(',');
            foreach (var item in array)
            {
                Node tempNode = new Node();
                tempNode.name = item;
                tempNode.neighbors = new Dictionary<Node, int>();
                currentMaze.Add(tempNode);
            }
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
        static void PrintCurrentMaze()
        {

            Console.WriteLine("STARTNODE:" + startNode.name);
            Console.WriteLine("ENDNODE:" + endNode.name);
            foreach (var item in currentMaze)
            {
                Console.WriteLine("Name: " + item.name);
                Console.WriteLine("num Of Neighbors: " + item.neighbors.Count);
                foreach (var item2 in item.neighbors)
                {
                    //Console.WriteLine(item2.name);
                }
            }
        }

        static void PrintSolutions()
        {
            for (int i = 0; i < solutions.Count; i++)
            {
                Console.WriteLine("SOLUTION " + i + ":");
                foreach (var item in solutions[i])
                {
                    Console.Write(item.name + ",");
                }
                Console.WriteLine();
            }
        }

        static void PrintSingeSolution(List<Node> solution)
        {
            Console.WriteLine("SOLUTION ");
            if (solution.Count != 0)
            {
                for (int i = 0; i < solution.Count - 1; i++)
                {
                    Console.Write(solution[i].name + ",");
                }
                Console.Write(solution[solution.Count - 1].name);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Maze Cannot Be Solved");
            }
        }

    }
}
