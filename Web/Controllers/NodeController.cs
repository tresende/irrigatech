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
    public class NodeController : Controller
    {
        #region Private Properites

        private NodeService Service = new NodeService();

        #endregion

        // GET api/values
        [HttpGet]
        public IEnumerable<Node> Get()
        {
            return Service.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Node Get(int id)
        {
            return Service.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Node node)
        {
            this.Service.Save(node);
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
