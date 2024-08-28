using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6._1
{
    internal class Program
    {
        static void CountingSort(int[] m)
        {
            int max = m.Max(); // макс. элемент
            int min = m.Min(); // мин. элемент
            int k = max - min + 1; // нужное количество счётчиков
            int[] len = new[] { k }; // массив длин
            int[] minInd = new[] { min };
            // массив счётчиков:
            var counter = Array.CreateInstance(typeof(int), len, minInd);
            for (int i = 0; i < m.Length; i++) // цикл по массиву m
            {
                int v = (int)counter.GetValue(m[i]); // читаем счётчик
                counter.SetValue(v + 1, m[i]); // инкремент счётчика
            }
            int p = 0; // индекс элементов массива m
            for (int item = min; item <= max; item++) // цикл по счётчикам
            {
                int e = (int)counter.GetValue(item); // читаем счётчик
                for (int j = 0; j < e; j++) // если счётчик > 0
                    m[p++] = item; // модифицируем массив m
            }
        }
        static int[] Init(int k)
        {
            var res = new int[1000000];
            var rnd = new Random();
            for (int i = 0; i < res.Length; i++)
                res[i] = rnd.Next(-k, k);
            return res;
        }
        static void Main(string[] args)
        {
            var test1 = Init(100);
            var test2 = new int[1000000];
            test1.CopyTo(test2, 0);

            var t1 = DateTime.Now;
            Array.Sort(test1);
            var t2 = DateTime.Now;
            Console.WriteLine($"Array.Sort: {t2.Subtract(t1).TotalSeconds}");

            var t3 = DateTime.Now;
            CountingSort(test2);
            var t4 = DateTime.Now;
            Console.WriteLine($"CountingSort: {t4.Subtract(t3).TotalSeconds}");
            Console.ReadKey();
        }
    }
}
