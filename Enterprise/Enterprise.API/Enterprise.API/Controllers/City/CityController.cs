using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HM = Enterprise.DataLayers.EnterpriseDB_HelperModel;
using HB = Enterprise.API.BusinessLogics.City.CityBusinessLogic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.City
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly HM.HelperContext _context;
        public CityController(HM.HelperContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<HM.TblCity> Get()
        {
            return HB.GetListOfCity(_context);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return HB.GetCityById(id, _context);
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
