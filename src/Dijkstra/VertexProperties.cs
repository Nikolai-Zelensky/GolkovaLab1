using Dijkstra.CustomGraph;

namespace Dijkstra
{
    public class VertexProperties
    {
        public Vertex Vertex { get; set; }

        public bool IsUnvisited { get; set; }

        public int EdgesCostSum { get; set; }

        public Vertex PreviousVertex { get; set; }

        public VertexProperties(Vertex vertex)
        {
            Vertex = vertex;
            IsUnvisited = true;
            EdgesCostSum = int.MaxValue;
            PreviousVertex = null;
        }
    }
}
