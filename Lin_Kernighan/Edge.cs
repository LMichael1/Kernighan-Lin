using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lin_Kernighan
{
    class Edge
    {
        public int LeftNum { get; set; }
        public int RightNum { get; set; }
        public Vertex LeftVertex { get; set; }
        public Vertex RightVertex { get; set; }
        public Edge(int left, int right)
        {
            LeftNum = left;
            RightNum = right;
        }
        public override bool Equals(object obj)
        {
            if (obj is Edge)
            {
                Edge obj1 = (Edge)obj;
                return this.LeftNum == obj1.LeftNum && this.RightNum == obj1.RightNum;
            }
            else return false;
        }
        public static bool operator ==(Edge v1, Edge v2)
        {
            return v1.Equals(v2);
        }
        public static bool operator !=(Edge v1, Edge v2)
        {
            return !v1.Equals(v2);
        }
        public override int GetHashCode()
        {
            string str = "";
            str += LeftNum;
            str += RightNum;
            return str.GetHashCode();
        }
    }
}
