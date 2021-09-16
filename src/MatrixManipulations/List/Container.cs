using System.Collections.Generic;

namespace Dijkstra.MatrixManipulations.CustomList
{
    public class Container
    {
        public List<string> from = new List<string>();
        public List<string> where = new List<string>();
        public List<string> vertices = new List<string>();
        public List<int> cost = new List<int>();

        public Container GetEmptyContainer() => new();
    }
}
