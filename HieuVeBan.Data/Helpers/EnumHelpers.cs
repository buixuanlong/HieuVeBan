using System.Text;

namespace HieuVeBan.Data.Helpers;

public static class EnumHelpers
{
    /// <summary>
    /// Get enum description
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    public static string GetDescriptions<TEnum>() where TEnum : System.Enum
    {
        StringBuilder sb = new($"Type of {typeof(TEnum).Name}");

        if (typeof(TEnum).IsDefined(typeof(FlagsAttribute), false))
        {
            sb.Append("(many choices)");
        }

        sb.Append(':');

        foreach (TEnum enumValue in System.Enum.GetValues(typeof(TEnum)))
        {
            sb.Append($" {Convert.ToInt32(enumValue)} {enumValue},");
        }

        // Remove end character ','
        sb.Length--;

        return sb.ToString();
    }
}