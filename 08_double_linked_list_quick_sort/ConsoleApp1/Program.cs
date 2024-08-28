using System;
using System.Collections.Generic;

namespace ConsoleApp35
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = LstInit(5);
            lst.PrintNodes();

            // Из одного два
            //var a = new DoublyLinkedList<int>();
            //var b = new DoublyLinkedList<int>();
            //(a,b) = DoublyLinkedList<int>.One2Two(lst, 5);
            //a.PrintNodes();
            //b.PrintNodes();

            // Из двух один
            //var lst1 = LstInit(5);
            //lst1.PrintNodes();
            //var z = DoublyLinkedList<int>.Two2One(lst, lst1);
            //z.PrintNodes();

            // Из одного два по значению
            //var (lst2, lst3) = DoublyLinkedList<int>.ValOne2Two(lst, 5);
            //lst2.PrintNodes();
            //lst3.PrintNodes();

            //Итератор
            //var e = lst.Iterator();
            //foreach (var c in e)
            //    Console.Write(c.Value + " ");
            //Console.ReadLine();

            // Итератор2
            //var en = lst.Iterator2(5, 15, 3);
            //foreach(var c in en)
            //    Console.Write(c.Value + " ");
            //Console.ReadLine();
        }
        public class Node<T>
        {
            public T Value; // поле Value
            public Node<T> Previous; // ссылка на предыдущий элемент

            public Node<T> Next; // ссылка на следующий элемент
            public Node(T value, Node<T> previous = null, Node<T> next =
            null) // конструктор нового элемента
            { Value = value; Previous = previous; Next = next; }
        }
        class DoublyLinkedList<T>
        {
            public int Size; // размер списка
            public Node<T> First; // первый элемент списка  
            public Node<T> Last; // последний элемент списка
            public static (DoublyLinkedList<int>, DoublyLinkedList<int>) ValOne2Two(DoublyLinkedList<int> m, int val)
            {
                var a = new DoublyLinkedList<int>();
                var b = new DoublyLinkedList<int>();

                var t = m.First;
                while ((t != null) && (t.Value != val))
                {
                    a.Add2End(t.Value);
                    t = t.Next;
                }
                while (t != null)
                {
                    b.Add2End(t.Value);
                    t = t.Next;
                }
                return (a, b);
            }
            public static (DoublyLinkedList<T>, DoublyLinkedList<T>) One2Two<T>(DoublyLinkedList<T> m, uint n)
            {
                var a = new DoublyLinkedList<T>();
                var b = new DoublyLinkedList<T>();

                var t = m.First;
                for (int i = 0; i < n; i++) { a.Add2End(t.Value); t = t.Next; }
                while (t != null) { b.Add2End(t.Value); t = t.Next; }
                return (a, b);
            }
            public static DoublyLinkedList<T> Two2One<T>(DoublyLinkedList<T> m, DoublyLinkedList<T> w)
            {
                var a = new DoublyLinkedList<T>();
                var t = m.First;

                while (t != null)
                {
                    a.Add2End(t.Value);
                    t = t.Next;
                }
                t = w.First;
                while (t != null)
                {
                    a.Add2End(t.Value);
                    t = t.Next;
                }
                return a;
            }
            public void Add2Begin(T value)
            {
                Node<T> node = new Node<T>(value, null, First);
                if (First == null) { First = node; Last = node; }
                else { First.Previous = node; First = node; }
                Size++;
            }
            public void Add2End(T value)
            {
                Node<T> node = new Node<T>(value, Last, null);
                if (Last == null) { First = node; Last = node; }
                else { Last.Next = node; Last = node; }
                Size++;
            }
            public IEnumerable<Node<T>> Iterator()
            {
                Node<T> Temp = Last;
                while (Temp != null)
                {
                    yield return Temp;
                    Temp = Temp.Previous;
                }
            }
            public IEnumerable<Node<T>> Iterator1()
            {
                Node<T> Temp = First;
                while (Temp != null)
                {
                    yield return Temp;
                    Temp = Temp.Next;
                }
            }
            public IEnumerable<Node<T>> Iterator2(uint from, uint to, int step)
            {
                Node<T> Temp = First;
                if (Size > from && from < to)
                    for (int i = 0; i < from; i++)
                        Temp = Temp.Next; // идём к позиции from
                else
                    yield break;
                for (int i = 0; i < to - from + 1; i += step)
                {
                    yield return Temp; // возвращаем все от from до to
                    for (int j = 0; j < step; j++)
                        if (Temp != null)
                            Temp = Temp.Next;

                    if (Temp == null) yield break;
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
        static DoublyLinkedList<int> LstInit(int size)
        {
            DoublyLinkedList<int> lst = new DoublyLinkedList<int>();
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                lst.Add2End(rnd.Next(0, 30));
            }
            return lst;
        }
    }
}
