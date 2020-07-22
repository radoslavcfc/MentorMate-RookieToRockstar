using System;
using GreenVsRed.Nodes;

namespace GreenVsRed
{
    /// <summary>
    /// Class that runs the iterations of the matrix methods
    /// </summary>
    public class Engine
    {
        private AdjacencyMatrix _matrix;

        public Engine(AdjacencyMatrix matrix)
        {
            if (matrix != null)
            {
                this._matrix = matrix;
            }

            else
            {
                throw new NullReferenceException("Empty matrix");
            }
        }

        /// <summary>
        /// This method iterates the matrix methods, for applying all the rules and counting the green appearances 
        /// of the target element
        /// </summary>
        /// <param name="targetRow">Row of the target element</param>
        /// <param name="targetCol">Column of the target element</param>
        /// <param name="generationsCount">Number of iterations</param>
        /// <returns>It returns how many times the target element was Green (1)</returns>
        public int Start(int targetRow, int targetCol, int generationsCount)
        {
            var currentNode = this._matrix.Nodes[targetRow, targetCol];

            if (currentNode == null)
            {
                throw new NullReferenceException("Current node is null");
            }

            int result = currentNode.GetType() == typeof(GreenNode) ? 1 : 0;
                                  //.CurrentValue == '1'; alternative with type checking above.


            //This method alocates all the neighbours of each element 

            _matrix.InitialNeighboursAllocate();

            for (int i = 0; i < generationsCount; i++)
            {
                _matrix.CountGreenNeighbours();
                _matrix.UpdateMatrix();

                //This could be an alternative check :
                //if (_matrix.Nodes[targetRow, targetCol].GetType() == typeof(GreenNode))

                if (_matrix.Nodes[targetRow, targetCol].CurrentValue == '1')
                {
                    result++;
                }
            }
            return result;
        }
    }
}
