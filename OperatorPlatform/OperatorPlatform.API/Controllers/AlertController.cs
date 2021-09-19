using Microsoft.AspNetCore.Mvc;
using OperatorPlatform.Models.DataTransferObjects;

namespace OperatorPlatform.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostBarAlert(BarAlertDto barAlert)
        {
            var resultMessage = $"The ticker that comes from BarAlert is {barAlert.TickerName.ToUpper()}";
            return Ok(resultMessage);
        }

        [HttpPost]
        public IActionResult PostIndicatorAlert(IndicatorAlertDto indicatorAlert)
        {
            var resultMessage = $"The ticker that comes from IndicatorAlert is {indicatorAlert.TickerName.ToUpper()}";
            return Ok(resultMessage);
        }
    }
}
