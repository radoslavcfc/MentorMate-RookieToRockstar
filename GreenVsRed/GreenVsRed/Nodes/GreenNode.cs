namespace GreenVsRed.Nodes
{
    /// <summary>
    /// Child class implementing the abstract Node logic
    /// </summary>
   public class GreenNode : Node
    {
        /// <summary>
        /// Automated overriden property returns the value according to the type
        /// </summary>
        public override char CurrentValue { get => '1'; }

        /// <summary>
        /// Concrete applying of the rules for checking if the node needs to change its color
        /// </summary>
        /// <returns>Boolean result</returns>
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

        /// <summary>
        /// Concrete implementation of the abstract method, switching the type(the color) of the node.
        /// </summary>
        /// <returns>A new node from type RedNode()</returns>
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
