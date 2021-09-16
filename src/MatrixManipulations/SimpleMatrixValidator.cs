using System;

namespace Dijkstra.MatrixManipulations
{
    public class SimpleMatrixValidator
    {
        private int[,] _firstMatrix;
        private int[,] _secondMatrix;

        public SimpleMatrixValidator(int[,] firstMatrix, int[,] secondMatrix)
        {
            _firstMatrix = firstMatrix;
            _secondMatrix = secondMatrix;
        }

        /// <summary>
        /// Проверяет является ли размер двух массивов идентичным
        /// </summary>
        /// <returns></returns>
        public bool CheckIfSizeEqual() => _firstMatrix.Length == _secondMatrix.Length;

        /// <summary>
        /// Проверяет противоречит маршрутизация в матрице смежности с матрицой стоимости
        /// (Когда маршрута нет, а стоимость для пути есть)
        /// </summary>
        /// <returns></returns>
        public bool CheckIfRoutsEqual()
        {
            int correctMatches = 0;
            int lengthOfRow = (int)Math.Sqrt(_firstMatrix.Length);

            for (int i = 0; i < lengthOfRow; i++)
            {
                for (int j = 0; j < lengthOfRow; j++)
                {
                    if (HasSameRoutes(i, j))
                    {
                        correctMatches++;
                    }
                    else
                    {
                        Console.WriteLine("This matrix has errors! Try another matrix.");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Конкретизированная проверка правильности маршрутизации в матрицах по индексам
        /// </summary>
        /// <param name="firstIndex"> первый индекс </param>
        /// <param name="secondIndex"> второй индекс </param>
        /// <returns>Логическое true - если пути одинаково выстроены в матрицах, Логическое false - если пути выстроены неодинаково </returns>
        private bool HasSameRoutes(int firstIndex, int secondIndex)
        {
            return (_firstMatrix[firstIndex, secondIndex] == 0 && _secondMatrix[firstIndex, secondIndex] == 0) ||
                (_firstMatrix[firstIndex, secondIndex] != 0 && _secondMatrix[firstIndex, secondIndex] != 0);
        }

    }
}
