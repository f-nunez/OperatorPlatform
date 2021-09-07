using OperatorPlatform.Models.Abstractions;
using OperatorPlatform.Models.Enums;
using System;
using System.Collections.Generic;

namespace OperatorPlatform.Models
{
    public class Alert : BaseLogicModel
    {
        public string Description { get; set; }
        public int ExchangeBarId { get; set; }
        public OperationType OperationType { get; set; }
        public DateTime ReceivedOn { get; set; }
        public AlertStatus Status { get; set; }
        public TimeFrame TimeFrame { get; set; }
        public DateTime UpdatedOn { get; set; }

        public int IndicatorId { get; set; }
        public int TickerId { get; set; }
        public virtual Indicator Indicator { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual Ticker Ticker { get; set; }
    }
}
