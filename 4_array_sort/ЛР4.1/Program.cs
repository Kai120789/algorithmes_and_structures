using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР4._1
{
    internal class Program
    {
        static uint[] Init(uint n)
        {
            var res = new uint[n];
            for (uint i = 0; i < n; i++)
                res[i] = i+1;
            return res;
        }
        static void Unsort(uint[] ar, int n)
        {
            var ind = new int[ar.Length];
            var rnd = new Random();
            while (true) 
            {
                uint i = (uint)rnd.Next(0, ar.Length);
                uint j = (uint)rnd.Next(0, ar.Length);
                (ar[i], ar[j]) = (ar[j], ar[i]);
                ind[i] = 1;
                ind[j] = 1;
                if (100 - (ind.Count(x => x == 1) * 100 / ar.Length) <= n)
                    break;
            }
        }
        static void Main(string[] args)
        {
            var lst = Init(10);
            Unsort(lst, 50);
            Console.WriteLine(string.Join(" ", lst));
            //var t1 = DateTime.Now;
            //Array.Sort(lst);
            //var t2 = DateTime.Now;
            //Console.WriteLine(t2.Subtract(t1).TotalSeconds);
            Console.ReadKey();
        }
    }
}
