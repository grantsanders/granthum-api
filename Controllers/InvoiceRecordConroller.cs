using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace granthum_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceRecordConroller : ControllerBase
    {
        // GET: api/Project
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Project/{id}
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Project
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Project/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Project/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
