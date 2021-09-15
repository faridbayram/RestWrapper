namespace RestWrapper.Business.Abstract
{
    public interface ICalculator
    {
        int Add(int leftOperand, int rightOperand);
        int Subtract(int leftOperand, int rightOperand);
        int Multiply(int leftOperand, int rightOperand);
        int Divide(int leftOperand, int rightOperand);
    }
}
