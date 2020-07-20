using System;
using GreenVsRed.Nodes;

namespace GreenVsRed
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var commaSeparator = ",";
            var gridDimensionElements = Console.ReadLine()
                .Split(commaSeparator,StringSplitOptions.RemoveEmptyEntries);

            int width = int.Parse(gridDimensionElements[0]);
            int height = int.Parse(gridDimensionElements[1]);

            var matrix = new AdjacencyMatrix(width, height);

            for (int row = 0; row < matrix.Height; row++)
            {
                string colElements = Console.ReadLine();

                for (int col = 0; col < matrix.Width; col++)
                {
                    var currentNode = colElements[col];
                    if (currentNode == '0')
                    {
                        matrix.Nodes[row, col] = new RedNode();
                    }
                    if (currentNode == '1')
                    {
                        matrix.Nodes[row, col] = new GreenNode();
                    }
                }
            }

            var targetElementInformation = Console.ReadLine().Split(commaSeparator);

            var targetCol = int.Parse(targetElementInformation[0]);
            var targetRow = int.Parse(targetElementInformation[1]);
            var generationCounts = int.Parse(targetElementInformation[2]);

            var engine = new Engine(matrix);
            var result = engine.Start(targetRow, targetCol, generationCounts);

            Console.WriteLine(result);
            Console.ReadKey();           
        }       
    }
}


