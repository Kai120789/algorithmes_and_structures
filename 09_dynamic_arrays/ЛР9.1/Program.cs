using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ЛР9._1
{
    internal class Program
    {
        class MyList<T>
        {
            public int Capacity; // ёмкость массива
            public int Size; // используемая ёмкость массива
            public T[] A; // массив

            public MyList(int capacity) // конструктор
            { Capacity = capacity; A = new T[capacity]; Size = 0; }
            public MyList(T[] ar) 
            { Capacity = ar.Length; Size = ar.Length; A = new T[Capacity]; ar.CopyTo(A, 0); }
            public void Add(T value)
            {
                if (Size < Capacity) // в пределах ёмкости
                    A[Size] = value; // добавили элемент
                else // вышли за предел ёмкости
                {
                    Array.Resize(ref A, Capacity + 4); // ёмкость + 4
                    Capacity += 4;
                    A[Size] = value; // добавили элемент
                }
                Size++; // размер + 1
            }
            public void Insert(T value, int position)
            {
                if (position >= 0 && position <= Size) // индекс в границах
                {
                    if (Size >= Capacity) // вышли за предел ёмкости
                    {
                        Array.Resize(ref A, Capacity + 4); // ёмкость + 4
                        Capacity += 4;
                    }
                    if (position == Size) // вставка в конец
                    { A[Size] = value; Size++; }
                    else
                    {
                        for (int i = Size - 1; i >= position; i--)
                            A[i + 1] = A[i]; // раздвинули массив
                        A[position] = value; // вставили элемент
                        Size++; // размер + 1
                    }
                }
                else
                {
                    throw new System.Exception("Выход индекса" + position + "за границы массива");
                }
            }
            public T Delete()
            {
                if (Size > 0) // удаление из непустого массива
                {
                    Size--; // удаление последнего элемента
                    return A[Size]; // возвращаем удалённый элемент
                }
                else
                {
                    throw new System.Exception("Попытка удаления из пу-стого списка");
                }
            }
            public T this[int position]
            {
                get
                {
                    if (position < Size) return A[position];
                    else
                    {
                        throw new System.IndexOutOfRangeException("Выходиндекса" + position + "за границы массива");
                    }
                }
                set
                {
                    if (position < Size) A[position] = value;
                    else
                    {
                        throw new System.IndexOutOfRangeException("Выходиндекса" + position + "за границы массива");
                    }
                }
            }
            public void PrintList(string Title)
            {
                Console.Write(Title + " ");
                for (uint i = 0; i < Size; i++)
                    Console.Write(A[i] + " ");
                Console.WriteLine();
            }
            public T Cut(int pos)
            {
                if (pos >= 0 && pos <= Size)
                {
                    T value = A[pos];
                    Size--;
                    for (int i = pos; i < Size; i++)
                        A[i] = A[i + 1];
                    return value;
                }
                else throw new System.Exception("Выход индекса" + pos + "за границы массива"); 
            }
            public int Remove(T item)
            {
                for (int i = 0; i < Size;i++)
                    if (A[i].Equals(item))
                    {
                        Cut(i);
                        return i;
                    }
                throw new System.Exception("Такого элемента нет в списке");
            }
        }
        static void Main(string[] args)
        {
            var ar = new int[] { 8, 2, 4, 2 };
            var lst = new MyList<int>(ar);

            //var value = lst.Cut(2);
            //Console.WriteLine(value);

            //var index = lst.Remove(2);
            //Console.WriteLine(index);
            lst.PrintList("");
            Console.ReadKey();
        }
    }
}
