using System.Collections.Generic;

namespace GreenVsRed.Nodes
{
    /// <summary>
    /// Base abstract class implementing the interface and leaving abstract methods for the child classes
    /// </summary>
    public abstract class Node : INode
    {
        /// <summary>
        /// Property keeps the number of the green neighbours (the neighbour elements with value '1')
        /// </summary>
        public int GreenNeighboursCount { get; set; }

        /// <summary>
        /// Property keeps the addresses (coordinates in the matrix) of all the neighbours
        /// </summary>
        public List<int[]> Neighbours { get; set; }

        /// <summary>
        /// Abstract property to keep the current value of the concrete typed child class
        /// </summary>
        public abstract char CurrentValue { get;}

        public Node()
        {            
            this.Neighbours = new List<int[]>();
        }       

        //Abstract methods left for the child classes to implement

        public abstract bool RequiresUpdate();

        public abstract INode Update();        
    }
}
