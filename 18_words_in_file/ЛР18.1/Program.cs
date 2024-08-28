namespace ЛР18
{
    class Vertex
    {
        public char Letter;
        public int Terminal;
        public List<Vertex> Next;
        public Vertex(char letter, int terminal)
        {
            Letter = letter; Terminal = terminal; Next = new
        List<Vertex>();
        }
        public Vertex(char letter, int terminal, List<Vertex> next)
        { Letter = letter; Terminal = terminal; Next = next; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Vertex('\0', 0); // создание вершин бора

            var c1 = new Vertex('п', 0);
            var c2 = new Vertex('а', 0);
            var c3 = new Vertex('р', 1); // пар
            var c4 = new Vertex('о', 0);
            var c5 = new Vertex('в', 0); 
            var c6 = new Vertex('о', 0);
            var c7 = new Vertex('з', 2); // паровоз

            var c8 = new Vertex('р', 0);
            var c9 = new Vertex('о', 0);
            var c10 = new Vertex('в', 3); // ров
            var c11 = new Vertex('н', 0);
            var c12 = new Vertex('ы', 0);  
            var c13 = new Vertex('й', 4);   // ровный
            var c14 = new Vertex('д', 5);   // род

            var c15 = new Vertex('в', 0);
            var c16 = new Vertex('о', 0);  
            var c17 = new Vertex('з', 6);  // воз

            var c18 = new Vertex('б', 0);  
            var c19 = new Vertex('о', 0);
            var c20 = new Vertex('р', 7);   // бор
            var c21 = new Vertex('о', 0);
            var c22 = new Vertex('д', 0);
            var c23 = new Vertex('а', 8);   // борода

            root.Next = new List<Vertex>() { c1, c8, c15, c18}; // рёбра бора
            c1.Next = new List<Vertex>() { c2 };
            c2.Next = new List<Vertex>() { c3 };
            c3.Next = new List<Vertex>() { c4 };
            c4.Next = new List<Vertex>() { c5 };
            c5.Next = new List<Vertex>() { c6 };
            c6.Next = new List<Vertex>() { c7 };

            c8.Next = new List<Vertex>() { c9 };
            c9.Next = new List<Vertex>() { c10, c14 };
            c10.Next = new List<Vertex>() { c11 };
            c11.Next = new List<Vertex>() { c12 };
            c12.Next = new List<Vertex>() { c13 };

            c15.Next = new List<Vertex>() { c16 };
            c16.Next = new List<Vertex>() { c17 };

            c18.Next = new List<Vertex>() { c19 };
            c19.Next = new List<Vertex>() { c20 };
            c20.Next = new List<Vertex>() { c21 };
            c21.Next = new List<Vertex>() { c22 };
            c22.Next = new List<Vertex>() { c23 };

            var stream = new StreamReader("C:\\Users\\1\\Desktop\\Даня\\ЛР_Колесников_Д_22-КБ-ПР1\\2 Сем\\АСД\\ЛР18\\ЛР18.1\\TextFile1.txt");
            string? s = stream.ReadLine();
            Vertex? n = root; // активная вершина бора
            for (int i = 0; i < s.Length; i++)
            {
                n = n.Next.Find(x => x.Letter == s[i]); // поиск буквы s[i]
                if (n != null)
                {
                    if (n.Terminal > 0)
                        Console.WriteLine($"Найден образец №{n.Terminal}");
                }
                else n = root;
            }
            stream.Close();
            Console.ReadKey();
        }
    }
}