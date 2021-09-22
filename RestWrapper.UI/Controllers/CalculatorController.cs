using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestWrapper.Business.Abstract;
using RestWrapper.Core.CrossCuttingConcerns.Logging.DatabaseLoggers;
using RestWrapper.Core.Entities.DTOs;

namespace RestWrapper.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;
        private readonly DatabaseLogger _dbLogger;

        public CalculatorController(ICalculator calculator, DatabaseLogger dbLogger)
        {
            _calculator = calculator;
            _dbLogger = dbLogger;
        }


        [HttpPost("Add")]
        public ActionResult Add(OperationDTO operation)
        {
            //var result = _calculator.Add(operation.LeftOperand, operation.RightOperand);

            var result = _dbLogger.Add();
            return Ok(result);
        }

        [HttpPost("Divide")]
        public ActionResult Divide(OperationDTO operation)
        {
            var result = _calculator.Divide(operation.LeftOperand, operation.RightOperand);
            return Ok(result);
        }

        [HttpPost("Multiply")]
        public ActionResult Multiply(OperationDTO operation)
        {
            var result = _calculator.Multiply(operation.LeftOperand, operation.RightOperand);
            return Ok(result);
        }

        [HttpPost("Subtract")]
        public ActionResult Subtract(OperationDTO operation)
        {
            var result = _calculator.Subtract(operation.LeftOperand, operation.RightOperand);
            return Ok(result);
        }
    }
}
