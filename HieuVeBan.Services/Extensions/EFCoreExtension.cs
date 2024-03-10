using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HieuVeBan.Services.Extensions;

static class EFCoreExtension
{
    public static string SQL_CI_AI_COLLATE = "Latin1_General_CI_AI";
    public static IQueryable<T> ContainWithCollation<T>(this IQueryable<T> query,
        Expression<Func<T, string>> keySelector,
        string value) where T : class
    {
        if (string.IsNullOrWhiteSpace(value) || keySelector is null)
            return query;

        MemberExpression memberExpression = (MemberExpression)keySelector.Body;
        var propertyName = memberExpression.Member.Name;

        query = query.Where(x => EF.Functions.Like(
                EF.Functions.Collate(
                    EF.Property<string>(x, propertyName), SQL_CI_AI_COLLATE),
                EF.Functions.Collate($"%{value}%", SQL_CI_AI_COLLATE)));

        return query;
    }
}