namespace GreenVsRed.Nodes
{
    public class RedNode : Node 
    {
        /// <summary>
        /// Automated overriden property returns the value according to the type
        /// </summary>
        public override char CurrentValue { get => '0';}
        
        /// <summary>
        /// Concrete applying of the rules for checking if the node needs to change its color
        /// </summary>
        /// <returns>Boolean result</returns>
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

        /// <summary>
        /// Concrete implementation of the abstract method, switching the type(the color) of the node.
        /// </summary>
        /// <returns>A new node from type GreenNode()</returns>
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
