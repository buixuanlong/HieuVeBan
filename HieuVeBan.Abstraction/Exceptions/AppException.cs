﻿namespace HieuVeBan.Abstraction.Exceptions
{
    public sealed class AppException : Exception
    {
        public AppException(string message) : base(message)
        { }

        public AppException(string message, Exception? innerException = null) : base(message, innerException)
        { }
    }
}
