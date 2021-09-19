namespace OperatorPlatform.Models.DataTransferObjects
{
    public class BarAlertDto
    {
        public string BollingerLowerBandFirst { get; set; }
        public string BollingerLowerBandSecond { get; set; }
        public string BollingerLowerBandThird { get; set; }
        public string BollingerUpperBandFirst { get; set; }
        public string BollingerUpperBandSecond { get; set; }
        public string BollingerUpperBandThird { get; set; }
        public string Close { get; set; }
        public string ExchangeBarId { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string MovingAverage { get; set; }
        public string Open { get; set; }
        public string TickerName { get; set; }
        public string Time { get; set; }
        public string Volume { get; set; }
    }
}
