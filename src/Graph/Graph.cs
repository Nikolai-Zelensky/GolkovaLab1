using System;
using System.Collections.Generic;

namespace Dijkstra.CustomGraph
{
    public class Graph
    {
        public List<Vertex> Vertices { get; }

        public Graph()
        {
            Vertices = new List<Vertex>();
        }

        /// <summary>
        /// Добавляет вершину по имени или 
        /// </summary>
        /// <param name="vertexName">название вершины</param>
        /// <returns> вершину </returns>
        public Vertex AddVertex(string vertexName)
        {
            Vertices.Add(new Vertex(vertexName));
            return new Vertex(vertexName);
        }

        /// <summary>
        /// Ищет вершину 
        /// </summary>
        /// <param name="vertexName"> Название передаваемой вершины</param>
        /// <returns> Совпадающая вершина с переданным названием </returns>
        public Vertex FindVertex(string vertexName)
        {
            foreach (var vertex in Vertices)
            {
                if (vertex.Name.Equals(vertexName))
                {
                    return vertex;
                }
            }
            return null;
        }

        /// <summary>
        /// Добавляет ребро
        /// </summary>
        /// <param name="firstName"> Имя первой вершины </param>
        /// <param name="secondName"> Имя второй вершины </param>
        /// <param name="cost"> Стоимость ребра, соединяющего две вершины</param>
        public void AddEdge(string firstName, string secondName, int cost)
        {
            var firstVertex = FindVertex(firstName);
            var secondVertex = FindVertex(secondName);

            if (firstVertex != null && secondVertex != null)
            {
                firstVertex.AddEdge(secondVertex, cost);
                secondVertex.AddEdge(firstVertex, cost);
            }
        }

        public void Print()
        {
            foreach (var vertex in Vertices)
            {
                Console.WriteLine(vertex.Name + " => ");
                vertex.Print();
                Console.WriteLine("\n");
            }
        }
    }
}
