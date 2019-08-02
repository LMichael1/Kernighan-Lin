using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lin_Kernighan
{
    class Graph
    {
        public List<Edge> Edges { get; set; }
        public List<Vertex> Vertices { get; set; }
        public List<Vertex> GroupA { get; set; }
        public List<Vertex> GroupB { get; set; }
        public Dictionary<int, Vertex> VertexMap;
        public Graph(List<Vertex> v, List<Edge> e)
        {
            Vertices = v;
            Edges = e;
            VertexMap = new Dictionary<int, Vertex>();
            foreach (var a in Vertices)
            {
                VertexMap.Add(a.Num, a);
            }
            for (int i=0; i<Edges.Count; i++)
            {
                Edges[i].LeftVertex = VertexMap[Edges[i].LeftNum];
                Edges[i].RightVertex = VertexMap[Edges[i].RightNum];
            }
            GroupA = new List<Vertex>();
            GroupB = new List<Vertex>();
            CreateRandomGroups();
        }
        public void CreateRandomGroups()
        {
            for (int i=0; i<Vertices.Count/2; i++)
            {
                Vertices[i].Group = 'A';
                GroupA.Add(Vertices[i]);
            }
            for (int i=Vertices.Count/2;i<Vertices.Count; i++)
            {
                Vertices[i].Group = 'B';
                GroupB.Add(Vertices[i]);
            }
        }
        public int GetCutSize()
        {
            int size = 0;
            foreach (var e in Edges)
            {
                if (Vertices[e.LeftNum].Group != Vertices[e.RightNum].Group)
                {
                    size++;
                }
            }
            return size;
        }
    }
}
