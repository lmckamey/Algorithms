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
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.m_next;
            }
            return currentNode.m_value;
        }
        public T Remove()
        {
            if (m_head != null)
            {
                T value = m_head.m_value;
                if (m_head.m_next != null)
                {
                    m_head = m_head.m_next;
                }
                else
                {
                    m_head = null;
                }
                Count--;
                return value;
            }
            return default(T);
        }

        public T RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            T value = default(T);
            if (index == 0)
            {
                value = m_head.m_value;
                Remove();
            }
            else if (index == Count - 1)
            {
                value = m_tail.m_value;
                RemoveLast();
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
                previousNode.m_next = currentNode.m_next;
                value = currentNode.m_value;
                Count--;
            }
            return value;
        }

        public T RemoveLast()
        {
            Node<T> currentNode = m_head;
            T value = m_tail.m_value;
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
            return value;
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
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.m_value.Equals(val))
                {
                    index = i;
                    break;
                }
                currentNode = currentNode.m_next;
            }
            return index;
        }

        public override string ToString()
        {
            string LLstring = "";
            if (Count > 0)
            {
                if (Count > 1)
                {
                    Node<T> currentNode = m_head;
                    LLstring += m_head.m_value.ToString() + ", ";
                    for (int i = 1; i < Count - 1; i++)
                    {
                        currentNode = currentNode.m_next;
                        LLstring += currentNode.m_value.ToString() + ", ";
                    }
                }
                LLstring += m_tail.m_value.ToString();
            }
            return LLstring;
        }

    }
    public class DoubleLinkedList<T>
    {
        public class Node<T>
        {
            public Node<T> m_next;
            public Node<T> m_prev;
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
                tempnode.m_prev = m_tail;
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
                Node<T> tempNode = new Node<T> { m_value = val, m_next = currentNode, m_prev = previousNode };
                currentNode.m_prev = tempNode;
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
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.m_next;
            }
            return currentNode.m_value;
        }

        public T Remove()
        {
            if (m_head != null)
            {
                T value = m_head.m_value;
                if (m_head.m_next != null)
                {
                    m_head = m_head.m_next;
                }
                else
                {
                    m_head = null;
                }
                Count--;
                return value;
            }
            return default(T);
        }

        public T RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            T value = default(T);
            if (index == 0)
            {
                value = m_head.m_value;
                Remove();
            }
            else if (index == Count - 1)
            {
                value = m_tail.m_value;
                RemoveLast();
            }
            else
            {
                Node<T> currentNode = m_head;
                Node<T> previousNode = null;
                if (index >= Count / 2)
                {
                    for (int i = index; i > 0; i--)
                    {
                        previousNode = currentNode;
                        currentNode = currentNode.m_next;
                    }
                    previousNode.m_next = currentNode.m_next;
                    value = currentNode.m_value;
                }
                else
                {
                    for (int i = 0; i < index; i++)
                    {
                        previousNode = currentNode;
                        currentNode = currentNode.m_next;
                    }
                    previousNode.m_next = currentNode.m_next;
                    value = currentNode.m_value;
                }
                Count--;
            }
            return value;
        }

        public T RemoveLast()
        {
            T value = m_tail.m_value;
            if (m_tail.m_prev != null)
            {
                m_tail = m_tail.m_prev;
            }
            Count--;
            return value;
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
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.m_value.Equals(val))
                {
                    index = i;
                    break;
                }
                currentNode = currentNode.m_next;
            }
            return index;
        }

        public override string ToString()
        {
            string LLstring = "";
            if (Count > 0)
            {
                if (Count > 1)
                {
                    Node<T> currentNode = m_head;
                    LLstring += m_head.m_value.ToString() + ", ";
                    for (int i = 1; i < Count - 1; i++)
                    {
                        currentNode = currentNode.m_next;
                        LLstring += currentNode.m_value.ToString() + ", ";
                    }
                }
                LLstring += m_tail.m_value.ToString();
            }
            return LLstring;
        }
    }
    public class BinarySearchTree<T> where T : IComparable
    {
        public class Node<T>
        {
            public Node<T> LeftBranch { get; set; }
            public Node<T> RightBranch { get; set; }

            public T Value { get; set; }

        }

        Node<T> m_Root;

        public int Count { get; set; }

        public void Add(T val)
        {
            if (m_Root == null)
            {
                m_Root = InsertNode(m_Root, val);
            }
            else
            {
                InsertNode(m_Root, val);
            }
            Count++;
        }

        private Node<T> InsertNode(Node<T> currentNode, T value)
        {
            if (currentNode == null)
                currentNode = new Node<T> { Value = value };

            else if (currentNode.Value.CompareTo(value) <= 0)
            {
                currentNode.RightBranch = InsertNode(currentNode.RightBranch, value);
            }
            else
            {
                currentNode.LeftBranch = InsertNode(currentNode.LeftBranch, value);
            }

            return currentNode;

        }

        public bool Contains(T val)
        {
            Node<T> temp = Search(m_Root, val);
            if (temp != null)
            {
                if (temp.Value.Equals(val))
                    return true;
            }
            return false;
        }

        private Node<T> Search(Node<T> node, T val)
        {
            if (node == null || node.Value.Equals(val))
                return node;
            if (node.Value.CompareTo(val) > 0)
            {
                return Search(node.LeftBranch, val);
            }
            return Search(node.RightBranch, val);
        }

        public void Remove(T val)
        {
            Node<T> node = null;
            if (m_Root != null)
            {
                node = Search(m_Root, val);
            }
            if (node != null)
            {

            }
        }

        public void Clear()
        {
            m_Root = null;
            Count = 0;
        }

        public string InOrder()
        {
            return "";
        }

        public string PreOrder()
        {
            return "";
        }

        public string PostOrder()
        {
            return "";
        }

        public int Height()
        {
            Node<T> currentNode = m_Root;
            int num = 1;
            Node<T> prevNode = null;
            while (currentNode != null)
            {
                if (currentNode.LeftBranch != null)
                {
                    prevNode = currentNode;
                    num++;
                    currentNode = currentNode.LeftBranch;
                }
                else if (currentNode.RightBranch != null)
                {
                    prevNode = currentNode;
                    num++;
                    currentNode = currentNode.RightBranch;
                }
                else
                    currentNode = null;
            }
            return num;
        }

        public T[] ToArray()
        {
            int index = 0;
            T[] array = new T[Count];
            Node<T> currentNode = m_Root;

            while(currentNode !=  null)
            {

            }



            return array;
        }

        private Node<T> inOrderNodes(Node<T> node)
        {
            if (node == null)
                return node;
            return node;
        }

    }

}