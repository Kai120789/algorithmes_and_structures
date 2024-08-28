using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6._2
{
    internal class Program
    {
        static List<int> Init(int k)
        {
            var res = new List<int>();
            var rnd = new Random();
            for (int i = 0; i < 15; i++)
                res.Add(rnd.Next(-k, k+1));
            return res;
        }
        static List<int> RadixSort(List<int> m, uint p)
        {
            if (m.Count <= 1 || p == 0) return m; // дно рекурсии
            List<int> a = new List<int>(); // объявляем левый список
            List<int> b = new List<int>(); // объявляем правый список
            if (p == 0x80000000) // 2 ^ 31, т.е. бит знака == 1, т.е. проверка на отрицательность (которая сработает 1 раз)
            {
                foreach (int e in m) // разделение списка
                    if ((e & p) == p) a.Add(e); // число в левый список
                    else b.Add(e); // число в правый список
            }
            else
            {
                foreach (int e in m) // разделение списка
                    if ((e & p) == 0) a.Add(e); // число в левый список
                    else b.Add(e); // число в правый список
            }
            
            p >>= 1; // сдвиг маски
            List<int> a1 = RadixSort(a, p); // сортируем левый список
            List<int> b1 = RadixSort(b, p); // сортируем правый список
            foreach (int e in b1)
                a1.Add(e); // соединение списков
            return a1;
        }
        static void Main(string[] args)
        {
            // ПО ИДЕЕ ОНО ОСТАЁТСЯ ТАКИМ ЖЕ ПРИ ЛЮБОЙ РАЗРЯДНОСТИ. МБ ЭТО ИЗ-ЗА ТОГО, ЧТО ПРОЦ ВСЕГДА МАЛЕНЬКИЕ ЧИСЛА ДОДЕЛЫВАЕТ ДО БОЛЬШИХ ФЕКТИВНЫМИ НУЛЯМИ ИЛИ ЕДИНИЦАМИ
            var test = Init(50);
            Console.WriteLine(string.Join(" ", test));
            var t1 = DateTime.Now;
            var test1 = RadixSort(test, 0x80000000);
            var t2 = DateTime.Now;
            Console.WriteLine(string.Join(" ", test1));
            Console.WriteLine(t2.Subtract(t1).TotalMilliseconds);
        }
    }
}
