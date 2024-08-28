class Program
{
    class Bush<T>
    {
        public T Name; // имя вершины
        public LinkedList<Bush<T>> Neighbors = new LinkedList<Bush<T>>(); // соседи
        public Bush(T name) { Name = name; }
    }
    class Graph<T>
    {
        public LinkedList<Bush<T>> LLN;
        public Graph() { LLN = new LinkedList<Bush<T>>(); }
        public void AddNode(T name) // добавление уникальной вершины
        {
            foreach (Bush<T> n in LLN) if (n.Name.Equals(name)) return;
            var bush = new Bush<T>(name);
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
                        {
                            a.Neighbors.AddLast(b); break;
                        }
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
                            {
                                a.Neighbors.AddLast(b); break;
                            }
                        }
                    }
                    return;
                }
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
        public void DepthFirstTraversal(T name) // обход в глубину
        {
            var tabu = new List<T> { name }; // список табу + name
            foreach (Bush<T> bush in LLN) // поиск стартового куста
            {
                if (bush.Name.Equals(name))
                {
                    DepthFirstTraversal(bush, tabu);
                    break;
                }
            }
        }
        public void DepthFirstTraversal(Bush<T> bush, List<T> tabu)
        {
            bool f = true; // флаг неизменения табу
            foreach (Bush<T> Neighbor in bush.Neighbors) // все соседи
            {
                if (!tabu.Contains(Neighbor.Name)) // не в списке табу
                {
                    f = false;
                    tabu.Add(Neighbor.Name); // в список табу
                    DepthFirstTraversal(Neighbor, tabu);
                    tabu.Remove(Neighbor.Name); // удаление после возврата
                }
            }
            if (f)
                Console.WriteLine(string.Join(" ", tabu));
        }
        public void BreadthFirstTraversal(T name) // обход в ширину
        {
            var internals = new List<Bush<T>>(); // список внут. вершин
            var externals = new List<Bush<T>>(); // список фронта
            foreach (Bush<T> bush in LLN) // поиск стартового куста
            {
                if (bush.Name.Equals(name))
                {
                    Console.WriteLine(bush.Name);
                    externals.Add(bush);
                    BreadthFirstTraversal(internals, externals);
                    break;
                }
            }
        }
        public void BreadthFirstTraversal(List<Bush<T>> internals, List<Bush<T>> externals)
        {
            if (externals.Count == 0) return;
            internals.AddRange(externals); // список табу
            var newexternals = new List<Bush<T>>(); // новый фронт
            foreach (Bush<T> bush in externals)
            {
                foreach (Bush<T> Neighbor in bush.Neighbors)
                {
                    if (!internals.Contains(Neighbor)) // не табу
                    {
                        Console.Write(Neighbor.Name + " ");
                        newexternals.Add(Neighbor); // в список фронта
                    }
                }
            }
            Console.WriteLine();
            BreadthFirstTraversal(internals, newexternals);
        }
    }
    static void Main()
    {
        var G = new Graph<char>();
        G.AddNode('a');
        G.AddNode('b');
        G.AddNode('c');
        G.AddNode('d');
        G.AddNode('e');
        G.AddNode('f');
        G.AddNode('x');
        G.AddEdges('a', new char[] { 'b', 'c', 'e' });
        G.AddEdge('b', 'c');
        G.AddEdges('c', new char[] { 'b', 'd' });
        G.AddEdge('d', 'b');
        G.AddEdge('e', 'f');
        //G.AddEdge('b', 'x');
        Console.WriteLine("Обход вглубь из вершины 'a':");
        G.DepthFirstTraversal('a');
        Console.ReadKey();
    }
}