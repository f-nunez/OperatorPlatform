using OperatorPlatform.Models.Abstractions;
using System.Collections.Generic;

namespace OperatorPlatform.Models
{
    public class Ticker : BaseLogicModel
    {
        public string Name { get; set; }

        public int ExchangeId { get; set; }
        public virtual ICollection<Alert> Alerts { get; set; }
        public virtual ICollection<Bar> Bars { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual Exchange Exchange { get; set; }
    }
}
