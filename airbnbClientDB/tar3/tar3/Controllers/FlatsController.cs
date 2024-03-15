using Microsoft.AspNetCore.Mvc;
using tar3.BL;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tar3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirBNB : ControllerBase
    {
        // GET: api/<FlatsController>
        [HttpGet]
        public IEnumerable<Flat> Get()
        {
            FlatsDBservices F = new FlatsDBservices();
            return F.Read();
        }

        [HttpGet("Maps")]
        public IEnumerable<Flat> GetByCityAndPrice(string city, double price)
        {
            Flat F = new Flat();
            return F.GetByCityAndPrice(city,price);
        }

        // GET api/<FlatsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // POST api/<FlatsController>
        [HttpPost]
        public int Post([FromBody] Flat f)
        {
            return f.Insert();
        }

        // PUT api/<FlatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlatsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
