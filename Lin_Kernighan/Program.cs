using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lin_Kernighan
{
    class Program
    {
        public static Graph ReadGraph(string filename)
        {
            int count = System.IO.File.ReadAllLines(filename).Length;
            StreamReader st1 = new StreamReader(filename);
            string[] ch1;
            try
            {
                ch1 = st1.ReadLine().Split(' ');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ch1 = null;
            }
            st1.Close();
            if (count > 0 && count % 2 == 0 && ch1.Length==count)
            {
                StreamReader st = new StreamReader(filename);
                int[,] matrix = new int[count, count];
                int k = 0;
                try
                {
                    while (!st.EndOfStream)
                    {
                        string[] ch = st.ReadLine().Split(' ');
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrix[k, j] = Convert.ToInt32(ch[j]);
                        }
                        k++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                st.Close();
                List<Edge> edges = new List<Edge>();
                List<Vertex> vertex = new List<Vertex>();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    vertex.Add(new Vertex(i));
                }
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == 1)
                        {
                            Edge e = new Edge(i, j);
                            Edge e1 = new Edge(j, i);
                            if (edges.Contains(e) == false && edges.Contains(e1) == false)
                            {
                                vertex[i].Edges.Add(e);
                                vertex[j].Edges.Add(e);
                                edges.Add(e);
                            }
                        }
                    }
                }
                return new Graph(vertex, edges);
            }
            else
            {
                Console.WriteLine("Error");
                return null;
            }
        }
        static void Main(string[] args)
        {
            Graph g = ReadGraph("graph1.txt");
            if (g != null)
            {
                Kernighan_Lin kl = new Kernighan_Lin(g);
                kl.Start();
            }
            Console.ReadLine();
        }
    }
}
