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
        static void Main(string[] args)
        {

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

