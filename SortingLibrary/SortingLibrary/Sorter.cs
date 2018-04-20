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
            T[] A;
            T[] B;
            if (arr.Length > 1)
            {
                A = arr.Take(arr.Length / 2).ToArray();
                B = arr.Skip(arr.Length / 2).ToArray();

                MergeSort(A);
                MergeSort(B);
                Merge(A, B, arr);
            }
        }

        public static void Merge(T[] A, T[] B, T[] origin)
        {
            int k = 0;
            int i = 0;
            int j = 0;
            while (i < A.Length && j < B.Length)
            {
                if (A[i].CompareTo(B[j]) < 0)
                {
                    origin[k] = A[i];
                    i++;
                }
                else
                {
                    origin[k] = B[j];
                    j++;
                }
                k++;
            }
            while (i < A.Length)
            {
                origin[k] = A[i];
                i++;
                k++;
            }

            while (j < B.Length)
            {
                origin[k] = B[j];
                j++;
                k++;
            }
        }

        public static void QuickSort(T[] arr)
        {
            if (arr.Length > 0)
            {
                List<T> Left = new List<T>();
                List<T> Right = new List<T>();
                int randomIndex = randy.Next(0, arr.Count());
                T pivot = arr[0];
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
                QuickSort(Left.ToArray());
                QuickSort(Right.ToArray());
            } 
        }
    }

}
