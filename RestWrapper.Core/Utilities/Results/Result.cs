namespace RestWrapper.Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }

        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }


        public static Result Succeeded()
        {
            return new SuccessResult();
        }

        public static Result Succeeded(string message)
        {
            return new SuccessResult(message);
        }

        public static Result Failure()
        {
            return new ErrorResult();
        }

        public static Result Failure(string message)
        {
            return new ErrorResult(message);
        }
    }
}
