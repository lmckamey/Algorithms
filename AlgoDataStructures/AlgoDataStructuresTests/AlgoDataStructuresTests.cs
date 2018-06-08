using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoDataStructures;
using System.Text;
using System.Collections.Generic;
namespace Test
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void SLL_EmptyList()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            int expectedCount = 0;
            int actualCount = list.Count;
            string expectedString = "";
            string actualString = list.ToString();
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void SLL_Methods()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Insert(1, 0);
            var count = list.Count;
            var value = list.Get(0);
            var removed = list.Remove();
            var last = list.RemoveLast();
            var listString = list.ToString();
            list.Clear();
            var index = list.Search(1);
        }

        [TestMethod]

        public void SLL_REMOVEONE()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Remove();
            Assert.AreEqual("", list.ToString());
        }

        [TestMethod]

        public void SLL_TENREMOVE()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            list.Remove();

            Assert.AreEqual("2, 3, 4, 5, 6, 7, 8, 9, 10", list.ToString());
        }

        [TestMethod]

        public void SLL_TENREMOVEALL()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            list.Remove();
            Assert.AreEqual("", list.ToString());
        }
        [TestMethod]

        public void SLL_TENCLEAR()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            list.Clear();
            Assert.AreEqual("", list.ToString());
        }

        [TestMethod]

        public void SLL_TENGETAT0()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            Assert.AreEqual(1, list.Get(0));
        }

        [TestMethod]

        public void SLL_TENGETAT5()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            Assert.AreEqual(6, list.Get(5));
        }

        [TestMethod]

        public void SLL_TENGETAT9()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            Assert.AreEqual(10, list.Get(9));
        }

        [TestMethod]
        public void SLL_TENREMOVEAT0()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            list.RemoveAt(0);
            Assert.AreEqual("2, 3, 4, 5, 6, 7, 8, 9, 10", list.ToString());
        }

        [TestMethod]
        public void SLL_TENREMOVEAT5()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            list.RemoveAt(5);
            Assert.AreEqual("1, 2, 3, 4, 5, 7, 8, 9, 10", list.ToString());
        }

        [TestMethod]
        public void SLL_TENREMOVEAT9()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            list.RemoveAt(9);
            Assert.AreEqual("1, 2, 3, 4, 5, 6, 7, 8, 9", list.ToString());
        }

        [TestMethod]
        public void SLL_RemoveThenAdd()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Remove();
            list.Add(1);
            Assert.AreEqual("1", list.ToString());
        }

        [TestMethod]
        public void SLL_SearchForValueAtHead()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();
            list.Add(10);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            Assert.AreEqual(0, list.Search(10));
        }

        [TestMethod]
        public void DLL_EmptyList()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            int expectedCount = 0;
            int actualCount = list.Count;
            string expectedString = "";
            string actualString = list.ToString();
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }
        [TestMethod]
        public void DLL_Methods()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Insert(1, 0);
            var count = list.Count;
            var value = list.Get(0);
            var removed = list.Remove();
            var last = list.RemoveLast();
            var listString = list.ToString();
            list.Clear();
            var index = list.Search(1);
        }

        [TestMethod]
        public void DLL_ListOfOne_Remove()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(24);
            int expectedReturn = 24;
            int expectedCount = 0;
            string expectedString = "";

            int actualReturn = list.Remove();
            int actualCount = list.Count;
            string actualString = list.ToString();

            Assert.AreEqual(expectedReturn, actualReturn);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]

        public void DLL_ADD()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            Assert.AreEqual("1", list.ToString());
        }


        [TestMethod]

        public void DLL_REMOVEONE()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Add(1);
            list.Remove();
            Assert.AreEqual("", list.ToString());
        }

    }

    [TestClass]

    public class TreeTests
    {
        [TestMethod]
        public void CanGetYourBst()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.Add(1);
            bst.Contains(1);
            bst.Remove(1);
            bst.Clear();
            bst.InOrder();
            bst.PreOrder();
            bst.PostOrder();
            bst.Height();
            bst.ToArray();

            Assert.IsNotNull(bst);
        }

        [TestMethod]
        public void BSTAdd()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Add(10);
            tree.Add(11);
            tree.Add(9);
            tree.Add(5);
            tree.Add(21);
            tree.Add(15);
            tree.Add(6);
            tree.Add(1);

            Assert.IsNotNull(tree);
        }

        [TestMethod]
        public void BSTContains()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();


            tree.Add(15);
            tree.Add(20);
            tree.Add(10);
            tree.Add(12);
            tree.Add(13);
            tree.Add(145);
            tree.Add(60);
            tree.Add(1);

            Assert.IsTrue(tree.Contains(1));
        }

        [TestMethod]
        public void BSTDoesNotContain()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();


            tree.Add(15);
            tree.Add(20);
            tree.Add(10);
            tree.Add(12);
            tree.Add(13);
            tree.Add(145);
            tree.Add(60);
            tree.Add(1);

            Assert.IsFalse(tree.Contains(12381347));
        }

        [TestMethod]
        public void BSTClear()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();


            tree.Add(15);
            tree.Add(20);
            tree.Add(10);
            tree.Add(12);
            tree.Add(13);
            tree.Add(145);
            tree.Add(60);
            tree.Add(1);

            tree.Clear();

            Assert.IsNotNull(tree);
            Assert.AreEqual(tree.Count, 0);
        }

        [TestMethod]
        public void BSTHeightOf4()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();


            tree.Add(15);
            tree.Add(20);
            tree.Add(10);
            tree.Add(12);
            tree.Add(13);
            tree.Add(145);
            tree.Add(60);
            tree.Add(1);

            int num = tree.Height();

            Assert.AreEqual(4, num);
        }

        [TestMethod]
        public void BSTDeleteLeaf()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();


            tree.Add(15);
            tree.Add(20);
            tree.Add(10);
            tree.Add(12);
            tree.Add(13);
            tree.Add(145);
            tree.Add(60);
            tree.Add(1);

            tree.Remove(60);
            Assert.AreEqual("1, 10, 12, 13, 15, 20, 145", tree.InOrder());
        }

        [TestMethod]
        public void BSTDeleteWithTwoBranches()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();


            tree.Add(15);
            tree.Add(20);
            tree.Add(10);
            tree.Add(12);
            tree.Add(13);
            tree.Add(145);
            tree.Add(60);
            tree.Add(1);

            tree.Remove(10);
            Assert.AreEqual("1, 12, 13, 15, 20, 60, 145", tree.InOrder());
        }


        [TestMethod]
        public void BSTDeleteWithOneBranch()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();


            tree.Add(15);
            tree.Add(20);
            tree.Add(10);
            tree.Add(12);
            tree.Add(13);
            tree.Add(145);
            tree.Add(60);
            tree.Add(1);

            tree.Remove(20);
            Assert.AreEqual("1, 10, 12, 13, 15, 60, 145", tree.InOrder());
        }


        [TestMethod]
        public void BSTDeleteRoot()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();


            tree.Add(15);
            tree.Add(20);
            tree.Add(10);
            tree.Add(12);
            tree.Add(13);
            tree.Add(145);
            tree.Add(60);
            tree.Add(1);

            tree.Remove(15);
            Assert.AreEqual("1, 10, 12, 13, 20, 60, 145", tree.InOrder());
        }


        [TestMethod]
        public void BSTHeightOf1()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Add(15);

            int num = tree.Height();

            Assert.AreEqual(1, num);
        }

        [TestMethod]
        public void BSTHeightOf0()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            int num = tree.Height();

            Assert.AreEqual(0, num);
        }

        [TestMethod]
        public void BSTInOrderString()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Add(10);
            tree.Add(7);
            tree.Add(3);
            tree.Add(8);
            tree.Add(12);
            tree.Add(11);

            string list = tree.InOrder();
            Assert.AreEqual("3, 7, 8, 10, 11, 12", list);
        }

        [TestMethod]
        public void BSTPreOrderString()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Add(10);
            tree.Add(7);
            tree.Add(3);
            tree.Add(8);
            tree.Add(12);
            tree.Add(11);

            string list = tree.PreOrder();
            Assert.AreEqual("10, 7, 3, 8, 12, 11", list);
        }

        [TestMethod]
        public void BSTPostOrderString()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Add(10);
            tree.Add(7);
            tree.Add(3);
            tree.Add(8);
            tree.Add(12);
            tree.Add(11);

            string list = tree.PostOrder();
            Assert.AreEqual("3, 8, 7, 11, 12, 10", list);
        }


        [TestMethod]
        public void BSTToArray()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Add(10);
            tree.Add(7);
            tree.Add(3);
            tree.Add(8);
            tree.Add(12);
            tree.Add(11);

            var array = tree.ToArray();

            string thingy = "";

            foreach (var item in array)
            {
                thingy += item + ", ";
            }

            Assert.AreEqual("3, 7, 8, 10, 11, 12, ", thingy);
        }
    }
    [TestClass]
    public class PriorityQueueUnitTest
    {
        #region Tests

        [TestMethod]
        public void PriorotyQueue_MethodsExist()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            pq.Enqueue(10, 1);
            pq.Dequeue();
            pq.Peek();
            pq.ToSortedArray();
            pq.ToString();
            int num = pq.Count;
            Assert.IsNotNull(pq);
        }
        [TestMethod]
        public void PriorotyQueue_HeapDoublesInSize()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            for (int i = 0; i < 11; i++)
            {
                pq.Enqueue(10, i);
            }

            Assert.AreEqual(20, pq.GetHeapSize());

        }
        [TestMethod]
        public void PriorotyQueue_CountIsCorrectAfterSingleAdd()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            pq.Enqueue(10, 1);

            Assert.AreEqual(1, pq.Count);

        }
        [TestMethod]
        public void PriorotyQueue_CountIsCorrectAfterSingleRemove()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            pq.Enqueue(10, 1);
            pq.Dequeue();

            Assert.AreEqual(0, pq.Count);
        }
        [TestMethod]
        public void PriorotyQueue_CountIsCorrectAfterAddRemoveAdd()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            pq.Enqueue(10, 1);
            pq.Dequeue();
            pq.Enqueue(10, 1);

            Assert.AreEqual(1, pq.Count);
        }
        [TestMethod]
        public void PriorotyQueue_CountIsUnchagedAfterPeek()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            pq.Enqueue(10, 1);

            PQNode peek = pq.Peek();

            Assert.AreEqual(1, pq.Count);
        }
        [TestMethod]
        public void PriorotyQueue_CountIsZeroForNewPQ()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();

            Assert.AreEqual(0, pq.Count);
        }
        //Dequeue
        [TestMethod]
        public void PriorotyQueue_DequeueSingleNodePQ()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();

            for (int i = 0; i < 5; i++)
            {
                pq.Enqueue(i * 10, i);
            }

            PQNode dequeueNode = pq.Dequeue();

            Assert.AreEqual(40, dequeueNode.Priority);
        }
        [TestMethod]
        public void PriorotyQueue_DequeueFullTreeToEmpty()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();

            for (int i = 0; i < 13; i++)
            {
                pq.Enqueue(i * 10, i);
            }

            for (int i = 0; i < 16; i++)
            {
                pq.Dequeue();
            }
            Assert.AreEqual(0, pq.Count);
            Assert.AreEqual("", pq.ToString());

        }

        [TestMethod]
        public void DequeueFullTreeToEmpty()
        {
            MaxHeapPriorityQueue pq = CreateThirteenNodePQDescending();
            for (int i = 0; i < 13; i++)
            {
                pq.Dequeue();
            }

            int expectedCount = 0;
            int actualCount = pq.Count;
            string expectedString = "";
            string actualString = pq.ToString();

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedString, actualString);
        }

        private MaxHeapPriorityQueue CreateThirteenNodePQDescending()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            pq.Enqueue(13, 10);
            pq.Enqueue(12, 20);
            pq.Enqueue(11, 30);
            pq.Enqueue(10, 40);
            pq.Enqueue(9, 50);
            pq.Enqueue(8, 60);
            pq.Enqueue(7, 70);
            pq.Enqueue(6, 80);
            pq.Enqueue(5, 90);
            pq.Enqueue(4, 100);
            pq.Enqueue(3, 110);
            pq.Enqueue(2, 120);
            pq.Enqueue(1, 130);

            return pq;
        }
        //Peek
        [TestMethod]
        public void PriorotyQueue_PeekSingleNodePQ()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();

            pq.Enqueue(0, 0);

            Assert.AreEqual(0, pq.Peek().Priority);
        }
        [TestMethod]
        public void PriorotyQueue_PeekThreeNodePQ()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            for (int i = 0; i < 3; i++)
            {
                pq.Enqueue(i * 10, i);
            }

            Assert.AreEqual(20, pq.Peek().Priority);
        }
        [TestMethod]
        public void PriorotyQueue_PeekThirteenNodePQ()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            for (int i = 0; i < 13; i++)
            {
                pq.Enqueue(i * 10, i);
            }

            Assert.AreEqual(120, pq.Peek().Priority);
        }
        //ToString
        [TestMethod]
        public void PriorotyQueue_ToStringSingleNodePQ()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            pq.Enqueue(0, 0);

            Assert.AreEqual("0:0", pq.ToString());
        }

        [TestMethod]
        public void PriorotyQueue_ToStringFourNodesPQ()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            pq.Enqueue(0, 0);
            pq.Enqueue(10, 0);
            pq.Enqueue(20, 0);
            pq.Enqueue(30, 0);

            Assert.AreEqual("30:0, 20:0, 10:0, 0:0", pq.ToString());
        }


        //ToSortedArray


        [TestMethod]
        public void PriorotyQueue_ToSortedArrayFourNodes()
        {
            MaxHeapPriorityQueue pq = new MaxHeapPriorityQueue();
            pq.Enqueue(0, 0);
            pq.Enqueue(10, 0);
            pq.Enqueue(20, 0);
            pq.Enqueue(30, 0);

            PQNode[] array = pq.ToSortedArray();
            string str = "";
            foreach (var item in array)
            {
                str += item.Priority + ":" + item.Value+  ", ";
            }

            Assert.AreEqual("30:0, 20:0, 10:0, 0:0, ", str);
        }

        #endregion
    }

}
