using System;

namespace Models
{
    public class AvgMeasurementHour
    {
        public long Id { get; set; }
        public long IdNode { get; set; }
        public string Node { get; set; }
        public float? MaxTemperature { get; set; }
        public float? MinTemperature { get; set; }
        public float? Temperature { get; set; }
        public float? MaxAirHumidity { get; set; }
        public float? MinAirHumidity { get; set; }
        public float? AirHumidity { get; set; }
        public float? MaxSoilHumidity { get; set; }
        public float? MinSoilHumidity { get; set; }
        public float? SoilHumidity { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public double Area { get; set; }
    }
}