using Core.Utils.Result.Abstract;

namespace Core.Utils.Result.Concrete
{
    public class PaginatedResult<T> : IDataResult<T>
    {
        public PaginatedResult(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber <= 0 ? 1 : pageNumber;
            PageSize = pageSize <= 0 ? 1 : pageSize;
            Data = data;
            IsSuccessful = true;
        }

        public bool IsSuccessful { get; set; }
        public string Message { get; }
        public T Data { get; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string FirstPage { get; set; }
        public string LastPage { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}