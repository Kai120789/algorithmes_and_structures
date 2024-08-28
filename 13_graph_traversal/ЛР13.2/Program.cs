class Program
{
    class Bush<T>
    {
        public T Name; // имя вершины
        public List<Bush<T>> Neighbors = new List<Bush<T>>(); // соседи
        public Bush(T name) { Name = name; }
    }
    static bool IsTree<T>(Bush<T> bush)
    {
        var tabu = new List<Bush<T>>() { bush };
        var internals = new List<Bush<T>>();
        return IsTree(bush, tabu, internals);
    }
    static bool IsTree<T>(Bush<T> bush, List<Bush<T>> tabu, List<Bush<T>> internals)
    {
        // мне кажется он не оптимизирован
        if (bush.Neighbors.Count == 1 && internals.Contains(bush.Neighbors.First())) { internals.Add(bush); return true; }

        foreach(Bush<T> neigh in bush.Neighbors)    // основной цикл проверки, что соседи не связаны с табу
        {
            if (!tabu.Contains(neigh))
            {
                tabu.Add(neigh);
                foreach (Bush<T> t in neigh.Neighbors)
                    if (tabu.Contains(t) && t != bush)
                        return false;
            }
        }

        internals.Add(bush);
        bool f = true;
        foreach (Bush<T> neigh in bush.Neighbors)   //рекурсивное продолжение
        {
            if (!internals.Contains(neigh))
                f &= IsTree(neigh, tabu, internals);
            if (!f)
                break;
        }
        return f; 
    }
    static void Main()
    {
        var b1 = new Bush<int>(1);
        var b2 = new Bush<int>(2);
        var b3 = new Bush<int>(3);
        var b4 = new Bush<int>(4);
        var b5 = new Bush<int>(5);
        var b6 = new Bush<int>(6);
        var b7 = new Bush<int>(7);
        var b8 = new Bush<int>(8);
        b1.Neighbors.Add(b2);
        b2.Neighbors.Add(b1);

        b1.Neighbors.Add(b3);
        b3.Neighbors.Add(b1);

        b3.Neighbors.Add(b5);
        b5.Neighbors.Add(b3);

        b4.Neighbors.Add(b3);
        b3.Neighbors.Add(b4);

        //b2.Neighbors.Add(b4);
        //b4.Neighbors.Add(b2);

        b5.Neighbors.Add(b6);
        b6.Neighbors.Add(b5);

        b7.Neighbors.Add(b5);
        b5.Neighbors.Add(b7);

        b7.Neighbors.Add(b8);
        b8.Neighbors.Add(b7);
        Console.WriteLine(IsTree(b8));
    }
}