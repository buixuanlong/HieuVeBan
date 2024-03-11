namespace HieuVeBan.Api.Models
{
    internal static class ApiResponseCode
    {
        public const string Succeed = "00";
        public const string TypeErrorValidation = "01";
        public const string ValueErrorValidation = "02";
        public const string ApiVersioningError = "97";
        public const string ApiBehaviorError = "98";
        public const string OtherError = "99";
        public const string UnhandledError = "100";

        // database exception 200
        public const string DbUnhandledError = "299";
        public const string DbUniqueConstraint = "201";
        public const string DbCannotInsertNull = "202";
        public const string DbMaxLengthExceeded = "203";
        public const string DbNumericOverflow = "204";
        public const string DbReferenceConstrain = "205";

        // notfound
        public const string NotFound = "404";

    }
}
