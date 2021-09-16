using Dijkstra.CustomGraph;
using System.Collections.Generic;

namespace Dijkstra
{
    public class DijkstraAlghoritm : Alghoritm
    {
        private Graph _graph;
        private List<VertexProperties> _properties;

        public DijkstraAlghoritm(Graph graph) => _graph = graph;

        /// <summary>
        /// Инициализирует информацию вершин
        /// </summary>
        public void InitializeProperties()
        {
            _properties = new List<VertexProperties>();
            foreach (var vertex in _graph.Vertices)
            {
                _properties.Add(new VertexProperties(vertex));
            }
        }

        /// <summary>
        /// Позволяет получить свойства вершины графа
        /// </summary>
        /// <param name="vertex"> Вершина графа </param>
        /// <returns> свойства вершины <returns>
        public VertexProperties GetVertexProperties(Vertex vertex)
        {
            foreach (var property in _properties)
            {
                if (property.Vertex.Equals(vertex))
                {
                    return property;
                }
            }
            return null;
        }

        /// <summary>
        /// Вычисляет сумму стоимости рёбер для следующей вершины графа
        /// </summary>
        /// <param name="properties"> Свойства текущей вершины </param>
        private void SetSumToNextVertex(VertexProperties properties)
        {
            properties.IsUnvisited = false;
            foreach (var edge in properties.Vertex.Edges)
            {
                var nextProperties = GetVertexProperties(edge.LinkedVertex);
                var sum = properties.EdgesCostSum + edge.EdgeCost;
                if (sum < nextProperties.EdgesCostSum)
                {
                    nextProperties.EdgesCostSum = sum;
                    nextProperties.PreviousVertex = properties.Vertex;
                }
            }
        }

        /// <summary>
        ///  Создаёт путь от начальной вершины до конечной
        /// </summary>
        /// <param name="startVertex"> Начальная вершина </param>
        /// <param name="endVertex"> Конечная вершина </param>
        /// <returns> Путь </returns>
        private string GetPath(Vertex startVertex, Vertex endVertex)
        {
            var path = endVertex.ToString();
            while (startVertex != endVertex)
            {
                endVertex = GetVertexProperties(endVertex).PreviousVertex;
                path = endVertex.ToString() + path;
            }
            return path;
        }

        /// <summary>
        /// Ищет непосещённую вершину с минимальным значением суммы рёбер 
        /// </summary>
        /// <returns> Свойства вершины с минимальной суммой </returns>
        private VertexProperties FindUnvisitedVertexWithMinSum()
        {
            var minValue = int.MaxValue;
            VertexProperties propertyWithMinSum = null;
            foreach (var property in _properties)
            {
                if (property.IsUnvisited && property.EdgesCostSum < minValue)
                {
                    propertyWithMinSum = property;
                    minValue = property.EdgesCostSum;
                }
            }
            return propertyWithMinSum;
        }

        public string FindShortestPathByName(string firstVertexName, string secondVertexName)
            => FindShortestPathByVertex(_graph.FindVertex(firstVertexName), _graph.FindVertex(secondVertexName));


        public string FindShortestPathByVertex(Vertex firstVertex, Vertex secondVertex)
        {
            InitializeProperties();
            var firstVertexProperties = GetVertexProperties(firstVertex);
            firstVertexProperties.EdgesCostSum = 0;
            while (true)
            {
                var unvisitedVertexWithMinSum = FindUnvisitedVertexWithMinSum();
                if (unvisitedVertexWithMinSum == null)
                {
                    break;
                }
                SetSumToNextVertex(unvisitedVertexWithMinSum);
            }
            return GetPath(firstVertex, secondVertex);
        }
    }
}