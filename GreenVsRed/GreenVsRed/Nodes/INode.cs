using System;
using System.Collections.Generic;

namespace GreenVsRed.Nodes
{
    public interface INode 
    {   
        char CurrentValue { get; set; }
        int GreenNeighboursCount { get; set; }
        public List<int[]> Neighbours { get; set; }

        bool RequiresUpdate();        
    }
}
