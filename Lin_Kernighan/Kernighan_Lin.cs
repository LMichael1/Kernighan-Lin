using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lin_Kernighan
{
    class Kernighan_Lin
    {
        public Graph KGraph { get; set; }
        public List<Vertex> UnchosenA { get; set; }
        public List<Vertex> UnchosenB { get; set; }
        private int G = 0;
        public Kernighan_Lin(Graph g)
        {
            KGraph = g;
        }
        public void Start()
        {
            UnchosenA = KGraph.GroupA;
            UnchosenB = KGraph.GroupB;
            int NCutSize = int.MaxValue;
            int StepsCount = KGraph.Vertices.Count / 2;
            int CutSize = KGraph.GetCutSize();
            int gmaxi = 0;
            int gmax = 0;
            NCutSize = KGraph.GetCutSize();
            Console.WriteLine("Изначальный разрез: " + NCutSize);
            int i = 0;
            while (i<StepsCount)
            {
                Console.WriteLine("Шаг " + i);
                Console.WriteLine("Группа А:");
                for (int z = 0; z < UnchosenA.Count; z++)
                {
                    Console.WriteLine("Вершина №" + UnchosenA[z].Num + " Цена: " + UnchosenA[z].GetCost());
                }
                Console.WriteLine("Группа B:");
                for (int z = 0; z < UnchosenB.Count; z++)
                {
                    Console.WriteLine("Вершина №" + UnchosenB[z].Num + " Цена: " + UnchosenB[z].GetCost());
                } 
                OneSwap();
                int cost = KGraph.GetCutSize();
                Console.WriteLine("Разрез: " + cost + "\n");
                if (G>gmax)
                {
                    gmax = G;
                    gmaxi = i;
                }
                i++;
            }
           // }
            KGraph.CreateRandomGroups();
            UnchosenA = KGraph.GroupA;
            UnchosenB = KGraph.GroupB;
            for (int k=0; k<=gmaxi; k++)
            {
                OneSwap();
            }
            PrintResult();
        }
        public void OneSwap()
        {
            int g_max = int.MinValue;
            Vertex[] pair = new Vertex[2];
            for (int i = 0; i < UnchosenA.Count; i++)
            {
                for (int k = 0; k < UnchosenB.Count; k++)
                {
                    int c = 0;
                    if (KGraph.Edges.Contains(new Edge(UnchosenA[i].Num, UnchosenB[k].Num)) || KGraph.Edges.Contains(new Edge(UnchosenB[k].Num, UnchosenA[i].Num))) c++;
                    int g = UnchosenA[i].GetCost() + UnchosenB[k].GetCost() - 2 * c;
                 //   Console.WriteLine(UnchosenA[i].Num + " Цена " + UnchosenA[i].GetCost() + " " + UnchosenB[k].Num + " Цена " + UnchosenB[k].GetCost() + " " + g);
                    if (g_max<g)
                    {
                        g_max = g;
                        pair[0] = UnchosenA[i];
                        pair[1] = UnchosenB[k];
                    }
                }
            }
            if (pair[0]!=null && pair[1] != null)
            {
                UnchosenA.Remove(pair[0]);
                UnchosenB.Remove(pair[1]);
                Swap(pair[0], pair[1]);
            }
            G += g_max;
        }
        public void Swap(Vertex a, Vertex b)
        {
            KGraph.Vertices[a.Num].Group = 'B';
            KGraph.Vertices[b.Num].Group = 'A';
        }
        public void PrintResult()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Результат:");
            foreach(var e in KGraph.Vertices)
            {
                Console.WriteLine("Вершина №" + e.Num + " Группа: " + e.Group);
            }
            Console.WriteLine("Разрез: "+KGraph.GetCutSize());
        }
    }
}
