namespace HieuVeBan.Abstraction.Security;

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

    public static class Client
    {
        public const string AppClient = "af17018c-da72-48c1-add3-05dd29160a97";
    }
}