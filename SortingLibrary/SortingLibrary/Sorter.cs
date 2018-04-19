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
                A = new T[arr.Length / 2];
                B = new T[arr.Length / 2];
                Array.Copy(arr, A, (arr.Length / 2));
                Array.Copy(arr, (arr.Length / 2), B, 0, B.Length - 1);

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
                    k++;
                }
            }
            //if (i == A.Length)
            //{
            //    Array.Copy(A, j, origin, A.Length - k, A.Length);
            //}
            //else
            //{
            //    Array.Copy(B, i, origin, k, A.Length);

            //}


        }

        public static void QuickSort(T[] arr)
        {
            int randomIndex = randy.Next(0, arr.Count());
            T pivot = arr[randomIndex];
        }
    }

}
