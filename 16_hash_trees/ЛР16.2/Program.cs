using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР16._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            uint[] ar = new uint[128];
            foreach (char x in Console.ReadLine())
                ar[x.GetHashCode() & ((int)Math.Pow(2, 7) - 1)] += 1;

            foreach (char x in Console.ReadLine())
            {
                ar[x.GetHashCode() & ((int)Math.Pow(2, 7) - 1)] -= 1;
                if (ar[x.GetHashCode() & ((int)Math.Pow(2, 7) - 1)] < 0)
                { Console.WriteLine(false); return; }
            }
            foreach (uint x in ar)
                if (x != 0)
                { Console.WriteLine(false); return; }
            
            Console.WriteLine(true);
        }
    }
}
