namespace HieuVeBan.Models.Abstractions
{
    public record Error(string Code, string Name)
    {
        #region Fields

        public static Error None = new(string.Empty, string.Empty);

        public static Error NullValue = new("Error.NullValue", "Null value was provided");
        public static Error NotFound = new("Error.NotFound", "Not found");

        #endregion
    }
}