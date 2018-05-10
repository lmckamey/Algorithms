using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructures
{

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

        public void Remove()
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
        }

        public void RemoveAt(int index)
        {
            if (index >= Count || Count == 0 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Count--;
        }

        public void Clear()
        {
            m_head = null;
            m_tail = null;
            Count = 0;
        }

        public void Search(T val)
        {

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
    public class DoubleLinkedList<T>
    {
        public class Node<T>
        {
            public Node<T> m_next;
            public T m_value;
        }
        public int Count { get; set; }
        public void Add(T val)
        {

        }

        public void Insert(T val, int index)
        {

        }

        public T Get()
        {
            return default(T);
        }

        public void Remove()
        {

        }

        public void RemoveAt(int index)
        {

        }

        public void Clear()
        {

        }

        public void Search(T val)
        {

        }
    }

}
