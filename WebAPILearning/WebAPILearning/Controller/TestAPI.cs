using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPILearning.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAPI : ControllerBase
    {
        // GET: api/<TestAPI>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
