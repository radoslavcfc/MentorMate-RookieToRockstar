using GreenVsRed.Nodes;
using System.Collections.Generic;

namespace GreenVsRed
{
    /// <summary>
    /// The main matrix class containing the elements and the main logic 
    /// </summary>
    public class AdjacencyMatrix
    {
        /// <summary>
        /// Matrix width 
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Matrix height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Actual data kept in matrix of Nodes
        /// </summary>
        public INode[,] Nodes { get; set; }

        /// <summary>
        /// Keeps the current addresses (indexes in the matrix) for all the elements that will need to be updated on each iteration
        /// </summary>
        public List<int[]> UpdateCoordinates { get; set; }

        public AdjacencyMatrix(int width, int height)
        {
            this.Height = height;
            this.Width = width;
            this.Nodes = new INode[width, height];
        }

        /// <summary>
        /// 
        /// </summary>
        public void CountGreenNeighbours()
        {
            this.UpdateCoordinates = new List<int[]>();

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    var currentNode = Nodes[row, col];
                    currentNode.GreenNeighboursCount = 0;

                    foreach (var neighbour in currentNode.Neighbours)
                    {
                        if (this.Nodes[neighbour[0], neighbour[1]].CurrentValue == '1')
                        {
                            currentNode.GreenNeighboursCount++;
                        }
                    }

                    if (currentNode.RequiresUpdate())
                    {
                        this.UpdateCoordinates.Add(new int[] { row, col });
                    }
                }
            }
        }

        /// <summary>
        /// Method for updating the matrix on each iteration. It finds all the nodes that are booked in the UpdateCoordinates 
        /// property.
        /// </summary>
        public void UpdateMatrix()
        {
            foreach (var item in this.UpdateCoordinates)
            {
                var x = item[0];
                var y = item[1];
                var elementToUpdate = this.Nodes[x, y];
                this.Nodes[x, y] = elementToUpdate.Update();                
            }
        }

        /// <summary>
        /// This method is ran only once after the matrix is filled up with its data. 
        /// This will save neighbour allocation on each iteration 
        /// </summary>
        public void InitialNeighboursAllocate()
        {
            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    var currentNode = Nodes[row, col];
                    this.NeighboursAllocate((Node)currentNode, row, col);
                }
            }
        }
        /// <summary>
        /// Separated method responsible only for allocating the neighbours which are checked first if they are in the matrix
        /// boundaries
        /// </summary>
        /// <param name="currentNode">The node that will receive the neighbours</param>
        /// <param name="row">The row index of the current node</param>
        /// <param name="col">The column index of the current node</param>
        private void NeighboursAllocate(Node currentNode, int row, int col)
        {
            //Asigning the neighbour indexes first
            var upRowIndex = row - 1;
            var downRowIndex = row + 1;
            var leftColIndex = col - 1;
            var rightColIndex = col + 1;

            //Booleans showing if the neighbour index is in the matrix boundaries
            var upperRowExists = upRowIndex >= 0;
            var downRowExists = downRowIndex < Height;
            var leftColExists = leftColIndex >= 0;
            var rightColExists = rightColIndex < Width;

            //In accordance with the boolean results the node will register its neighbours
            if (upperRowExists)
            {
                currentNode.Neighbours.Add(new int[] { upRowIndex, col });
            }

            if (upperRowExists && leftColExists)
            {
                currentNode.Neighbours.Add(new int[] { upRowIndex, leftColIndex });
            }

            if (upperRowExists && rightColExists)
            {
                currentNode.Neighbours.Add(new int[] { upRowIndex, rightColIndex });
            }

            if (leftColExists)
            {
                currentNode.Neighbours.Add(new int[] { row, leftColIndex });
            }

            if (rightColExists)
            {
                currentNode.Neighbours.Add(new int[] { row, rightColIndex });
            }

            if (downRowExists)
            {
                currentNode.Neighbours.Add(new int[] { downRowIndex, col });
            }

            if (downRowExists && leftColExists)
            {
                currentNode.Neighbours.Add(new int[] { downRowIndex, leftColIndex });
            }

            if (downRowExists && rightColExists)
            {
                currentNode.Neighbours.Add(new int[] { downRowIndex, rightColIndex });
            }
        }
    }
}
