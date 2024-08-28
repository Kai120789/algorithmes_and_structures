using System;

namespace ЛР12._2
{
    class Program
    {
        public static int Func(int x)
        {
            int res = 0;
            for (int i = 1; i <= x; i++)
                res += i;
            return res;
        }
        public static int[,] Init(int v, int e)
        {
            if (e > Func(v))
                throw new Exception("Слишком много ребер");
            int[,] m = new int[v,v];
            int r = 0;
            for (int i = 0; i < v && r < e; i++)
            {
                for (int j = i + 1; j < v && r < e; j++)
                {
                    m[i, j] = 1;
                    r++;
                }
            }
            int r1 = r;
            r = 0;
            for (int i = v-1; i >= 0 && r < e; i--)
            {
                for (int j = 0; j < i && r < e; j++)
                {
                    m[i, j] = 1;
                    r++;
                }
            }
            for (int i = 0; i < v && r1 < e; i++)
            { m[i, i] = 1; r1++; }
            return m;
        }
        public static void Print(int[,] ar)
        {
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    Console.Write(ar[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var res = Init(4, 7);
            Print(res);
        }
    }
}
