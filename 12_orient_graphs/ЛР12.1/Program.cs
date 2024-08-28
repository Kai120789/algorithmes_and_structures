using System;
using System.Collections.Generic;

namespace ЛР12._1
{
    class Program
    {
        public class Bush<T>
        {
            public T Name;
            public int X; // Координата x
            public int Y; // Координата y
            // Список смежных вершин (если список пустой, то null)
            public LinkedList<Bush<T>> Neighbors = new LinkedList<Bush<T>>();
            public Bush(T name, int x, int y) { Name = name; X = x; Y = y; }
        }
        class Graph<T>
        {
            public LinkedList<Bush<T>> LLN;
            public Graph() { LLN = new LinkedList<Bush<T>>(); }
            public void AddNode(T name, int x, int y)
            {
                foreach (Bush<T> n in LLN) if (n.Name.Equals(name)) return;
                var bush = new Bush<T>(name, x, y);
                LLN.AddLast(bush);
            }
            public void AddEdge(T FromName, T ToName)
            {
                foreach (Bush<T> a in LLN)
                {
                    if (a.Name.Equals(FromName))
                    {
                        foreach (Bush<T> b in LLN)
                        {
                            if (b.Name.Equals(ToName))
                                a.Neighbors.AddLast(b);
                        }
                        return;
                    }
                }
            }
            public void AddEdges(T FromName, T[] ToNames)
            {
                foreach (Bush<T> a in LLN)
                {
                    if (a.Name.Equals(FromName))
                    {
                        foreach (T ToName in ToNames)
                        {
                            foreach (Bush<T> b in LLN)
                            {
                                if (b.Name.Equals(ToName))
                                    a.Neighbors.AddLast(b);
                            }
                        }
                        return;
                    }
                }
            }
            public void MoveNode(T name, int x, int y)
            {
                foreach (Bush<T> a in LLN)
                {
                    if (a.Name.Equals(name)) { a.X = x; a.Y = y; }
                }
            }
            public void PrintNeighbors(T name)
            {
                foreach (Bush<T> a in LLN)
                {
                    if (a.Name.Equals(name))
                    {
                        foreach (Bush<T> m in a.Neighbors)
                            Console.Write(m.Name + ", ");
                        return;
                    }
                }
            }
            public void PrintNode(T name)
            {
                foreach(Bush<T> node in LLN)
                {
                    if (node.Name.Equals(name))
                    {
                        Console.WriteLine("Имя вершины: " + node.Name);
                        Console.WriteLine("Координата x: " + node.X + ", y: " + node.Y);
                        Console.Write("Её соседи:"); PrintNeighbors(name); Console.WriteLine();
                        foreach (Bush<T> neigh in node.Neighbors)
                        {
                            double x = Math.Pow(node.X - neigh.X, 2);
                            double y = Math.Pow(node.Y - neigh.Y, 2);
                            double res = Math.Round(Math.Pow(x + y, 0.5), 4);
                            Console.WriteLine($"Расстояние от {node.Name} до {neigh.Name} = {res}");
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            var G = new Graph<char>();
            G.AddNode('a', 1, 4);
            G.AddNode('b', 4, 5);
            G.AddNode('c', 3, 1);
            G.AddEdges('a', new char[] { 'b', 'c' });
            G.AddEdge('b', 'c');
            G.PrintNode('a');
            Console.ReadKey();
        }
    }
}
