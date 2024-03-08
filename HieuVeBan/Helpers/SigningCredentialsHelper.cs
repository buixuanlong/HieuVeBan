using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace HieuVeBan.Helpers;
public static class SigningCredentialsHelper
{
    public static SigningCredentials BuildCredentialsSha256(string secret)
    {
        var key = BuildSymmetricSecurityKey(secret);
        return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    public static SymmetricSecurityKey BuildSymmetricSecurityKey(string secret)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        return key;
    }
}