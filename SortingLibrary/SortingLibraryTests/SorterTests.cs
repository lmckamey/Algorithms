
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingLibrary;
using System;
using System.Linq;
using System.Text;
namespace UnitTestProject1
{
    [TestClass]
    public class SortingUnitTests
    {
        protected int[] hunRand = new int[100];
        protected int[] hunDesc = new int[100];
        protected int[] hunAsc = new int[100];
        protected string expected;
        public SortingUnitTests()
        {
            Random rand = new Random(12271978);
            for (int i = 0; i < hunRand.Length; i++)
            {
                hunRand[i] = rand.Next(100001);
            }
            //ten = mil.Take(10).ToArray();
            hunDesc = hunRand.OrderByDescending(x => x).ToArray();
            hunAsc = hunRand.OrderBy(x => x).ToArray();
            expected = ArrayToString(hunAsc);
        }
        protected int[] CloneRand
        {
            get { return (int[])hunRand.Clone(); }
        }
        protected int[] CloneDesc
        {
            get { return (int[])hunDesc.Clone(); }
        }
        protected int[] CloneAsc
        {
            get { return (int[])hunAsc.Clone(); }
        }
        protected string ArrayToString(int[] a)
        {
            StringBuilder sb = new StringBuilder();
            if (a.Length > 0)
            {
                sb.Append(a[0]);
                for (int i = 1; i < a.Length; i++)
                {
                    sb.Append(", ");
                    sb.Append(a[i]);
                }
            }
            return sb.ToString();
        }
        [TestMethod]
        public void BubbleSortOnRandomArrayOf100()
        {
            int[] arr = CloneRand;
            Sorter<int>.BubbleSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BubbleSortOnAscendingArrayOf100()
        {
            int[] arr = CloneAsc;
            Sorter<int>.BubbleSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void BubbleSortOnDescendingArrayOf100()
        {
            int[] arr = CloneDesc;
            Sorter<int>.BubbleSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertionSortOnRandomArrayOf100()
        {
            int[] arr = CloneRand;
            Sorter<int>.InsertionSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertionSortOnAscendingArrayOf100()
        {
            int[] arr = CloneAsc;
            Sorter<int>.InsertionSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InsertionSortOnDescendingArrayOf100()
        {
            int[] arr = CloneDesc;
            Sorter<int>.InsertionSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SelectionSortOnRandomArrayOf100()
        {
            int[] arr = CloneRand;
            Sorter<int>.SelectionSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SelectionSortOnAscendingArrayOf100()
        {
            int[] arr = CloneAsc;
            Sorter<int>.SelectionSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SelectionSortOnDescendingArrayOf100()
        {
            int[] arr = CloneDesc;
            Sorter<int>.SelectionSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MergeSortOnRandomArrayOf100()
        {
            int[] arr = CloneRand;
            Sorter<int>.MergeSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MergeSortOnAscendingArrayOf100()
        {
            int[] arr = CloneAsc;
            Sorter<int>.MergeSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MergeSortOnDescendingArrayOf100()
        {
            int[] arr = CloneDesc;
            Sorter<int>.MergeSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void QuickSortOnRandomArrayOf100()
        {
            int[] arr = CloneRand;
            Sorter<int>.QuickSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void QuickSortOnAscendingArrayOf100()
        {
            int[] arr = CloneAsc;
            Sorter<int>.MergeSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void QuickSortOnDescendingArrayOf100()
        {
            int[] arr = CloneDesc;
            Sorter<int>.QuickSort(arr);
            string actual = ArrayToString(arr);
            Assert.AreEqual(expected, actual);
        }
    }
}
