using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public partial class MainContext : DbContext
    {
        public static void MeasurementMap(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Measurement>().ToTable("MEASUREMENT");
            // Primary Key
            map.HasKey(t => t.Id);

            // Table & Column Mappings
            map.Property(t => t.Id).HasColumnName("ID_MEASUREMENT");
            map.Property(t => t.Temperature).HasColumnName("TEMPERATURE");
            map.Property(t => t.AirHumidity).HasColumnName("AIR_HUMIDITY");
            map.Property(t => t.SiolHumidity).HasColumnName("SOIL_HUMIDITY");
            map.Property(t => t.MeasurementDate).HasColumnName("MEASUREMENT_DATE");
            map.Property(t => t.IdNode).HasColumnName("ID_NODE");
        }
    }
}
