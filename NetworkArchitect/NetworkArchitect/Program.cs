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

        static string path = "C:/Users/Lucas/Downloads/NetworkInputTest.txt";


        static List<List<string>> mazeInfo = new List<List<string>>();
        static List<List<Node>> solutions = new List<List<Node>>();
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
            Console.WriteLine("CURRENT NODES");
            PrintCurrentMaze();


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
            //string path = "";
            while (path == null || path == "")
            {
                //path = PromptForString("Please Enter a file Path");
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
            for (int i = 1; i < tempList.Count; i++)
            {
                string[] nodes = tempList[i].Split(',');
                Dictionary<Node, int> tempNeighbors = new Dictionary<Node, int>();
                var modifiedNode = currentMaze.Where(n => n.name == nodes[0]).First();
                for (int j = 1; j < nodes.Length; j++)
                {

                    string[] tempStrings = nodes[j].Split(':');
                    int weight = 0;
                    int.TryParse(tempStrings[1].Trim(), out weight);

                    var neighborNode = currentMaze.Where(n => n.name == tempStrings[0]).First();
                    tempNeighbors.Add(neighborNode, weight);

                }

                modifiedNode.neighbors = new Dictionary<Node, int>(tempNeighbors);
            }

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
            foreach (var item in currentMaze)
            {
                Console.WriteLine("Name: " + item.name);
                Console.WriteLine("num Of Neighbors: " + item.neighbors.Count);
                var keys = item.neighbors.Keys;
                foreach (var item2 in keys)
                {
                    Console.Write(item2.name);
                    Console.WriteLine("Weight: "+item.neighbors[item2]); 
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
