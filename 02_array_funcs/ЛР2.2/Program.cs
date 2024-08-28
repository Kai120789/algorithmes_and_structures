using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР2._2
{
    internal class Program
    {
        static int[] Init()
        {
            var res = new int[7];
            Random random = new Random();
            for (int i = 0; i < 7; i++)
                res[i] = random.Next(1, 100);
            Console.WriteLine(string.Join(" ", res));
            return res;
        }
        static int[] Func(int[] ar, int k)
        {
            var res = new int[k];
            int ind = 0, amax = int.MinValue, z = 0;
            for (int i = 0; i < ar.Length; i++)
                if (ar[i] > amax) {ind = i; amax = ar[i]; }
            res[z++] = amax;

            for (int j = 0; j <= k - 2; j++)
            {
                int pos = 0, pmax = int.MinValue;
                bool flag = true;
                for (int i = 0; i < ar.Length; i++)
                {
                    if (ar[i] > pmax && ar[i] < amax)
                    {
                        pos = i; pmax = ar[i];
                    }
                    else if (ar[i] == amax && i > ind) { res[z++] = ar[i]; ind = i; flag = false; break; }
                }
                if (flag) { res[z++] = pmax; amax = pmax; ind = pos; }
            }

            return res;
        }
        static void Main(string[] args)
        {
            //var test = Init();
            var test = new int[] { 92, 77, 88, 92, 88, 92, 77, 88};
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", Func(test, 7)));
        }
    }
}
