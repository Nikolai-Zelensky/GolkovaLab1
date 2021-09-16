using Dijkstra.MatrixManipulations.CustomList;
using System;

namespace Dijkstra.MatrixManipulations
{
    public class MatrixConverter
    {
        private int[,] _firstMatrix;
        private int[,] _secondMatrix;

        private Container _container = new Container();

        public MatrixConverter(int[,] firstArray, int[,] secondArray)
        {
            _firstMatrix = firstArray;
            _secondMatrix = secondArray;
        }

        /// <summary>
        /// Конвертирует матрицу в контейнер списков
        /// </summary>
        /// <returns> контейнер списков </returns>
        public Container ConvertToContainer()
        {
            int lengthOfRow = (int)Math.Sqrt(_firstMatrix.Length);
            int countOfVerticies = 0;
            for (int i = 0; i < lengthOfRow; i++)
            {
                for (int j = 0; j < lengthOfRow; j++)
                {
                    if (_firstMatrix[i, j] != 0 && _secondMatrix[i, j] != 0)
                    {
                        ToFromList(i.ToString());
                        ToWhereList(j.ToString());
                        ToCostList(_secondMatrix[i, j]);
                    }
                }
            }

            for (int vertex = 0; countOfVerticies != lengthOfRow; vertex++)
            {
                countOfVerticies++;
                ToVerticesList(vertex.ToString());
            }

            return _container;
        }

        private void ToFromList(string element) => _container.from.Add(element);
        private void ToWhereList(string element) => _container.where.Add(element);
        private void ToVerticesList(string element) => _container.vertices.Add(element);
        private void ToCostList(int element) => _container.cost.Add(element);
    }
}
