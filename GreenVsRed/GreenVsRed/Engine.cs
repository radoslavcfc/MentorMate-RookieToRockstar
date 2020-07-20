using GreenVsRed.Nodes;

namespace GreenVsRed
{
    public class Engine
    {
        private AdjacencyMatrix _matrix;
        public Engine(AdjacencyMatrix matrix)
        {
            if (matrix != null)
            {
                this._matrix = matrix;
            }            
        }

        /// <summary>
        /// This method iterates the matrix methods, for applying all the rules and counting the green appearances of the target element
        /// </summary>
        /// <param name="targetRow">Row of the target element</param>
        /// <param name="targetCol">Column of the target element</param>
        /// <param name="generationsCount">Number of iterations</param>
        /// <returns>It returns how many times the target element was Green (1)</returns>
        public int Start(int targetRow, int targetCol, int generationsCount)
        {
            int result = this._matrix.Nodes[targetRow, targetCol]
                        .GetType() == typeof(GreenNode) ? 1 : 0;

            _matrix.InitialNeighboursAllocate();


            for (int i = 0; i < generationsCount; i++)
            {
                _matrix.CountGreenNeighbours();
                _matrix.UpdateMatrix();

                if (_matrix.Nodes[targetRow, targetCol].GetType() == typeof(GreenNode))
                {
                    result++;
                }
            }

            return result;
        }
    }
}
