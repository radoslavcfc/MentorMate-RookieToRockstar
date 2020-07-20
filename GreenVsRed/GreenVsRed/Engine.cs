using GreenVsRed.Nodes;


namespace GreenVsRed
{
    public class Engine
    {
        private AdjacencyMatrix _matrix;
        public Engine(AdjacencyMatrix matrix)
        {
            this._matrix = matrix;
        }

        public int Start(int targetRow, int targetCol, int generationsCount)
        {
            int result = this._matrix.Nodes[targetRow, targetCol]
                        .GetType() == typeof(GreenNode) ? 1 : 0;

            _matrix.InitialNeighboursAllocate();


            for (int i = 0; i < generationsCount; i++)
            {
                _matrix.CountGreenNeighbours();
                _matrix.UpdateMatrix();

                if (_matrix.Nodes[targetRow, targetCol].GetType() == typeof(GreenNode))
                {
                    result++;
                }
            }

            return result;
        }
    }
}
