using Core.Utils.Result.Abstract;

namespace Core.Utils.Result.Concrete
{
    public class PagingResult<T> : Result, IPagingResult<T>
    {
        public PagingResult(IQueryable<T> data, int totalItemCount) : base(true)
        {
            Data = data;
            TotalItemCount = totalItemCount;
        }

        public IQueryable<T> Data { get; }
        public int TotalItemCount { get; }
    }
}
