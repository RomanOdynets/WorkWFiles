using System;

namespace WorkWFiles.Exceptions
{
    class UserModelParseException : Exception
    {
        public UserModelParseException(string message) : base(message)
        {
        }
    }
}
