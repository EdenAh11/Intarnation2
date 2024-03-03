using Microsoft.AspNetCore.Mvc;
using Q1.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vacationsController : ControllerBase
    {
        // GET: api/<vacationsController>
        [HttpGet]
        public IEnumerable<Vacation> Get()
        {
            VacationDBservices vacations = new VacationDBservices();
            return vacations.Read();
        }

        [HttpGet("getByDate/{start}/{end}")]
        public IEnumerable<Vacation> GetByStartAndEndDate(DateTime start, DateTime end)
        {
            Vacation v1 = new Vacation();
            return v1.GetByStartAndEndDate(start, end);
        }

        // GET api/<vacationsController>/5
        [HttpGet("{flatId}")]
        public IEnumerable<Vacation> Get(string flatId)
        {
            Vacation v2 = new Vacation();
            return v2.GetByFlatId(flatId);
        }

        // POST api/<vacationsController>
        [HttpPost]
        public int Post([FromBody] Vacation v)
        {
            return v.Insert();
        }

        // PUT api/<vacationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<vacationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
