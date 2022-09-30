namespace Core.Utils.Result.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}