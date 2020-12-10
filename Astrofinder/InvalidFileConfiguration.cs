using System;

namespace Astrofinder
{
    /// <summary>
    /// A new exception to show a file load error.
    /// </summary>
    public class InvalidFileConfiguration: Exception
    {
        public InvalidFileConfiguration (string message) : base(message)
        { }
    }
}