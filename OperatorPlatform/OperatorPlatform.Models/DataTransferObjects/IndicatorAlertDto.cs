using OperatorPlatform.Models.Enums;
using System;

namespace OperatorPlatform.Models.DataTransferObjects
{
    public class IndicatorAlertDto
    {
        public string IndicatorDescription { get; set; }
        public string IndicatorName { get; set; }
        public OperationType OperationType { get; set; }
        public string TickerName { get; set; }
        public DateTime? Time { get; set; }
        public TimeFrame TimeFrame { get; set; }
    }
}
