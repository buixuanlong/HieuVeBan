namespace HieuVeBan.Configurations;

public static class SecurityConstant
{
    public static class Policies
    {
        public const string InternalPolicy = nameof(InternalPolicy);
        public const string ExternalPolicy = nameof(ExternalPolicy);
    }
    public static class Scopes
    {
        public const string External = "external";
        public const string Internal = "internal";
    }
}