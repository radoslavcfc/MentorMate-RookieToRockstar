using System.Collections.Generic;

namespace GreenVsRed.Nodes
{
    public interface INode 
    {   
        char CurrentValue { get;}

        int GreenNeighboursCount { get; set; }

        public List<int[]> Neighbours { get; set; }

        bool RequiresUpdate();

        INode Update();
    }
}
