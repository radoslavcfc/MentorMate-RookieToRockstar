namespace GreenVsRed.Nodes
{
    public class RedNode : Node
    {
        public override bool RequiresUpdate()
        {

            switch (this.GreenNeighboursCount)
            {
                case 3:
                case 6:
                    return true;
                default:
                    return false;
            }
        }
    }
}
