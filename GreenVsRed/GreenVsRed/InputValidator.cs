﻿using GreenVsRed.Exceptions;

namespace GreenVsRed
{
    public class InputValidator
    {
        private const string positiveWidthMessage = "Width must be positive number bigger than zero!";
        private const string positiveHeightMessage = "Height must be positive number bigger than zero!";
        private const string heightLimitMessage = "Height must a number up to 1000!";
        private const string widthLimitMessage = "Width must me smaller or equal to the height!";
        private const string rowLimitMessage = "Row input must not be longer than the width of the matrix";
        private const string rowInputElementsMessage = "Elements in the matrix must be either 1 or 0";
        private const string targetRowHeightMessage = "The target height must not be bigger than the matrix height";
        private const string targetRowBottomMessage = "The target height must be a positive number";
        private const string targetColWidhtMessage = "The target width must not be bigger than the matrix width";
        private const string targetColBottomMessage = "The target width must be a positive number";
        private const string wrongFormatMessage = "Incorrect format of the matrix dimensions";

        public void WidthAndHeightValidate(int width, int height)
        {
            
            if (width <= 0 )
            {
                throw new InputException(positiveWidthMessage);
            }

            if (height <= 0)
            {
                throw new InputException(positiveHeightMessage);               
            }

            if (height >= 1000 )
            {
                throw new InputException(heightLimitMessage);                
            }
            
            if (width > height)
            {
                throw new InputException(widthLimitMessage);
            }
        }

        public void InputRowValidation(string row, int width)
        {
            if (row.Length != width)
            {
                throw new InputException(rowLimitMessage);
            }

            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] != '0' && row[i] !='1')
                {
                    throw new InputException(rowInputElementsMessage);
                    
                }
            }
        }

        public void TargetDimensionsValitate(int targetCol, int targetRow, int width, int height)
        {
            if (targetRow > height)
            {
                throw new InputException(targetRowHeightMessage);
            }

            if (targetRow < 0)
            {
                throw new InputException(targetRowBottomMessage);
            }

            if (targetCol > width)
            {
                throw new InputException(targetColWidhtMessage);

            }

            if (targetCol < 0)
            {
                throw new InputException(targetColBottomMessage);
            }
        }

        /// <summary>
        /// This methods extends the built-in validation for parsing the string element to a integer.
        /// It throws the custom exception with the custom message
        /// </summary>
        public void WrongFormat()
        {
            throw new InputException(wrongFormatMessage);
        }
    }
}