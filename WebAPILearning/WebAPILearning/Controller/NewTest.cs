using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPILearning.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewTest : ControllerBase
    {
        // GET: api/<NewTest>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[]
            {
                "value1",
                "value2"
            };
        }

        // GET api/<NewTest>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NewTest>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NewTest>/5
        [HttpPut("{id}")]
        public void Put(int id,
            [FromBody] string value)
        {
        }

        // DELETE api/<NewTest>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}