using System;

namespace Models
{
    public class Measurement
    {
        public long Id { get; set; }
        public float? IdNode { get; set; }
        public float? Temperature { get; set; }
        public float? AirHumidity { get; set; }
        public float? SiolHumidity { get; set; }
        public DateTime? MeasurementDate { get; set; }

        public Measurement()
        {
            this.MeasurementDate = DateTime.Now;
        }
    }
}