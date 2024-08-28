using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР8._2
{
    internal class Program
    {
        public class Node<T>
        {
            public T Value; // поле Value
            public Node<T> Previous; // ссылка на предыдущий элемент
            public Node<T> Next; // ссылка на следующий элемент
            public int position;
            public Node(T value, Node<T> previous = null, Node<T> next = null, int pos = 0) // конструктор нового элемента
            { Value = value; Previous = previous; Next = next; position = pos; }
        }
        public class DoublyLinkedList<T>
        {
            public int Size; // размер списка
            public Node<T> First; // первый элемент списка
            public Node<T> Last; // последний элемент списка
            public Node<T> this[int position]
            {
                get
                {
                    if (position < Size)
                    {
                        Node<T> Temp = First;
                        for (int i = 0; i < position; ++i)
                            Temp = Temp.Next; // бежим по ссылкам к позиции
                        return Temp;
                    }
                    else
                    {
                        throw new System.IndexOutOfRangeException("Индекс" + position + " вне пределов диапазона списка");
                    }
                }
            }
            public void Add2Begin(T value)
            {
                Node<T> node = new Node<T>(value, null, First, Size);
                if (First == null) { First = node; Last = node; }
                else { First.Previous = node; First = node; }
                Size++;
            }
            public void Add2End(T value)
            {
                Node<T> node = new Node<T>(value, Last, null, Size);
                if (Last == null) { First = node; Last = node; }
                else { Last.Next = node; Last = node; }
                Size++;
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
            public IEnumerable<Node<T>> Iterator2(int init,
            Func<int, int> next, Predicate<int> cond)
            {
                Node<T> Temp = First;
                int count = 0; // счётчик
                if (Size > init)
                    for (; count < init; count++)
                        Temp = Temp.Next; // идём к позиции init
                else
                    yield break;
                while (cond(count))
                {
                    yield return Temp; // возвращаем от init c шагом next
                    int d = next(count); // пока истинно условие cond
                    for (; count < d; count++)
                        if (Temp == null) yield break;
                        else Temp = Temp.Next; // идём к следующей позиции
                }
            }
            public void PrintNodes()
            {
                foreach (Node<T> node in Iterator1())
                    Console.Write(node.Value + " ");
                Console.WriteLine();

            }
            public static IEnumerable<(Node<T>, Node<T>)> Iterator3
            (DoublyLinkedList<T> list1, DoublyLinkedList<T> list2)
            {
                Node<T> Temp1 = list1.First;
                Node<T> Temp2 = list2.First;
                while (Temp1 != null & Temp2 != null) // оба элемента есть
                {
                    yield return (Temp1, Temp2); // возвращаем пару
                    Temp1 = Temp1.Next;
                    Temp2 = Temp2.Next;
                }
            }
        }
        static DoublyLinkedList<int> Merge(DoublyLinkedList<int> a, DoublyLinkedList<int> b)
        {
            var result = new DoublyLinkedList<int>();
            Node<int> temp1 = a.First;
            Node<int> temp2 = b.First;
            while (temp1 != null && temp2 != null)
            {
                if (temp1.Value <= temp2.Value)
                {
                    result.Add2End(temp1.Value);
                    temp1 = temp1.Next;
                }
                else
                {
                    result.Add2End(temp2.Value);
                    temp2 = temp2.Next;
                }
            }
            while (temp1 != null)
            {
                result.Add2End(temp1.Value);
                temp1 = temp1.Next;
            }

            while (temp2 != null)
            {
                result.Add2End(temp2.Value);
                temp2 = temp2.Next;
            }
            return result;
        }
        static DoublyLinkedList<int> MergeSort(DoublyLinkedList<int> m, int left, int right)
        {
            if (left >= right)
            {
                DoublyLinkedList<int> result = new DoublyLinkedList<int>();
                Node<int> temp0 = m.First;
                for (int i = 0; i < left; i++)
                    temp0 = temp0.Next;
                result.Add2End(temp0.Value);
                return result;
            }
            else
            {
                int mid = (left + right) >> 1;
                DoublyLinkedList<int> a = MergeSort(m, left, mid);
                DoublyLinkedList<int> b = MergeSort(m, mid + 1, right);
                return Merge(a, b);
            }
        }
        static void Main(string[] args)
        {
            var lst = new DoublyLinkedList<int>();
            Random rnd = new Random();
            for (int i = 0; i < 70000; i++)
                lst.Add2End(rnd.Next(1, 100));
            //lst.PrintNodes();
            //Console.WriteLine();
            DateTime t1 = DateTime.Now;
            var res = MergeSort(lst, 0, lst.Size-1);
            DateTime t2 = DateTime.Now;
            Console.WriteLine(t2.Subtract(t1).TotalSeconds);
            //res.PrintNodes();
        }
    }
}
