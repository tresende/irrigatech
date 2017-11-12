using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class AvgMeasurementHourController : Controller
    {
        #region Private Properites

        private AvgMeasurementHourService Service = new AvgMeasurementHourService();

        #endregion

        // GET api/values
        [HttpGet]
        public IEnumerable<AvgMeasurementHour> Get()
        {
            return Service.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public AvgMeasurementHour Get(int id)
        {
            return Service.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]AvgMeasurementHour AvgMeasurementHour)
        {   
            this.Service.Save(AvgMeasurementHour);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Service.Delete(id);
        }
    }
}
