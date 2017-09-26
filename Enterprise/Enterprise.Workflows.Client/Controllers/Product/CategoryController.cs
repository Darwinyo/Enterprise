using Enterprise.Workflows.Invoker.Abstract;
using Enterprise.Workflows.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Enterprise.Workflows.Client.Controllers.Product
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryWorkflowInvoker _categoryWorkflowInvoker;
        public CategoryController(ICategoryWorkflowInvoker categoryWorkflowInvoker)
        {
            _categoryWorkflowInvoker = categoryWorkflowInvoker;
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
        public CategoryWorkflowResponse Post([FromBody]object value)
        {
            return _categoryWorkflowInvoker.InvokeWorkflow(value);
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