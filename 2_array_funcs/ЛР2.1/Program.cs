using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР2._1
{
    internal class Program
    {
        static int BinSearch(int[] ar, int x, int low, int high)
        {
            int mid = (low + high) / 2;
            if (!ar.Contains(x)) return -1;
            if (x > ar[mid])
                return BinSearch(ar, x, mid + 1, high);
            else if (x < ar[mid])
                return BinSearch(ar, x, low, mid - 1);
            else return mid;    
        }
        static void Main(string[] args)
        {
            int[] ar = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(BinSearch(ar,11,0,ar.Length-1));
            Console.ReadKey();
        }
    }
}
