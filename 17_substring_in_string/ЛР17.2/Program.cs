using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР17._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: "); string s = Console.ReadLine();
            var lst = new List<char>();
            foreach (char c in s) if (!lst.Contains(c)) lst.Add(c);
            (char, int)[] ar = new (char, int)[lst.Count];
            for (int i = 0; i < lst.Count; i++) ar[i] = (lst[i], s.Length - 1 - s.LastIndexOf(lst[i]));
            Console.ReadLine();
        }
    }
}
