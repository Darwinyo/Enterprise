using Enterprise.Workflows.Models.Responses;
using Enterprise.Workflows.Invoker.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Enterprise.Workflows.Client.Controllers.Product
{
    public class InsertProductController : ApiController
    {
        private readonly IInsertProductWorkflowInvoker _insertProductWorkflowInvoker;
        public InsertProductController(IInsertProductWorkflowInvoker insertProductWorkflowInvoker)
        {
            _insertProductWorkflowInvoker = insertProductWorkflowInvoker;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public InsertProductWorkflowResponse Post([FromBody]object value)
        {
            return _insertProductWorkflowInvoker.InvokeWorkflow(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}