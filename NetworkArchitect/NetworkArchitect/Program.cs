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
            public List<Connection> neighbors;
        }
        public class Connection
        {
            public int weight;
            public Node baseNode;
            public Node connectedNode;
        }
        public class Graph
        {
            public List<Node> nodes = new List<Node>();
            public List<Connection> connections = new List<Connection>();
            public List<Connection> mst = new List<Connection>();
        }


        static string path = "C:/Users/Lucas/Downloads/NetworkInputTest.txt";


        static List<List<string>> graphInfo = new List<List<string>>();
        static List<Node> currentMaze = new List<Node>();
        static List<Graph> graphs = new List<Graph>();


        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            string[] rawFileInfo = null;
            ParseFileData(ref rawFileInfo);
            PopulateGraphInfo(rawFileInfo);
            PopulateNodeNeighbors(0);

            CreateGraphs();
            FindMSTs();
            //PrintGraphs();
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
        static void PopulateGraphInfo(string[] rawFileInfo)
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
                graphInfo.Add(new List<string>(info));
                info.Clear();
            }
        }
        static void PopulateNodeNeighbors(int index)
        {
            GenerateNode(graphInfo[index][0]);
            List<string> tempList = graphInfo[index];
            for (int i = 1; i < tempList.Count; i++)
            {
                string[] nodes = tempList[i].Split(',');
                List<Connection> tempNeighbors = new List<Connection>();
                var currentNode = currentMaze.Where(n => n.name == nodes[0]).First();
                for (int j = 1; j < nodes.Length; j++)
                {

                    string[] tempStrings = nodes[j].Split(':');
                    int weight = 0;
                    int.TryParse(tempStrings[1].Trim(), out weight);

                    var neighborNode = currentMaze.Where(n => n.name == tempStrings[0]).First();

                    Connection tempConnection = new Connection() { baseNode = currentNode, connectedNode = neighborNode, weight = weight };
                    tempNeighbors.Add(tempConnection);
                }
                currentNode.neighbors = new List<Connection>(tempNeighbors);

            }

        }
        static void GenerateNode(string nodeInfo)
        {
            string[] array = nodeInfo.Split(',');
            foreach (var item in array)
            {
                Node tempNode = new Node();
                tempNode.name = item;
                tempNode.neighbors = new List<Connection>();
                currentMaze.Add(tempNode);
            }
        }
        static void CreateGraphs()
        {
            List<Node> unusedNodes = new List<Node>(currentMaze);
            List<Node> usedNodes = new List<Node>();

            while (unusedNodes.Count > 0)
            {
                Graph graph = new Graph();
                Node currentNode = unusedNodes[0];
                List<Connection> connections = new List<Connection>();
                TraverseGraph(unusedNodes, usedNodes, currentNode, connections, graph);
                connections = connections.OrderBy(c => c.weight).ToList();
                graph.connections = new List<Connection>(connections);
                foreach (var item in connections)
                {
                    Console.WriteLine(item.baseNode.name + ":" + item.connectedNode.name + " = " + item.weight);
                }
                Console.WriteLine();
                graphs.Add(graph);
            }

        }
        static void TraverseGraph(List<Node> unusedNodes, List<Node> usedNodes, Node currentNode, List<Connection> connectionList, Graph graph)
        {
            if (!usedNodes.Contains(currentNode))
            {
                unusedNodes.Remove(currentNode);
                usedNodes.Add(currentNode);

                graph.nodes.Add(currentNode);
                for (int i = 0; i < currentNode.neighbors.Count; i++)
                {
                    TraverseGraph(unusedNodes, usedNodes, currentNode.neighbors[i].connectedNode, connectionList, graph);
                    Connection tempConnect = new Connection() { baseNode = currentNode, connectedNode = currentNode.neighbors[i].connectedNode, weight = currentNode.neighbors[i].weight };
                    var query = connectionList.Where(c => c.baseNode == tempConnect.connectedNode && c.connectedNode == tempConnect.baseNode && c.weight == tempConnect.weight);
                    var result = query.ToList();
                    if (result.Count == 0)
                        connectionList.Add(tempConnect);
                }
            }
        }
        static void FindMSTs()
        {
            for (int i = 0; i < graphs.Count; i++)
            {
                List<Connection> tempConnections = new List<Connection>();
                for (int j = 0; j < graphs[i].connections.Count; j++)
                {
                    if (!willCreateLoop(tempConnections, graphs[i].connections[j]))
                    {
                        tempConnections.Add(graphs[i].connections[j]);
                    }
                }
                graphs[i].mst = new List<Connection>(tempConnections);
                Console.WriteLine("MST:\n");
                foreach (var item in graphs[i].mst)
                {
                    Console.WriteLine(item.baseNode.name + ":" + item.connectedNode.name + " = " + item.weight);
                }
            }
        }

        static bool willCreateLoop(List<Connection> previousConections, Connection newConnection)
        {
            Node node1 = newConnection.baseNode;
            Node node2 = newConnection.connectedNode;

        }

        static void PrintMazeInfo()
        {

            for (int i = 0; i < graphInfo.Count; i++)
            {
                Console.WriteLine("MAZEINFO " + i + ":");
                foreach (var item in graphInfo[i])
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        static void PrintListOfNodes()
        {
            foreach (var item in currentMaze)
            {
                Console.WriteLine("Name: " + item.name);
                Console.WriteLine("num Of Neighbors: " + item.neighbors.Count);
                foreach (var item2 in item.neighbors)
                {
                    Console.WriteLine(item2.connectedNode.name + ": " + item2.weight);
                }
            }
        }

        static void PrintGraphs()
        {
            for (int i = 0; i < graphs.Count; i++)
            {
                Console.WriteLine("GRAPH" + i + ": ");
                for (int j = 0; j < graphs[i].nodes.Count; j++)
                {
                    Console.WriteLine(graphs[i].nodes[j].name);
                }

            }
        }

    }
}
