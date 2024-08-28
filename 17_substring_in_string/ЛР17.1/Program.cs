using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР17._1
{
    internal class Program
    {
        static int GetHash(string s)
        {
            int hash = 0, n = s.Length - 1;
            foreach (byte value in Encoding.ASCII.GetBytes(s)) {
                hash += value * (1 << n);
                n--;
            }
            return hash;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите строку: "); string s = Console.ReadLine(); int n = s.Length;
            Console.Write("Введите подстроку: "); string p = Console.ReadLine(); int m = p.Length;
            Console.WriteLine();

            int hp = GetHash(p);    // хеш образца
            string sub = s.Substring(0, m);  // первая подстрока длины образца
            int hs = GetHash(sub);  // хеш подстроки
            if (hp == hs)
                Console.WriteLine("В позиции 0 найдено вхождение");

            for (int i = 1; i <= n - m; i++) {
                // кольцевой хеш
                hs = (hs - Encoding.ASCII.GetBytes(s[i - 1].ToString())[0] * (1 << (m - 1))) * 2 + Encoding.ASCII.GetBytes(s[i + m - 1].ToString())[0];
                if (hp == hs)
                    Console.WriteLine($"В позиции {i} найдено вхождение");
            }
            Console.ReadLine();
        }
    }
}
