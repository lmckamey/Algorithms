using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class Sorter<T> where T : IComparable<T>
    {
        public static void BubbleSort(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j + 1].CompareTo(arr[j]) < 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                    }
                }
            }
        }

        public static void SelectionSort(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[min]) < 0)
                    {
                        T temp = arr[j];
                        arr[j] = arr[min];
                        arr[min] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(T[] arr)
        {
            for (int i = 1; i < arr.Length-1; i++)
            {
                var v = arr[i];
                int j = i - 1;

                while (j >= 0 && (arr[j].CompareTo(v) > 0))
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                    v = arr[j + 1];
                }
            }
        }

    }

}
