using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW02_NumberOfRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Factorial(3);
        }


        public static int NumberOfRectangles(int row, int column)
        {
            return (row * column * (row + 1) * (column + 1)) / 4;
        }

        public static bool IsValidWalk(string[] walk)
        {
            bool isValid = false;
            int y = 0;
            int x = 0;
            if (walk.Length == 10)
            {
                foreach (var item in walk)
                {

                    if (item == "n") y += 1;
                    if (item == "s") y -= 1;
                    if (item == "e") x -= 1;
                    if (item == "w") x += 1;
                }
                isValid = ((x + y) == 0);
            }

            return isValid;
        }

        public static BigInteger NumberOfRoutes(int m, int n)
        {
            return 0;
        }

        public static BigInteger Factorial(int x)
        {
            int num = 1;
            while (x > 1)
            {
                num *= --x;
            }
            return num;
        }
    }
}
