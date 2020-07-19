using System;
using System.Collections.Generic;

namespace GreenVsRed.Nodes
{
    public interface INode 
    {       
        int GreenNeighboursCount { get; set; }
        public List<int[]> Neighbours { get; set; }
        bool RequiresUpdate();        
    }
}
