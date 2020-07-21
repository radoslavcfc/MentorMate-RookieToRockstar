using System;

namespace GreenVsRed.Exceptions
{
    /// <summary>
    /// Custom exception class inherits the main System.Exception class
    /// </summary>
    public class InputException : Exception
    {
        public InputException(string message) : base(message)
        {

        }
    }
}
