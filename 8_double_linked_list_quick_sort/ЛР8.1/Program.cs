using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР8._1
{
    internal class Program
    {
        class NDLL
        {
            public int value;
            public NDLL next;
            public NDLL previous;
            public NDLL(int value, NDLL next = null, NDLL previous = null)
            { this.value = value; this.next = next; this.previous = previous; }
        }
        // двусвязный список
        class DLL
        {
            public int size;
            public NDLL first;
            public NDLL last;
            public DLL(int size)
            {
                var rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    var node = new NDLL(rnd.Next(1, 51));
                    Add2End(node);
                }
            }
            public void Add2End(NDLL node)
            {
                if (first == null) { first = node; last = node; size++; }
                else { last.next = node; node.previous = last; last = node; size++; }
            }
            public void Add2End(int value)
            {
                var node = new NDLL(value);
                if (first == null) { first = node; last = node; size++; }
                else { last.next = node; node.previous = last; last = node; size++; }
            }
            public void Print(string s = "")
            {
                var temp = first;
                Console.Write(s + " ");
                while (temp != null)
                { Console.Write(temp.value + " "); temp = temp.next; }
                Console.WriteLine();
            }
            public static void QuickSort(DLL lst)
            {
                QuickSort(lst.first, lst.last);
            }
            private static void QuickSort(NDLL low, NDLL high)
            {
                if (low == high) return;    // 1 элемент
                if (low.next == high)   // 2 элемента
                {
                    if (low.value > high.value)
                        (low.value, high.value) = (high.value, low.value);
                    return;
                }
                var t1 = low; var t2 = high;
                while (true) // поиск центрального элемента
                {
                    t2 = t2.previous;
                    if (t2 == t1) break;
                    t1 = t1.next;
                    if (t2 == t1) break;
                }
                int x = t2.value;
                t1 = low; t2 = high;
                bool f = true;  // флаг встречи поисковых node
                do
                {
                    while (t1.value < x)
                    { t1 = t1.next; if (t1 == t2) f = false; }
                    while (t2.value > x)
                    { t2 = t2.previous; if (t1 == t2) f = false; }
                    if (f)
                    {
                        (t1.value, t2.value) = (t2.value, t1.value);
                        t1 = t1.next; t2 = t2.previous;
                        if (t1 == t2 || t2.next == t1) f = false;
                    }
                } while (f);
                QuickSort(low, t2);
                QuickSort(t1, high);
            }
        }
        static void Main(string[] args)
        {
            var lst = new DLL(10);
            lst.Print();
            DLL.QuickSort(lst);
            lst.Print();
        }    
    }
}
