using System;
using System.Collections.Generic;

namespace CodeWarsScratch
{
    class Class1
    {
        static void Main()
        {
            SingleLinkedList<int> test = new SingleLinkedList<int>();
            Console.WriteLine(test.ToString());
            test.Add(0);
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);
            Console.WriteLine(test.ToString());
            //test.Remove();
            //test.Remove();
            //test.Remove();
            //test.Add(1);
            //Console.WriteLine(test.ToString());

            test.Insert(10, 2);
            Console.WriteLine(test.ToString());
            test.Insert(20, 1);
            Console.WriteLine(test.ToString());
            test.Insert(1001, 0);
            Console.WriteLine(test.ToString());
            try
            {
                test.Insert(0110101, 1010);
            }catch(IndexOutOfRangeException)
            {
                Console.WriteLine("OUT OF BOUNDS");
            }
            try
            {
                test.Insert(-10, test.Count);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("OUT OF BOUNDS");
            }


            #region Trycatch
            //Console.WriteLine("REMOVEAT");
            ////try
            ////{
            ////    test.RemoveAt(0);
            ////    Console.WriteLine(test.ToString());
            ////}
            ////catch (IndexOutOfRangeException)
            ////{
            ////    Console.WriteLine("OUT OF BOUNDS!");
            ////}
            ////try
            ////{
            ////    test.RemoveAt(1);
            ////    Console.WriteLine(test.ToString());
            ////}
            ////catch (IndexOutOfRangeException)
            ////{
            ////    Console.WriteLine("OUT OF BOUNDS!");
            ////}
            ////try
            ////{
            ////    test.RemoveAt(10);
            ////    Console.WriteLine(test.ToString());
            ////}
            ////catch (IndexOutOfRangeException)
            ////{
            ////    Console.WriteLine("OUT OF BOUNDS!");
            ////}
            ////try
            ////{
            ////    test.RemoveAt(0);
            ////    Console.WriteLine(test.ToString());
            ////}
            ////catch (IndexOutOfRangeException)
            ////{
            ////    Console.WriteLine("OUT OF BOUNDS!");
            ////}
            #endregion


        }
    }
    public class SingleLinkedList<T>
    {
        public class Node<T>
        {
            public Node<T> m_next;
            public T m_value;
        }

        private Node<T> m_head = null;
        private Node<T> m_tail = null;

        public int Count { get; set; }

        public void Add(T val)
        {
            Node<T> tempnode = new Node<T>
            {
                m_value = val
            };

            if (m_head == null)
            {
                m_head = tempnode;
                m_tail = tempnode;
            }
            else
            {
                m_tail.m_next = tempnode;
                m_tail = tempnode;
            }
            Count++;
        }

        public void Insert(T val, int index)
        {

            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                Node<T> tempNode = new Node<T> { m_value = val, m_next = m_head };
                m_head = tempNode;
            }
            else
            {
                Node<T> currentNode = m_head;
                Node<T> previousNode = null;
                for (int i = 0; i < index; i++)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.m_next;
                }
                Node<T> tempNode = new Node<T> { m_value = val, m_next = currentNode };
                previousNode.m_next = tempNode;
            }
            Count++;
        }

        public T Get(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Node<T> currentNode = m_head;
            for (int i = 1; i < index; i++)
            {
                currentNode = currentNode.m_next;
            }
            return currentNode.m_value;
        }

        public T Remove()
        {
            m_head = m_head.m_next;
            return m_head.m_value;
        }

        public T RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                Node<T> tempNode = new Node<T>();
                m_head = tempNode;
            }
            else
            {
                Node<T> currentNode = m_head;
                Node<T> previousNode = null;
                for (int i = 0; i < index; i++)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.m_next;
                }
                Node<T> tempNode = new Node<T>();
                previousNode.m_next = tempNode;
            }
        }

        public T RemoveLast()
        {
            Node<T> currentNode = m_head;
            for (int i = 0; i < Count - 2; i++)
            {
                currentNode = currentNode.m_next;
            }
            currentNode.m_next = null;
            m_tail = currentNode;
            if (Count > 0)
            {
                Count--;
            }
            return currentNode.m_value;
        }

        public void Clear()
        {
            m_head = null;
            m_tail = null;
            Count = 0;
        }

        public int Search(T val)
        {
            Node<T> currentNode = m_head;
            int index = -1;
            for (int i = 1; i < Count; i++)
            {
                currentNode = currentNode.m_next;
                if(currentNode.m_value.Equals(val))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public override string ToString()
        {
            string LLstring = "";
            if (Count > 0)
            {
                Node<T> currentNode = m_head;
                LLstring += m_head.m_value.ToString() + ", ";
                for (int i = 1; i < Count; i++)
                {
                    currentNode = currentNode.m_next;
                    LLstring += currentNode.m_value.ToString() + ", ";
                }
            }
            return LLstring;
        }

    }

}

