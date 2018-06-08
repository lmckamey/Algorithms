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

        int counter = 0;

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


        public void Remove(T val)
        {
            if (m_Root != null && Contains(val))
            {
                deleteNode(m_Root, val);
                Count--;
            }
        }

        public void Clear()
        {
            m_Root = null;
            Count = 0;
        }

        public string InOrder()
        {
            counter = 0;
            if (m_Root != null)
                return InOrderStrings(m_Root);
            return "";
        }

        public string PreOrder()
        {
            counter = 0;
            if (m_Root != null)
                return PreOrderStrings(m_Root);
            return "";
        }

        public string PostOrder()
        {
            counter = 0;
            if (m_Root != null)
                return PostOrderStrings(m_Root);
            return "";
        }

        public int Height()
        {
            return (HeightHelp(m_Root));
        }

        public T[] ToArray()
        {
            T[] array;
            int index = 0;
            array = new T[Count];
            if (m_Root != null)
                InOderValues(m_Root, ref index, array);

            return array;
        }

        private Node<T> deleteNode(Node<T> node, T value)
        {
            if (node == null)
                return node;
            //Leaf Case
            if (node.LeftBranch == null && node.RightBranch == null && node.Value.Equals(value))
            {
                node = null;
                return node;
            }

            if (node.LeftBranch != null && value.CompareTo(node.Value) < 0)
                node.LeftBranch = deleteNode(node.LeftBranch, value);
            else if (node.RightBranch != null && value.CompareTo(node.Value) > 0)
                node.RightBranch = deleteNode(node.RightBranch, value);

            else
            {
                if (node.LeftBranch == null)
                {
                    Node<T> temp = node.RightBranch;
                    node = null;
                    return temp;
                }
                else if (node.RightBranch == null)
                {
                    Node<T> temp = node.LeftBranch;
                    node = null;
                    return temp;
                }

                Node<T> temp2 = MinValueNode(node.RightBranch);

                node.Value = temp2.Value;

                node.RightBranch = deleteNode(node.RightBranch, temp2.Value);

            }
            return node;



        }
        private Node<T> MinValueNode(Node<T> node)
        {
            Node<T> currentNode = node;

            while (currentNode.LeftBranch != null)
            {
                currentNode = currentNode.LeftBranch;
            }
            return currentNode;

        }

        private int HeightHelp(Node<T> node)
        {
            if (node == null)
                return 0;
            int h1 = 0;
            int h2 = 0;
            if (node.LeftBranch != null)
                h1 = HeightHelp(node.LeftBranch);
            if (node.RightBranch != null)
                h2 = HeightHelp(node.RightBranch);
            int h = 1 + Math.Max(h1, h2);
            return h;
        }

        private Node<T> InOderValues(Node<T> node, ref int index, T[] array)
        {
            Node<T> temp;
            if (node.LeftBranch != null)
                temp = InOderValues(node.LeftBranch, ref index, array);
            temp = node;
            if (index < Count)
                array[index++] = temp.Value;
            if (node.RightBranch != null)
                temp = InOderValues(node.RightBranch, ref index, array);
            return temp;
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

        private string InOrderStrings(Node<T> node)
        {
            string str = "";
            if (node.LeftBranch != null)
            {
                str += InOrderStrings(node.LeftBranch);
            }
            counter++;
            if (counter == Count)
                str += node.Value;
            else
                str += node.Value + ", ";
            if (node.RightBranch != null)
            {
                str += InOrderStrings(node.RightBranch);
            }
            return str;
        }

        private string PreOrderStrings(Node<T> node)
        {
            string str = "";
            counter++;
            if (counter == Count)
                str += node.Value;
            else
                str += node.Value + ", ";
            if (node.LeftBranch != null)
                str += PreOrderStrings(node.LeftBranch);
            if (node.RightBranch != null)
                str += PreOrderStrings(node.RightBranch);
            return str;

        }

        private string PostOrderStrings(Node<T> node)
        {
            string str = "";
            if (node.LeftBranch != null)
                str += PostOrderStrings(node.LeftBranch);
            if (node.RightBranch != null)
                str += PostOrderStrings(node.RightBranch);

            counter++;
            if (counter == Count)
                str += node.Value;
            else
                str += node.Value + ", ";
            return str;
        }

    }
    public class PQNode
    {
        public int Value { get; set; }
        public int Priority { get; set; }
    }

    public class MaxHeapPriorityQueue
    {
        private PQNode[] heap = new PQNode[10];
        public int Count { get; private set; }
        public int GetHeapSize()
        {
            return heap.Length;
        }
        public PQNode Peek()
        {
            return heap[1];
        }
        public void Enqueue(int priority, int value)
        {
            Count++;
            if (Count > heap.Length - 1)
            {
                PQNode[] tempHeap = new PQNode[heap.Length * 2];
                heap.CopyTo(tempHeap, 0);
                heap = tempHeap;
            }
            PQNode tempNode = new PQNode() { Value = value, Priority = priority };
            heap[Count] = tempNode;

            HeapifiyNodeUp(Count);
        }

        public void HeapifiyNodeUp(int index)
        {
            PQNode parent = heap[index / 2];
            if (parent != null && heap[index].Priority > parent.Priority)
            {
                //swap parent with node
                heap[index / 2] = heap[index];
                heap[index] = parent;
                if (index / 2 != 0)
                    HeapifiyNodeUp(index / 2);
            }
        }
        public void HeapifiyNodeDown(int index)
        {
            int tempIndex;
            if (index * 2 + 1 < heap.Length)
            {
                if (heap[index * 2 + 1] != null)
                {
                    tempIndex = heap[index * 2].Priority > heap[index * 2 + 1].Priority ? index * 2 : index * 2 + 1;
                }
                else
                {
                    tempIndex = index * 2;
                }
                if (heap[tempIndex] != null)
                {
                    if (heap[index].Priority < heap[tempIndex].Priority)
                    {
                        //swap nodes
                        PQNode tempNode = heap[index];
                        heap[index] = heap[tempIndex];
                        heap[tempIndex] = tempNode;
                        HeapifiyNodeDown(tempIndex);
                    }
                }
            }
        }

        public PQNode Dequeue()
        {
            PQNode tempNode = null;
            if (Count >= 1)
            {
                tempNode = heap[1];
                heap[1] = heap[Count];
                heap[Count] = null;
                Count--;
                HeapifiyNodeDown(1);
            }

            return tempNode;
        }

        public override string ToString()
        {
            string str = "";
            if (Count >= 1)
            {
                str += heap[1].Priority + ":" + heap[1].Value;
                for (int i = 2; i < Count; i++)
                {
                    str += ", " + heap[i].Priority + ":" + heap[i].Value;
                }
                if (Count > 1)
                    str += ", " + heap[Count].Priority + ":" + heap[Count].Value;
            }
            return str;
        }

        public PQNode[] ToSortedArray()
        {
            PQNode[] array = new PQNode[Count];
            int i = 0;
            while (Count > 0)
            {
                array[i] = Dequeue();
                i++;
            }
            return array;
        }

    }

}