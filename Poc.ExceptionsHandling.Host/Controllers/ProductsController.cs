using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// Don't throw exceptions in C#. Do this instead
// https://www.youtube.com/watch?v=a1ye9eGTB98&ab_channel=NickChapsas

namespace Poc.ExceptionsHandling.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<Products>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Products>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Products>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

     
    }
}
