using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace nQueens
{
    class Program
    {

        static int[] grid;
        static List<int[]> solutions = new List<int[]>();
        static int stepCount = 0;
        static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            sw.Start();
            int userNum = 0;
            while (userNum == 0)
            {
                userNum = PromptUser();
            }
            grid = new int[userNum];
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = -1;
            }
            PlaceQueens(0);
            Console.WriteLine("Step Count: " + stepCount);
            Console.WriteLine("Solutions:  " + solutions.Count);
            Console.WriteLine("TIME: " + sw.Elapsed);
            //PrintArray();
        }


        static int PromptUser()
        {
            Console.WriteLine("Welcome to the N Queens Simulator!");
            Console.WriteLine("Please Enter an number greater than 0: ");
            string userIn = Console.ReadLine();
            int userNum = 0;
            int.TryParse(userIn, out userNum);
            return userNum;

        }

        static void PlaceQueens(int column)
        {
            stepCount++;
            if (column < grid.Length)
            {
                for (int QueenRow = 0; QueenRow < grid.Length; QueenRow++)
                {
                    if (column == 0)
                    {
                        grid[column] = QueenRow;
                        PlaceQueens(column + 1);
                        continue;
                    }
                    bool isValid = true;
                    for (int prevColumn = column-1; prevColumn >= 0; prevColumn--)
                    {
                        bool Horizontal;
                        bool diagUP;
                        bool diagDOWN;
                        // !isValid break;
                        if (!isValid) break;

                        Horizontal = (grid[prevColumn] != QueenRow);

                        //// Check Diags
                        diagUP = (column + QueenRow != prevColumn+ grid[prevColumn]);
                        diagDOWN = (column - QueenRow != (prevColumn - grid[prevColumn]));

                        isValid = Horizontal && diagUP && diagDOWN;
                        
                    }
                    if (isValid)
                    {
                        grid[column] = QueenRow;
                        PlaceQueens(column + 1);
                    }
                }
            }
            else
            {
                int[] temp = grid.Select(x => x).ToArray();
                solutions.Add(temp);
            }
        }

        static void PrintArray()
        {
            foreach (var item in solutions)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    for (int j = 0; j < item.Length; j++)
                    {
                        if (item[i] == j)
                        {
                            Console.Write("|Q|");
                        }
                        else
                        {
                            Console.Write("|_|");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        //static void PrintArray()
        //{
        //    foreach (var item in solutions)
        //    {
        //        for (int i = 0; i < item.Length; i++)
        //        {
        //            Console.Write(item[i] + ", ");

        //        }
        //        Console.WriteLine();

        //    }
        //}
    }
}
