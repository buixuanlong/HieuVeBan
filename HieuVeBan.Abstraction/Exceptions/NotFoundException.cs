namespace HieuVeBan.Abstraction.Exceptions
{
    public sealed class NotFoundException : Exception
    {
        /// <summary>
        /// Value
        /// </summary>
        public object? Value { get; init; }

        public NotFoundException(object? value = null) : base("Resource not found")
        {
            Value = value;
        }

        public NotFoundException(
            string message,
            object? value = null,
            Exception? innerException = null) : base(message, innerException)
        {
            Value = value;
        }
    }
}
