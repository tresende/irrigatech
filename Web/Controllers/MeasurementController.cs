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
    public class MeasurementController : Controller
    {
        #region Private Properites

        private MeasurementService Service = new MeasurementService();

        #endregion

        // GET api/values
        [HttpGet]
        public IEnumerable<Measurement> Get()
        {
            var list = Service.All().ToList();
            return Service.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Measurement Get(int id)
        {
            return Service.Get(id);
        }

        // POST api/values
        [HttpPost]
        public object Post([FromBody]Measurement Measurement)
        {
            this.Service.Save(Measurement);
            if (Measurement.SiolHumidity > 800)
            {
                return new
                {
                    green_led = false,
                    red_led = true,
                    servo = true,
                };
            }
            else
            {
                return new
                {
                    green_led = true,
                    red_led = false,
                    servo = false,
                };
            }
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
