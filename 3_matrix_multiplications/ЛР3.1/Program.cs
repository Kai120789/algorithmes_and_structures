using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ЛР3._1
{
    internal class Program
    {
        static void Print(int[,] ar)
        {
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0;  j < ar.GetLength(1); j++)
                    Console.Write(ar[i,j] + " ");
                Console.WriteLine();
            }
        }
        static int[,] Init(int a, int b)
        {
            var res = new int[a,b];
            Random rnd = new Random();
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                    res[i, j] = rnd.Next(1, 5);
            return res;
        }
        static void Concat(int[,] res, int[,] a, int x, int y)
        {
            int w = x, z = y;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    res[x, y] = a[i, j];
                    y++;
                }
                y = z;
                x++;
            }
        }
        static int[,] Mult(int[,] a, int[,] b)
        {
            var res = new int[2, 2];
            res[0,0] = a[0,0] * b[0,0];
            res[0,1] = a[0,0] * b[0,1];
            res[1,0] = a[1,0] * b[0,0];
            res[1,1] = a[1,0] * b[0,1];
            return res;
        }
        static void Func(int[,] a, int[,] b, int[,] res, ref int x, ref int y)
        {
            if (a.LongLength != 2 && b.LongLength == 2)
            {
                var t = new int[a.LongLength / 2, 1];
                for(int i = 0; i < a.LongLength / 2; i++)
                    t[i, 0] = a[i, 0];
                Func(t, b, res, ref x, ref y);

                t = new int[a.LongLength / 2, 1];
                for (int i = Convert.ToInt32(a.LongLength)/2; i < a.LongLength; i++)
                    t[i-(Convert.ToInt32(a.LongLength) / 2), 0] = a[i, 0];
                Func(t, b, res, ref x, ref y);
            }
            else if (a.LongLength == 2 && b.LongLength == 2)
            {
                Concat(res, Mult(a, b), x, y);
                x += 2;
            }
            //else if (a.LongLength != 2 && b.LongLength != 2)
            //{
            //    var t = new int[a.LongLength / 2, 1];
            //    for (int i = 0; i < a.LongLength / 2; i++)
            //        t[i, 0] = a[i, 0];
            //    var t2 = new int[1, b.LongLength / 2];
            //    for (int i = 0; i < b.LongLength / 2; i++)
            //        t2[0, i] = b[0, i];
            //    var t3 = new int[a.LongLength / 2, 1];
            //    for (int i = Convert.ToInt32(a.LongLength) / 2; i < a.LongLength; i++)
            //        t3[i - (Convert.ToInt32(a.LongLength) / 2), 0] = a[i, 0];
            //    var t4 = new int[1, b.LongLength / 2];
            //    for (int i = Convert.ToInt32(b.LongLength) / 2; i < b.LongLength; i++)
            //        t4[0, i - (Convert.ToInt32(b.LongLength) / 2)] = b[0, i];
            //    Func(t, t2, res, ref x, ref y);
            //    y += 2;
            //    Func(t, t4, res, ref x, ref y);
            //    y -= 2; x += 2;
            //    Func(t3, t2, res, ref x, ref y);
            //    y += 2;
            //    Func(t3, t4, res, ref x, ref y);
            //    x -= 2; 
            //}
        }
        static void Main(string[] args)
        {
            var a = Init(8, 1);
            var b = Init(1, 2);
            var res = new int[a.LongLength, b.LongLength];
            int x = 0, y = 0;
            Func(a, b, res, ref x, ref y);
            Print(res);
        }
    }
}
