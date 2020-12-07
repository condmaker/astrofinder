using System;

namespace Astrofinder
{
    public class InvalidFileConfiguration: Exception
    {
        public InvalidFileConfiguration (string message) : base(message)
        { }
    }
}