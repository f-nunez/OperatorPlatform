using OperatorPlatform.Models.Abstractions;
using System.Collections.Generic;

namespace OperatorPlatform.Models
{
    public class Indicator : BaseLogicModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BarsToLookBack { get; set; }

        public virtual ICollection<Alert> Alerts { get; set; }
    }
}
