using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР16._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ushort n = ushort.Parse(Console.ReadLine());
            ulong x = 0xF18A6ECFD39F1D57; // рандомная битовая последовательность (здесь мы использовали все 64 бита)
            ulong[] ar = new ulong[64 / n]; // делим входную последовательность на равные отрезки

            for (int i = 0; i < ar.Length; i++)
            {
                ulong mask = (ulong)Math.Pow(2, n) - 1;  // берет n первых (справа) битов у x
                ulong x0 = x & mask;
                x >>= n; // сдвигаем x
                ulong h;
                if (i == 0)
                {
                    h = 7 * 16777619; // 7 , 16777619 - произвольные простые числа
                    h &= (ulong)Math.Pow(2, n) - 1;
                    h ^= x0;
                    ar[i] = h;
                }
                else
                {
                    h = ar[i - 1] * 16777619;
                    h &= (ulong)Math.Pow(2, n) - 1;
                    h ^= x0;
                    ar[i] = h;
                }
            }

            foreach (var z in ar)
                Console.WriteLine(z + " ");
            Console.ReadLine();
        }
    }
}
