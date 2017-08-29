﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HM = Enterprise.DataLayers.EnterpriseDB_HelperModel;
using HB = Enterprise.API.BusinessLogics.Periode;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.API.Controllers.Periode
{
    [Route("api/[controller]")]
    public class PeriodeController : Controller
    {
        private readonly HM.HelperContext _context;
        public PeriodeController(HM.HelperContext context)
        {
            _context = context;
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
            return HB.PeriodeBusinessLogic.GetPeriodeId(id, _context);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
            HB.PeriodeBusinessLogic.CreatePeriode(value, _context);
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