using System;
using System.Collections.Generic;
using GreenVsRed.Exceptions;
using GreenVsRed.Nodes;

namespace GreenVsRed
{
    public static class StartUp
    {
        //Declaring the static variables, which will be asigned with values from the input
        //and will be used from the engine class
        static int width;
        static int height;
        static int targetCol;
        static int targetRow;
        static int generationCounts;
        static List<string> inputMatrix = new List<string>();
        const string commaSeparator = ",";

        public static void Main(string[] args)
        {           
            try
            {
                ReadInput();

                //Declaring the matrix and completing it with the data from the input which has been already checked

                var matrix = new AdjacencyMatrix(width, height);
                if (matrix == null)
                {
                    throw new NullReferenceException("Matrix is null");
                }

                for (int row = 0; row < height; row++)
                {
                    var inputRow = inputMatrix[row];
                    for (int col = 0; col < width; col++)
                    {
                        if (inputRow[col] == '1')
                        {
                            matrix.Nodes[row, col] = new GreenNode();
                        }

                        if (inputRow[col] == '0')
                        {
                            matrix.Nodes[row, col] = new RedNode();
                        }
                    }
                }

                //Initialize the Engine class and injecting a reference of the competed matrix.
                //Invoke the Start(...) method for extracting the result
                var engine = new Engine(matrix);
                var result = engine.Start(targetRow, targetCol, generationCounts);

                //Printing the result on the console
                Console.WriteLine(result);
                Console.ReadKey();
            }

            catch (InputException matrixException)
            {
                Console.WriteLine(matrixException.Message);
                //throw;
            }            
        }
       
        /// <summary>
        /// For readability I have moved the static input reading below the Main() method
        /// </summary>
        public static void ReadInput()
        {
            var validator = new InputValidator();

            //Reading and checking the input and extracting the parts 
            string[] gridDimensionElements = Console.ReadLine()
                .Split(commaSeparator, StringSplitOptions.RemoveEmptyEntries);

            bool parsedWidth = int.TryParse(gridDimensionElements[0], out width);           
            bool parsedHeight = int.TryParse(gridDimensionElements[1], out height);
          
            if (parsedWidth && parsedHeight)
            {
                validator.WidthAndHeightValidate(width, height);
            }

            else
            {
                validator.WrongFormat();
            }

            for (int row = 0; row < width; row++)
            {
                var rowInput = Console.ReadLine();
                validator.InputRowValidation(rowInput, width);                
                inputMatrix.Add(rowInput);                
            }

            var targetElementInformation = Console.ReadLine().Split(commaSeparator);

            bool parsedTargetCol = int.TryParse(targetElementInformation[0], out targetCol);
            bool parsedTargetRow = int.TryParse(targetElementInformation[1], out targetRow);

            if (parsedTargetCol && parsedTargetRow)
            {
                validator.TargetDimensionsValitate(targetCol, targetRow, width, height);
            }

            else
            {
                validator.WrongFormat();
            }
            
            generationCounts = int.Parse(targetElementInformation[2]);
        }
    }
}


