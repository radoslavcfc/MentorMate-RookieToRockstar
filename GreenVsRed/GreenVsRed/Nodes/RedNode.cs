namespace GreenVsRed.Nodes
{
    public class RedNode : Node 
    {
        public override char CurrentValue { get => '0';}
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
