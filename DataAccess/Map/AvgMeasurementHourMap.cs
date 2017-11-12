using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public partial class MainContext : DbContext
    {
        public static void AvgMeasurementHourMap(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<AvgMeasurementHour>().ToTable("VW_CURRENT_NODE_MEASUREMENT");
            // Primary Key
            map.HasKey(t => t.Id);

            // Table & Column Mappings
            map.Property(t => t.Id).HasColumnName("ID_MEASUREMENT");
            map.Property(t => t.IdNode).HasColumnName("ID_NODE");
            map.Property(t => t.Temperature).HasColumnName("TEMPERATURE");
            map.Property(t => t.MaxTemperature).HasColumnName("MAX_TEMP");
            map.Property(t => t.MinTemperature).HasColumnName("MIN_TEMP");
            map.Property(t => t.AirHumidity).HasColumnName("AIR_HUMIDITY");
            map.Property(t => t.MaxAirHumidity).HasColumnName("MAX_AIR_HUMIDITY");
            map.Property(t => t.MinAirHumidity).HasColumnName("MIN_AIR_HUMIDITY");
            map.Property(t => t.SoilHumidity).HasColumnName("SOIL_HUMIDITY");
            map.Property(t => t.MaxSoilHumidity).HasColumnName("MAX_SOIL_HUMIDITY");
            map.Property(t => t.MinSoilHumidity).HasColumnName("MIN_SOIL_HUMIDITY");
            map.Property(t => t.Node).HasColumnName("NODE_NAME");
            map.Property(t => t.Lat).HasColumnName("LATITUDE");
            map.Property(t => t.Long).HasColumnName("LONGITUDE");
            map.Property(t => t.Area).HasColumnName("AFFECTED_AREA");
        }
    }
}
