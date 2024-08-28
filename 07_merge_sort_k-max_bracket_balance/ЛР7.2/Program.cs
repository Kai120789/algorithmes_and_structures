using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР7._2
{
    internal class Program
    {
        class Node<T>
        {
            public T Value;
            public Node<T> Next;
            public Node(T value, Node<T> next = null)
            { Value = value; Next = next; }
        }
        class SinglyLinkedList<T>
        {
            public Node<T> First;
            public Node<T> Last;
            public int Size;
            public void Add(T value)
            {
                Node<T> node = new Node<T>(value);
                if (Last == null) { First = node; Last = node; }
                else { Last.Next = node; Last = node; }
                Size++;
            }
            public T Delete(uint position)
            {
                Node<T> Temp = First;
                if (position == 0 & Size == 1)
                {
                    First = null;
                    Last = null;
                    Size--;
                    return Temp.Value;
                }
                if (position == 0 & Size > 1)
                {
                    First = First.Next;
                    Temp.Next = null;
                    Size--;
                    return Temp.Value;
                }
                if (position < Size & Size > 0)
                {
                    for (int i = 0; i < position - 1; i++)
                    {
                        Temp = Temp.Next;
                    }
                    Node<T> DelNode = Temp.Next;
                    Temp.Next = DelNode.Next;
                    DelNode.Next = null;
                    if (position == Size - 1) Last = Temp;
                    Size--;
                    return DelNode.Value;
                }
                else
                {
                    throw new System.IndexOutOfRangeException("Индекс " +
                position + " вне пределов диапазона списка");
                }
            }
            public T this[uint position]
            {
                get
                {
                    if (position < Size)
                    {
                        Node<T> Temp = First;
                        for (int i = 0; i < position; ++i)
                            Temp = Temp.Next;
                        return Temp.Value;
                    }
                    else
                    {
                        throw new System.IndexOutOfRangeException("Индекс" + position + " вне пределов диапазона списка");
                    }
                }
            }
            public void PrintNodes(string Title = "")
            {
                Console.Write(Title + " ");
                Node<T> Temp = First;
                while (Temp != null)
                {
                    Console.Write(" " + Temp.Value);
                    Temp = Temp.Next;
                }
                Console.WriteLine();
            }
        }
        static SinglyLinkedList<int> LstInit(int size)
        {
            SinglyLinkedList<int> lst = new SinglyLinkedList<int>();
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                lst.Add(rnd.Next(1, 100));
            }
            return lst;
        }
        static SinglyLinkedList<int> Merge(SinglyLinkedList<int> a, SinglyLinkedList<int> b)
        {
            SinglyLinkedList<int> result = new SinglyLinkedList<int>();
            Node<int> temp1 = a.First;
            Node<int> temp2 = b.First;
            while (temp1 != null && temp2 != null)
            {
                if (temp1.Value <= temp2.Value)
                {
                    result.Add(temp1.Value);
                    temp1 = temp1.Next;
                }
                else
                {
                    result.Add(temp2.Value);
                    temp2 = temp2.Next;
                }  
            }             
            while (temp1 != null)
            {
                result.Add(temp1.Value);
                temp1 = temp1.Next;
            }
                
            while (temp2 != null)
            {
                result.Add(temp2.Value);
                temp2 = temp2.Next;
            }                
            return result; 
        }
        static SinglyLinkedList<int> MergeSort(SinglyLinkedList<int> m, int left, int right)
        {
            if (left >= right)
            {
                SinglyLinkedList<int> result = new SinglyLinkedList<int>();
                Node<int> temp0 = m.First;
                for(int i = 0; i < left;i++)
                    temp0 = temp0.Next;
                result.Add(temp0.Value);
                return result;
            }
            else
            {
                int mid = (left + right) >> 1; 
                SinglyLinkedList<int> a = MergeSort(m, left, mid); 
                SinglyLinkedList<int> b = MergeSort(m, mid + 1, right); 
                return Merge(a, b); 
            }
        }
        static void Main(string[] args)
        {
            SinglyLinkedList<int> a = LstInit(70000);
            //a.PrintNodes();
            DateTime t1 = DateTime.Now;
            SinglyLinkedList<int> res = MergeSort(a, 0, a.Size-1);
            DateTime t2 = DateTime.Now;
            Console.WriteLine(t2.Subtract(t1).TotalSeconds);
            //res.PrintNodes();
        }
    }
}
