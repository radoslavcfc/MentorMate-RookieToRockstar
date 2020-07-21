using System.Collections.Generic;

namespace GreenVsRed.Nodes
{
    public abstract class Node : INode
    {
        public int GreenNeighboursCount { get; set; }
        public List<int[]> Neighbours { get; set; }
        public abstract char CurrentValue { get;}
        public Node()
        {            
            this.Neighbours = new List<int[]>();
        }       
        public abstract bool RequiresUpdate();

        public abstract INode Update();
        
    }
}
