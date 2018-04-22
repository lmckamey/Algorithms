using System;
using System.Collections.Generic;

namespace CodeWarsScratch
{
    struct Vec2
    {
        public int x, y;
    }

    class Program
    {
        public static Random randy = new Random();

        static int[] array = { 1, 5, 8, 2, 3, 6, 7, 9, 0, 4 };
        static void Main(string[] args)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            //array = new int[] {4, 2, 1, 3, 4};
            QuickSort(array);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

        }

        static void QuickSort(int[] arr)
        {
            if (arr.Length <= 1) return;
            
            List<int> Left = new List<int>();
            List<int> Right = new List<int>();
            int randomIndex = randy.Next(0, arr.Length);
            int pivot = arr[randomIndex];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(pivot) < 0)
                {
                    Left.Add(arr[i]);
                }
                else if (arr[i].CompareTo(pivot) > 0)
                {
                    Right.Add(arr[i]);
                }
            }
            var leftArray = Left.ToArray();
            var rightArray = Right.ToArray();
            QuickSort(leftArray);
            QuickSort(rightArray);

            for (int i = 0; i < leftArray.Length; i++)
            {
                arr[i] = leftArray[i];
            }
            arr[leftArray.Length] = pivot;
            for (int i = 0; i < rightArray.Length; i++)
            {
                arr[i + leftArray.Length+1] = rightArray[i];
            }
            
        }

            //public static int[,] FloodFill(int[,] array, int y, int x, int newValue)
            //{
            //    array[x, y] = newValue;


            //    return array;
            //}

            //public static void GetNeighbors(int[,] array, int x1, int y1, Queue<Vec2> queue)
            //{
            //    List<Vec2> mylist = new List<Vec2>();
            //    //middle with Four Neighbors
            //    if ((x1 < array.GetLength(0) && x1 > 0) && (y1 < array.GetLength(1) && y1 > 0))
            //    {
            //        mylist.Add(new Vec2 { x = x1 + 1, y = y1 });
            //        mylist.Add(new Vec2 { x = x1 - 1, y = y1 });
            //        mylist.Add(new Vec2 { x = x1, y = y1 + 1 });
            //        mylist.Add(new Vec2 { x = x1, y = y1 - 1 });
            //    }
            //    //Far Right with 3 neighbors
            //    else if (x1 == array.GetLength(0) && (y1 < array.GetLength(1) && y1 > 0))
            //    {
            //        mylist.Add(new Vec2 { x = x1 - 1, y = y1 });
            //        mylist.Add(new Vec2 { x = x1, y = y1 + 1 });
            //        mylist.Add(new Vec2 { x = x1, y = y1 - 1 });
            //    }
            //    //Far Left with 3 Neighbors
            //    else if (x1 == 0 && (y1 < array.GetLength(1) && y1 > 0))
            //    {

            //    }
            //    //Bottome with 3 Neighbors
            //    else if ((x1 < array.GetLength(0) && x1 > 0) && (y1 == array.GetLength(1)))
            //    {

            //    }
            //    //Top with 3 Neighbors
            //    else if ((x1 < array.GetLength(0) && x1 > 0) && (y1 == 0))
            //    {

            //    }
            //}
        }
    }

