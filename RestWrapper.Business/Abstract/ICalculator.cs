using RestWrapper.Core.Utilities.Results;

namespace RestWrapper.Business.Abstract
{
    public interface ICalculator
    {
        IDataResult<int> Add(int leftOperand, int rightOperand);
        IDataResult<int> Subtract(int leftOperand, int rightOperand);
        IDataResult<int> Multiply(int leftOperand, int rightOperand);
        IDataResult<int> Divide(int leftOperand, int rightOperand);
    }
}
