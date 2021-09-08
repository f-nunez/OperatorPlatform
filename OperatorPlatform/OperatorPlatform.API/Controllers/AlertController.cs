using Microsoft.AspNetCore.Mvc;
using OperatorPlatform.Models.DataTransferObjects;

namespace OperatorPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostAddAlert(AlertDto alertDto)
        {
            var resultMessage = $"The ticker that comes from alert is {alertDto.Ticker.ToUpper()}";
            return Ok(resultMessage);
        }
    }
}
