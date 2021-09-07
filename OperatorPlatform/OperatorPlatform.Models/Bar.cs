﻿using OperatorPlatform.Models.Abstractions;
using OperatorPlatform.Models.Enums;
using System;
using System.Collections.Generic;

namespace OperatorPlatform.Models
{
    public class Bar : BaseLogicModel
    {
        public decimal Close { get; set; }
        public int ExchangeBarId { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Open { get; set; }
        public DateTime Time { get; set; }
        public TimeFrame TimeFrame { get; set; }
        public int Volume { get; set; }

        public int TickerId { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual Ticker Ticker { get; set; }
    }
}
