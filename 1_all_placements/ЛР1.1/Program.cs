using System;
using System.Linq;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> w = new List<int>();
            for (int i = 1; i <= 5; i++)
                w.Add(i);
            List<int> p = new List<int>();
            DateTime t1 = DateTime.Now;
            Per(w, p);
            DateTime t2 = DateTime.Now;
            Console.WriteLine(t2.Subtract(t1).TotalSeconds);
            Console.ReadKey();
        }
        static void Per(List<int> w, List<int> p)
        {
            if (w.Count > 0)
            {
                for (int i = 0; i < w.Count; i++)
                {
                    List<int> w1 = new List<int>();
                    w1 = w.GetRange(0, w.Count);
                    int e = w1[i];
                    w1.RemoveAt(i);
                    List<int> p1 = new List<int>();
                    p1 = p.GetRange(0, p.Count);
                    p1.Add(e);
                    Console.WriteLine(string.Join(" ", p1));
                    Per(w1, p1);
                }
            }
        }
    }
}
