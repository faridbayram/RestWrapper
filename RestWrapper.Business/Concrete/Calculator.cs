using RestSharp;
using RestWrapper.Business.Abstract;

namespace RestWrapper.Business.Concrete
{
    public class Calculator : ICalculator
    {
        public int Add(int leftOperand, int rightOperand)
        {
            var client = new RestClient("http://www.dneonline.com/calculator.asmx");

        }

        public int Subtract(int leftOperand, int rightOperand)
        {
            throw new System.NotImplementedException();
        }

        public int Multiply(int leftOperand, int rightOperand)
        {
            throw new System.NotImplementedException();
        }

        public int Divide(int leftOperand, int rightOperand)
        {
            throw new System.NotImplementedException();
        }
    }
}
