using System.Collections.Generic;

namespace Core.Utils.Result.Abstract
{
    public interface IPagingResult<T> : IResult
    {
        IQueryable<T> Data { get; }
        int TotalItemCount { get; }
    }
}
