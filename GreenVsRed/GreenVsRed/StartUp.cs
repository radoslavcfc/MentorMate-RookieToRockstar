using System;
using GreenVsRed.Exceptions;
using GreenVsRed.Nodes;

namespace GreenVsRed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                const string commaSeparator = ",";
                const string matrixErrorMessage = "Element of the matrix must be either 1 or 0";
                //Reading the input and extracting the parts

                var gridDimensionElements = Console.ReadLine()
                    .Split(commaSeparator, StringSplitOptions.RemoveEmptyEntries);

                int width = int.Parse(gridDimensionElements[0]);
                int height = int.Parse(gridDimensionElements[1]);

                //Initialize the matrix and assigning the elements of it from the input
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
                        else
                        {
                            throw new MatrixException(matrixErrorMessage);
                        }
                    }
                }

                var targetElementInformation = Console.ReadLine().Split(commaSeparator);

                var targetCol = int.Parse(targetElementInformation[0]);
                var targetRow = int.Parse(targetElementInformation[1]);
                var generationCounts = int.Parse(targetElementInformation[2]);

                //Initialize the Engine class and injecting a reference of the competed matrix.
                //Invoke the Start(...) method for extracting the result
                var engine = new Engine(matrix);
                var result = engine.Start(targetRow, targetCol, generationCounts);

                //Printing the result on the console
                Console.WriteLine(result);
                Console.ReadKey();
            }
            catch (MatrixException matrixException)
            {
                Console.WriteLine(matrixException.Message);
                //throw;
            }
            
        }       
    }
}


