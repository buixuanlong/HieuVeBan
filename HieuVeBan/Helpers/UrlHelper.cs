using Microsoft.AspNetCore.Mvc;

namespace HieuVeBan.Helpers
{
    public static class UrlHelper
    {
        public static string GetLocalUrl(this IUrlHelper urlHelper, string localUrl)
        {
            if (!urlHelper.IsLocalUrl(localUrl))
            {
                return urlHelper.Page("/Index");
            }

            return localUrl;
        }
    }
}
