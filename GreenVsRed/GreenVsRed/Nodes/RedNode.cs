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
        public override INode Update()
        {
            var newNode = new GreenNode();

            foreach (var neig in this.Neighbours)
            {
                newNode.Neighbours.Add(neig);
            }

            return newNode;
        }
    }
}
