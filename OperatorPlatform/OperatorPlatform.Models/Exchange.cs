using OperatorPlatform.Models.Abstractions;
using System.Collections.Generic;

namespace OperatorPlatform.Models
{
    public class Exchange : BaseLogicModel
    {
        public string Name { get; set; }
        public virtual ICollection<Ticker> Tickers { get; set; }
    }
}
