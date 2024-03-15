using Microsoft.AspNetCore.Mvc;
using tar3.BL;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tar3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            UserDBservices u = new UserDBservices();
            return u.Read();
        }

        [HttpGet("averagePrice")]
        public object GetAvgPriceByCityAndMonth(int month)
        {
            UserDBservices dbs = new UserDBservices();

            List<object> avgPrice = dbs.ReadAvgPricePerNight(month);

            return avgPrice;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       

        // POST api/<UsersController>
        [HttpPost]
        public int Post([FromBody] User u)
        {
            return u.Insert();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{email}")]
        public int Put([FromBody] User u)
        {
            return u.Update();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
