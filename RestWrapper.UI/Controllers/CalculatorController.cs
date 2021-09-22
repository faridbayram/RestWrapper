using Microsoft.AspNetCore.Mvc;
using RestWrapper.Business.Abstract;
using RestWrapper.UI.Models;

namespace RestWrapper.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }


        [HttpPost("Add")]
        public ActionResult Add(OperationModel operation)
        {
            var result = _calculator.Add(operation.LeftOperand, operation.RightOperand);

            return Ok(result);
        }

        [HttpPost("Divide")]
        public ActionResult Divide(OperationModel operation)
        {
            var result = _calculator.Divide(operation.LeftOperand, operation.RightOperand);
            return Ok(result);
        }

        [HttpPost("Multiply")]
        public ActionResult Multiply(OperationModel operation)
        {
            var result = _calculator.Multiply(operation.LeftOperand, operation.RightOperand);
            return Ok(result);
        }

        [HttpPost("Subtract")]
        public ActionResult Subtract(OperationModel operation)
        {
            var result = _calculator.Subtract(operation.LeftOperand, operation.RightOperand);
            return Ok(result);
        }
    }
}
