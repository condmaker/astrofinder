using System;

namespace Astrofinder
{
    /// <summary>
    /// A new exception to show a custom value error.
    /// </summary>
    public class InvalidValueException: Exception
    {
        public InvalidValueException (string message) : base(message)
        { }
    }
}