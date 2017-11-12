using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public partial class MainContext : DbContext
    {
        public static void NodeMap(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Node>().ToTable("SENSOR_NODE");
            // Primary Key
            map.HasKey(t => t.Id);

            // Table & Column Mappings
            map.Property(t => t.Id).HasColumnName("ID_NODE");
            map.Property(t => t.Name).HasColumnName("NODE_NAME");
            map.Property(t => t.Lat).HasColumnName("LATITUDE");
            map.Property(t => t.Long).HasColumnName("LONGITUDE");
            map.Property(t => t.Area).HasColumnName("AFFECTED_AREA");
        }
    }
}
