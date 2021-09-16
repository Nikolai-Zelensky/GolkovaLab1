using Dijkstra.CustomGraph;
using Dijkstra.MatrixManipulations.CustomList;

namespace Dijkstra.Formatting
{
    public class GraphBuilder
    {
        private Container _container;
        private Graph _graph = new Graph();

        public GraphBuilder(Container container)
        {
            _container = container;
        }

        /// <summary>
        /// Строит граф из вершин и рёбер
        /// </summary>
        /// <returns></returns>
        public Graph BuildGraph()
        {
            BuildVertices();
            BuildEdges();
            return _graph;
        }

        /// <summary>
        /// Стороит вершины из списка вершин и добавляет в граф
        /// </summary>
        private void BuildVertices()
        {
            for (int i = 0; i < _container.vertices.Count; i++)
            {
                _graph.AddVertex(_container.vertices[i].ToString());
            }
        }

        /// <summary>
        /// Стороит рёбра из списка вершин и добавляет в граф
        /// </summary>
        private void BuildEdges()
        {
            for (int i = 0; i < _container.from.Count; i++)
            {
                _graph.AddEdge(_container.from[i], _container.where[i], _container.cost[i]);
            }
        }
    }
}
