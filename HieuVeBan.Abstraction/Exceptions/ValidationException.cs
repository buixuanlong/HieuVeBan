namespace HieuVeBan.Abstraction.Exceptions
{
    public sealed class ValidationException : Exception
    {
        /// <summary>
        /// Properties invalid
        /// <list>
        /// <item> <see langword="Key" /> is PropertyName  </item>
        /// <item> <see langword="Value" /> is Error message </item>
        /// </list>
        /// </summary>
        public IReadOnlyDictionary<string, string> PropertiesError { get; init; }

        public ValidationException(IReadOnlyDictionary<string, string> propertiesError)
            : base("Invalid object")
        {
            PropertiesError = propertiesError;
        }

        public ValidationException(
            string message,
            IReadOnlyDictionary<string, string> propertiesError,
            Exception? innerException = null) : base(message, innerException)
        {
            PropertiesError = propertiesError;
        }
    }
}
