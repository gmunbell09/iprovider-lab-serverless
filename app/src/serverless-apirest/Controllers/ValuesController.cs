using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructure.Dapper.PostgreSQL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace serverless_apirest.Controllers
{
    [Route("v1/[controller]")]
    public class ValuesController : ControllerBase
    {
        public readonly ICrudRepository _crudRepositoy;

        public ValuesController(ICrudRepository crudRepository) 
        {
            _crudRepositoy = crudRepository;
        }

        // GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    var result = _crudRepositoy.ReadQuery();
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var result = _crudRepositoy.ReadQuery();
            return new OkObjectResult(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
        }
    }
}
