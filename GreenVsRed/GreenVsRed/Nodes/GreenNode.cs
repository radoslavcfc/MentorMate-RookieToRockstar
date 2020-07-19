namespace GreenVsRed.Nodes
{
   public class GreenNode : Node
    {
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
    }
}
