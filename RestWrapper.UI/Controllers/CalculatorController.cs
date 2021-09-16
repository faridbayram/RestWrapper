﻿using Microsoft.AspNetCore.Mvc;
using RestWrapper.Business.Abstract;
using RestWrapper.Core.Entities.DTOs;

namespace RestWrapper.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;
        private static object _lockObject = new object();

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }


        [HttpPost("Add")]
        public ActionResult Add(OperationDTO operation)
        {
            lock (_lockObject)
            {
                var result = _calculator.Add(operation.LeftOperand, operation.RightOperand);
                return Ok(result);
            }
        }

        [HttpPost("Divide")]
        public ActionResult Divide(OperationDTO operation)
        {
            lock (_lockObject)
            {
                var result = _calculator.Divide(operation.LeftOperand, operation.RightOperand);
                return Ok(result);
            }
        }

        [HttpPost("Multiply")]
        public ActionResult Multiply(OperationDTO operation)
        {
            lock (_lockObject)
            {
                var result = _calculator.Multiply(operation.LeftOperand, operation.RightOperand);
                return Ok(result);
            }
        }

        [HttpPost("Subtract")]
        public ActionResult Subtract(OperationDTO operation)
        {
            lock (_lockObject)
            {
                var result = _calculator.Subtract(operation.LeftOperand, operation.RightOperand);
                return Ok(result);
            }
        }
    }
}
