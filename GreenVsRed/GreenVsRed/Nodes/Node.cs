using System.Collections.Generic;

namespace GreenVsRed.Nodes
{
    public abstract class Node : INode
    {
        public IUpdate _update;
        public int GreenNeighboursCount { get; set; }
        public List<int[]> Neighbours { get; set; }
        public abstract char CurrentValue { get;}
        public Node()
        {            
            this.Neighbours = new List<int[]>();
        }

        //public bool UpdateValue()
        //{
        //    this._update.RequiresUpdate();

        //}

       
        public abstract bool RequiresUpdate(); 

    }
}
