using Models;
using System.Linq;

namespace Services
{
    public class MeasurementService : Service<Measurement>
    {
        public Measurement GetLastByNode(int id)
        {
            return this.context.Measurements.Where(x => x.IdNode == id).OrderByDescending(x => x.Id).Last();
        }
    }
}
