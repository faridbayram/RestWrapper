namespace RestWrapper.Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public new static IDataResult<T> Succeeded()
        {
            return new SuccessDataResult<T>();

        }

        public new static IDataResult<T> Succeeded(string message)
        {
            return new SuccessDataResult<T>(message);
        }

        public static IDataResult<T> Succeeded(T data)
        {
            return new SuccessDataResult<T>(data);
        }

        public static IDataResult<T> Succeeded(T data, string message)
        {
            return new SuccessDataResult<T>(data, message);
        }

        public new static IDataResult<T> Failure()
        {
            return new ErrorDataResult<T>();
        }

        public new static IDataResult<T> Failure(string message)
        {
            return new ErrorDataResult<T>(message);
        }

        public static IDataResult<T> Failure(T data)
        {
            return new ErrorDataResult<T>(data);
        }

        public static IDataResult<T> Failure(string message, T data)
        {
            return new ErrorDataResult<T>(data, message);
        }
    }
}
