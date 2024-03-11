namespace HieuVeBan.Abstraction.Exceptions
{
    public sealed class PermissionDeniedException : Exception
    {
        public PermissionDeniedException() : base("Permission denied")
        { }

        public PermissionDeniedException(string message, Exception? innerException = null)
            : base(message, innerException)
        { }
    }
}
