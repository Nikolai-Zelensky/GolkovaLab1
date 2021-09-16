namespace Dijkstra.CustomGraph
{
    public class Edge
    {
        public Edge(Vertex linkedVertex, int cost)
        {
            LinkedVertex = linkedVertex;
            EdgeCost = cost;
        }
        public Vertex LinkedVertex { get; }

        public int EdgeCost { get; }
    }
}
