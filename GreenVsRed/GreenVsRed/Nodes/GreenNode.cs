using System.Reflection.Metadata.Ecma335;

namespace GreenVsRed.Nodes
{
   public class GreenNode : Node
    {
        public override char CurrentValue { get => '1'; }

        public override bool RequiresUpdate()
        {
            
                switch (this.GreenNeighboursCount)
                {
                    case 0:
                    case 1:
                    case 4:
                    case 5:
                    case 7:
                    case 8:
                        return true;
                    default:
                        return false;
                }
            }

        public override INode Update()
        {
            var newNode = new RedNode();

            foreach (var neig in this.Neighbours)
            {
                newNode.Neighbours.Add(neig);
            }

            return newNode;
        }
    }
}
