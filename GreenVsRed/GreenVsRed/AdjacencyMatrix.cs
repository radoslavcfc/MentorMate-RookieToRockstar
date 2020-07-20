using GreenVsRed.Nodes;
using System;
using System.Collections.Generic;

namespace GreenVsRed
{
    public class AdjacencyMatrix
    {
        private int _width;
        private int _height;
        public int Width 
        { 
            get; 
            set; 
        }
        public int Height
        {
            get;
            set;
        }
        public INode[,] Nodes{ get; set; }

        public List<int[]> UpdateCoordinates { get; set; }

        public AdjacencyMatrix(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Nodes = new INode[width, height];                   
        }      

       
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
                        if (this.Nodes[neighbour[0],neighbour[1]].GetType() == typeof(GreenNode))
                        {
                            currentNode.GreenNeighboursCount++;
                        }
                    }

                    if (currentNode.RequiresUpdate())
                    {
                        this.UpdateCoordinates.Add(new int[] {row, col});
                    }
                }
            }
        }

        public void UpdateMatrix()
        {
            foreach (var item in UpdateCoordinates)
            {
                var x = item[0];
                var y = item[1];
                var elementToUpdate = this.Nodes[x, y];
                var toUpdateType = elementToUpdate.GetType();
               
                this.Nodes[x, y] = this.ChangeType(toUpdateType);

                foreach (var neig in elementToUpdate.Neighbours)
                {
                    Nodes[x, y].Neighbours.Add(neig);
                }
            }
        }

        private INode ChangeType(Type toUpdate)
        {
            if (toUpdate == typeof(GreenNode))
            {
                return new RedNode();
            }
            else
            {
                return new GreenNode();
            }
        }
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

        private void NeighboursAllocate(Node currentNode, int row, int col)
        {
            var upRowIndex = row - 1;
            var downRowIndex = row + 1;
            var leftColIndex = col - 1;
            var rightColIndex = col + 1;

            var upperRowExists = upRowIndex >= 0;
            var downRowExists = downRowIndex < Height;
            var leftColExists = leftColIndex >= 0;
            var rightColExists = rightColIndex < Width;

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
