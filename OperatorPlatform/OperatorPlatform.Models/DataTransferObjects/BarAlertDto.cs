using OperatorPlatform.Models.Enums;
using System;

namespace OperatorPlatform.Models.DataTransferObjects
{
    public class BarAlertDto
    {
        public decimal BollingerLowerBandFirst { get; set; }
        public decimal BollingerLowerBandSecond { get; set; }
        public decimal BollingerLowerBandThird { get; set; }
        public decimal BollingerUpperBandFirst { get; set; }
        public decimal BollingerUpperBandSecond { get; set; }
        public decimal BollingerUpperBandThird { get; set; }
        public decimal Close { get; set; }
        public int ExchangeBarId { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal MovingAverage { get; set; }
        public decimal Open { get; set; }
        public string TickerName { get; set; }
        public DateTime Time { get; set; }
        public TimeFrame TimeFrame { get; set; }
        public int Volume { get; set; }
    }
}
