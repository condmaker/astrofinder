using System;

namespace Astrofinder
{
    public class InvalidValueException: Exception
    {
        public InvalidValueException (string message) : base(message)
        { }
    }
}