using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace System.Collections.Generic
{
    public abstract class PagedListBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }

    public class PagedList<T> : PagedListBase where T : class
    {
        public IList<T> Data { get; set; }

        public PagedList()
        {
            Data = new List<T>();
        }
    }
    public class QueryParams
    {
        private int _pageIndex;
        private int _pageSize;
        protected virtual int DefaultPageSize => 20;
        protected virtual int MaxPageSize => 100;

        public virtual int PageIndex
        {
            get { return Math.Max(_pageIndex, 1); }
            init { _pageIndex = value; }
        }
        public virtual int PageSize
        {
            get
            {
                return _pageSize == 0
                    ? DefaultPageSize
                    : Math.Min(_pageSize, MaxPageSize);
            }

            init { _pageSize = value; }
        }
        public string? OrderBy { get; init; }
    }
    public static class PagedListExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> query, QueryParams queryParams) where T : class
        {
            var result = new PagedList<T>
            {
                CurrentPage = queryParams.PageIndex,
                PageSize = queryParams.PageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / queryParams.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            if (queryParams.PageIndex > result.PageCount)
                return result;
            var skip = (queryParams.PageIndex - 1) * queryParams.PageSize;
            result.Data = query.Sort(queryParams.OrderBy).Skip(skip).Take(queryParams.PageSize).ToList();

            return result;
        }

        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query,
            QueryParams queryParams,
            CancellationToken cancellationToken = default) where T : class
        {
            var result = new PagedList<T>
            {
                CurrentPage = queryParams.PageIndex,
                PageSize = queryParams.PageSize,
                RowCount = await query.CountAsync(cancellationToken)
            };

            var pageCount = (double)result.RowCount / queryParams.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            if (queryParams.PageIndex > result.PageCount)
                return result;

            var skip = (queryParams.PageIndex - 1) * queryParams.PageSize;

            result.Data = await query
                .Sort(queryParams.OrderBy)
                .Skip(skip).Take(queryParams.PageSize)
                .ToListAsync(cancellationToken);

            return result;
        }

        public static PagedList<TModel> ToPagedList<T, TModel>(this IQueryable<T> query,
            QueryParams queryParams,
            IConfigurationProvider configurationProvider) where TModel : class
        {
            var result = new PagedList<TModel>
            {
                CurrentPage = queryParams.PageIndex,
                PageSize = queryParams.PageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / queryParams.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            if (queryParams.PageIndex > result.PageCount)
                return result;
            var skip = (queryParams.PageIndex - 1) * queryParams.PageSize;
            result.Data = query.Sort(queryParams.OrderBy)
                                .Skip(skip).Take(queryParams.PageSize)
                                .ProjectTo<TModel>(configurationProvider)
                                .ToList();
            return result;
        }

        public static PagedList<TModel> ToPagedList<TModel>(this IEnumerable<TModel> query, QueryParams queryParams) where TModel : class
        {
            var result = new PagedList<TModel>
            {
                CurrentPage = queryParams.PageIndex,
                PageSize = queryParams.PageSize,
                RowCount = query.Count()
            };

            var pageCount = (double)result.RowCount / queryParams.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            if (queryParams.PageIndex > result.PageCount)
                return result;
            var skip = (queryParams.PageIndex - 1) * queryParams.PageSize;
            result.Data = query.AsQueryable().Sort(queryParams.OrderBy)
                                .Skip(skip).Take(queryParams.PageSize)
                                .ToList();
            return result;
        }
        public static async Task<PagedList<TModel>> ToPagedListAsync<T, TModel>(this IQueryable<T> query,
            QueryParams queryParams,
            IConfigurationProvider configurationProvider,
            CancellationToken cancellationToken = default) where TModel : class
        {
            var result = new PagedList<TModel>
            {
                CurrentPage = queryParams.PageIndex,
                PageSize = queryParams.PageSize,
                RowCount = await query.CountAsync(cancellationToken)
            };

            var pageCount = (double)result.RowCount / queryParams.PageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            if (queryParams.PageIndex > result.PageCount)
                return result;

            var skip = (queryParams.PageIndex - 1) * queryParams.PageSize;

            result.Data = await query.Sort(queryParams.OrderBy)
                .Skip(skip).Take(queryParams.PageSize)
                .ProjectTo<TModel>(configurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
        public static PagedList<TModel> ToPagedList<T, TModel>(this DbSet<T> query, QueryParams queryParams, IConfigurationProvider configurationProvider) where T : class where TModel : class
        {
            return query.AsQueryable().ToPagedList<T, TModel>(queryParams, configurationProvider);
        }

        public static async Task<PagedList<TModel>> ToPagedListAsync<T, TModel>(this DbSet<T> query,
            QueryParams queryParams,
            IConfigurationProvider configurationProvider,
            CancellationToken cancellationToken = default) where T : class where TModel : class
        {
            return await query.AsQueryable().ToPagedListAsync<T, TModel>(queryParams, configurationProvider, cancellationToken);
        }

        private static IQueryable<T> Sort<T>(this IQueryable<T> entities, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return entities;

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.TrimStart().Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

                entities = param.EndsWith(" desc") ? entities.OrderByDescending(objectProperty.Name) : entities.OrderBy(objectProperty.Name);
            }

            return entities;
        }
    }
}

