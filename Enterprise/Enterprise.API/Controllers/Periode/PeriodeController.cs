using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Core.Services.Periode;
using Enterprise.Core.Services.Periode.Abstract;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Periode
{
    [Route("api/[controller]")]
    public class PeriodeController : Controller
    {
        private readonly IPeriodeService _periodeService;
        public PeriodeController(IPeriodeService periodeService)
        {
            _periodeService = periodeService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return _periodeService.GetPeriodeId(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
            _periodeService.InsertPeriode(value);
            _periodeService.SavePeriode();
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
