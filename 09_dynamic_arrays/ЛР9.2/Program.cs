using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР9._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lst = new List<long>();
            for (long i = 0; i < 60_000_000; i++)
                lst.Add(i);

            var llst = new LinkedList<long>();
            for (long i = 0; i < 60_000_000; i++)
                llst.AddLast(i);

            var t1 = DateTime.Now;
            lst.Contains(-1);
            var t2 = DateTime.Now;
            Console.WriteLine(t2.Subtract(t1).TotalSeconds);

            var t3 = DateTime.Now;
            llst.Contains(-1);
            var t4 = DateTime.Now;
            Console.WriteLine(t4.Subtract(t3).TotalSeconds);
        }
    }
}
