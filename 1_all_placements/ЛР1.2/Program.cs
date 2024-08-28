using System;
using System.Linq;
using System.Collections.Generic;
namespace Test
{
    class Program
    {
        static void Main()
        {
            DateTime t1 = DateTime.Now; H(3, "A", "B", "C");
            DateTime t2 = DateTime.Now; Console.WriteLine(t2.Subtract(t1).TotalSeconds);
            Console.ReadLine();
        }
        static void H(int n, string x, string y, string z)
        {
            if (n == 0) { return; }
            H(n - 1, x, z, y);
            Console.WriteLine($"Диск {n}: {x} -> {z}");      
            H(n - 1, y, x, z); 
        }
    }
}
