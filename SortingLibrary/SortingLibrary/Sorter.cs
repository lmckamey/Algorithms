using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class Sorter<T> where T : IComparable<T>
    {

        public static Random randy = new Random();
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
            for (int i = 1; i < arr.Length; i++)
            {
                var v = arr[i];
                int j = i - 1;

                while (j >= 0 && (arr[j].CompareTo(v) > 0))
                {
                    T temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    j = j - 1;
                }
            }
        }

        public static void MergeSort(T[] arr)
        {
            if(arr.Count() > 1)
            {
                int randomIndex = randy.Next(0, arr.Count());
                T pivot = arr[randomIndex];

            }
        }

        public static void Merge(T[] A, T[] B, T[] origin )
        {
           
        }

        public static void QuickSort(T[] arr)
        {

        }
    }

}
