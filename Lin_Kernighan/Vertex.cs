using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lin_Kernighan
{
    class Vertex
    {
        public int Num { get; set; }
        public List<Edge> Edges { get; set; }
        public char Group { get; set; }
        public Vertex()
        {
            Edges = new List<Edge>();
        }
        public Vertex(int num)
        {
            Num = num;
            Edges = new List<Edge>();
        }
        public void AddEdge(Edge edge)
        {
            if (!Edges.Contains(edge))
            {
                Edges.Add(edge);
            }
        }
        public int GetCost()
        {
            int cost = 0;
            foreach(var e in Edges)
            {
                if (e.LeftNum!=this.Num)
                {
                    if (e.LeftVertex.Group != this.Group)
                    {
                        cost++;
                    }
                    else cost--;
                }
                else
                {
                    if (e.RightVertex.Group != this.Group)
                    {
                        cost++;
                    }
                    else cost--;
                }
            }
            return cost;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vertex)
            {
                Vertex obj1 = (Vertex)obj;
                return this.Num == obj1.Num;
            }
            else return false;
        }
        public static bool operator ==(Vertex v1, Vertex v2)
        {
            return v1.Equals(v2);
        }
        public static bool operator !=(Vertex v1, Vertex v2)
        {
            return !v1.Equals(v2);
        }
        public override int GetHashCode()
        {
            return Num.GetHashCode();
        }
    }
}
