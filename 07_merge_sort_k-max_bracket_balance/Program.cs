using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР7
{
    class Program
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
            public void PrintNodes(string Title)
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
        static void PrintArr(int[] arr)
        {
            foreach(int i in arr)
                Console.Write(i + " ");
        }
        static SinglyLinkedList<int> LstInit(int size)
        {
            SinglyLinkedList<int> lst = new SinglyLinkedList<int>();
            Random rnd = new Random();
            for (int i = 0;i < size; i++)
            {          
                lst.Add(rnd.Next(1, 13));
            }
            return lst;
        }
        static int[] Func(SinglyLinkedList<int> lst, int k)
        {
            int[] res = new int[k]; // иниц. результата
            Node<int> temp = lst.First; // первый элемент списка
            while (temp != null) 
            {
                for (int i = 0; i < k; i++) // Пробег по массиву результата
                    if (temp.Value > res[i]) // сравниваем значение с элементами результата 
                    {
                        res[i] = temp.Value;
                        break;
                    }
                temp = temp.Next; // идём дальше по списку
                Array.Sort(res); // сортируем результат
            }
            return res;
        }
        static void Main(string[] args)
        {
            SinglyLinkedList<int> lst = LstInit(8); // инициализация списка
            lst.PrintNodes("Исходный список:");
            Console.Write("Введите k: ");
            int.TryParse(Console.ReadLine(), out int k);
            int[] res = Func(lst, k); // массив результата
            PrintArr(res); // вывод результата
        }
    }
}
            
 
