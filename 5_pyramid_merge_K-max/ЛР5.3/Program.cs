using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР5._3
{
    internal class Program
    {
        static void Heapify(int[] ar, int i, int size)
        {
            int left = (i * 2) + 1;
            int right = (i * 2) + 2;
            int min = i;
            if (left < size && ar[min] > ar[left]) min = left;
            if (right < size && ar[min] > ar[right]) min = right;
            if (min != i)
            {
                (ar[min], ar[i]) = (ar[i], ar[min]);
                Heapify(ar, min, size);
            }
        }
        static int[] Func(int[] ar, int K)
        {
            var res = new int[K]; 
            for (int i = 0; i < ar.Length; i++)
                if (ar[i] > res[0])
                {
                    res[0] = ar[i];
                    Heapify(res, 0, K);
                }
            return res;
        }
        static void Main(string[] args)
        {
            var ar = new int[] { 6, 1, 7, 5, 4, 14, 3, 9, 8, 2, 11, 13 };
            var res = Func(ar, 3);
            Console.WriteLine(string.Join(" ", res));
            Console.ReadKey();
        }
    }
}
