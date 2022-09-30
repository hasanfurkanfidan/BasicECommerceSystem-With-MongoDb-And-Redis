namespace Core.Utils.Result.Abstract
{
    public interface IResult
    {
        bool IsSuccessful { get; }
        string Message { get; }
    }
}