using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР15._1
{
    internal class Program
    {
        static void PrintArr(int[,] ar)
        {
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {

                    if (ar[i, j] != int.MaxValue) Console.Write(ar[i, j] + "\t");
                    else Console.Write(" " + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static int[,] GenFIeld()
        {
            object[][] ar = new object[16][];
            for (int i = 0; i < ar.Length; i++)
                ar[i] = new object[2];
            for (int i = 1; i < ar.Length; i++) {
                ar[i][0] = false;
                ar[i][1] = 0;
            }

            List<int> lst = new List<int>() { int.MaxValue };
            for (int i = 1; i <= 15; i++)
                lst.Add(i);

            int voidpos = 0;

            int[,] field = new int[4, 4];
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i < 3 || (i == 3 && j == 0))
                    {
                        int getrandom = rnd.Next(0, lst.Count);
                        field[i, j] = lst[getrandom];
                        if (lst[getrandom] == int.MaxValue) voidpos = i + 1;
                        else if (lst[getrandom] != int.MaxValue) {
                            for (int ind = lst[getrandom] + 1; ind <= 15; ind++)
                                if (ar[ind][0].Equals(true))
                                    ar[ind][1] = (int)ar[ind][1] + 1;
                            ar[lst[getrandom]][0] = true;
                        }
                        lst.RemoveAt(getrandom);
                    }
                }
            }

            int z = lst.FindAll(x => x != int.MaxValue).Count;
            if (z == 2) 
            {
                field[3, 3] = int.MaxValue;
                lst.Remove(int.MaxValue);

                int time = 0;
                for (int i = 1; i <= 15; i++)
                    time += (int)ar[i][1];
                voidpos = 4;
                time += voidpos;

                if ((time & 0b1) == 0)
                {
                    if ((((15 - lst.Min()) & 0b1) == 0 && ((15 - lst.Max()) & 0b1) == 0) || (((15 - lst.Min()) & 0b1) == 1 && ((15 - lst.Max()) & 0b1) == 1))
                    {
                        field[3, 1] = lst.Max();
                        field[3, 2] = lst.Min();
                    }
                    else if ((((15 - lst.Min()) & 0b1) == 0 && ((15 - lst.Max()) & 0b1) == 1) || (((15 - lst.Min()) & 0b1) == 1 && ((15 - lst.Max()) & 0b1) == 0))
                    {
                        field[3, 1] = lst.Min();
                        field[3, 2] = lst.Max();
                    }
                }
                else
                {
                    if ((((15 - lst.Min()) & 0b1) == 0 && ((15 - lst.Max()) & 0b1) == 0) || (((15 - lst.Min()) & 0b1) == 1 && ((15 - lst.Max()) & 0b1) == 1))
                    {
                        field[3, 1] = lst.Min();
                        field[3, 2] = lst.Max();
                    }
                    else if ((((15 - lst.Min()) & 0b1) == 0 && ((15 - lst.Max()) & 0b1) == 1) || (((15 - lst.Min()) & 0b1) == 1 && ((15 - lst.Max()) & 0b1) == 0))
                    {
                        field[3, 1] = lst.Max();
                        field[3, 2] = lst.Min();
                    }
                }
            }
            else if (z == 3)
            {
                int getrandom = rnd.Next(0, lst.Count);
                field[3, 1] = lst[getrandom];
                for (int ind = lst[getrandom] + 1; ind <= 15; ind++)
                    if (ar[ind][0].Equals(true))
                        ar[ind][1] = (int)ar[ind][1] + 1;
                lst.RemoveAt(getrandom);

                int time = 0;
                for (int i = 1; i <= 15; i++)
                    time += (int)ar[i][1];
                time += voidpos;

                if ((time & 0b1) == 0)
                {
                    if ((((15 - lst.Min()) & 0b1) == 0 && ((15 - lst.Max()) & 0b1) == 0) || (((15 - lst.Min()) & 0b1) == 1 && ((15 - lst.Max()) & 0b1) == 1))
                    {
                        field[3, 2] = lst.Max();
                        field[3, 3] = lst.Min();
                    }
                    else if ((((15 - lst.Min()) & 0b1) == 0 && ((15 - lst.Max()) & 0b1) == 1) || (((15 - lst.Min()) & 0b1) == 1 && ((15 - lst.Max()) & 0b1) == 0))
                    {
                        field[3, 2] = lst.Min();
                        field[3, 3] = lst.Max();
                    }
                }
                else
                {
                    if ((((15 - lst.Min()) & 0b1) == 0 && ((15 - lst.Max()) & 0b1) == 0) || (((15 - lst.Min()) & 0b1) == 1 && ((15 - lst.Max()) & 0b1) == 1))
                    {
                        field[3, 2] = lst.Min();
                        field[3, 3] = lst.Max();
                    }
                    else if ((((15 - lst.Min()) & 0b1) == 0 && ((15 - lst.Max()) & 0b1) == 1) || (((15 - lst.Min()) & 0b1) == 1 && ((15 - lst.Max()) & 0b1) == 0))
                    {
                        field[3, 2] = lst.Max();
                        field[3, 3] = lst.Min();
                    }
                }
            }
            return field;
        }
        static void Main(string[] args)
        {
            int[,] field = GenFIeld();
            PrintArr(field);
            Console.ReadLine();
        }
    }
}
