using Microsoft.AspNetCore.Mvc;
using RestWrapper.Core.Entities.DTOs;

namespace RestWrapper.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {

        [HttpPost("Add")]
        public ActionResult Add(OperationDTO operation)
        {
            return Ok(operation.LeftOperand + operation.RightOperand);
        }
    }
}
