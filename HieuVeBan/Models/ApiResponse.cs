using System.Text.Json.Serialization;

namespace HieuVeBan.Api.Models
{
    internal abstract class ApiResponse
    {
        [JsonPropertyOrder(-1)]
        public bool Success { get; private set; }

        [JsonPropertyOrder(99)]
        public DateTime Timestamp { get; } = DateTime.UtcNow;
        public ApiResponse(bool success) => Success = success;
    }

    internal class ResponseSuccess<T> : ApiResponse
    {
        public T? Data { get; private set; }
        protected ResponseSuccess(T? data) : base(true) => Data = data;

        public static ResponseSuccess<T> GetInstance(T? data) => new(data);
    }

    internal class ResponseError<T> : ApiResponse
    {
        public string ErrorCode { get; private set; }
        public T? Error { get; private set; }
        private ResponseError(string errorCode, T? errorMessage) : base(false)
        {
            ErrorCode = errorCode;
            Error = errorMessage;
        }

        public static ResponseError<T> GetInstance(T? error) => new(ApiResponseCode.OtherError, error);
        public static ResponseError<T> GetInstance(string errorCode, T? error) => new(errorCode, error);
    }

    internal class PagedResponse<T> : ResponseSuccess<IList<T>>
        where T : class
    {
        public int CurrentPage { get; private set; }
        public int PageCount { get; private set; }
        public int PageSize { get; private set; }
        public int RowCount { get; private set; }
        public int FirstRowOnPage => (CurrentPage - 1) * PageSize + 1;
        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, RowCount);

        private PagedResponse(
            IList<T> data,
            int currentPage,
            int pageCount,
            int pageSize,
            int rowCount) : base(data)
        {
            CurrentPage = currentPage;
            PageCount = pageCount;
            PageSize = pageSize;
            RowCount = rowCount;
        }

        public static PagedResponse<T> GetInstance(
            IList<T> data,
            int currentPage,
            int pageCount,
            int pageSize,
            int rowCount)
            => new(data,
                currentPage,
                pageCount,
                pageSize,
                rowCount);

        public static PagedResponse<T> GetInstance(PagedList<T> pagedList)
            => new(pagedList.Data,
                pagedList.CurrentPage,
                pagedList.PageCount,
                pagedList.PageSize,
                pagedList.RowCount);
    }
}