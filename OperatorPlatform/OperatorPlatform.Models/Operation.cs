using OperatorPlatform.Models.Abstractions;
using OperatorPlatform.Models.Enums;
using System;

namespace OperatorPlatform.Models
{
    public class Operation : BaseLogicModel
    {
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public OperationStatus OperationStatus { get; set; }
        public OperationType OperationType { get; set; }
        public decimal Price { get; set; }
        public int Leverage { get; set; }
        public decimal StopLoss { get; set; }
        public decimal StopProfit { get; set; }
        public decimal Total { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public int AlertId { get; set; }
        public int BarId { get; set; }
        public int TickerId { get; set; }
        public virtual Alert Alert { get; set; }
        public virtual Bar Bar { get; set; }
        public virtual Ticker Ticker { get; set; }
    }
}
