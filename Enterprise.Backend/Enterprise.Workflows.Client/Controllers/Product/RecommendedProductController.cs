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
    public class RecommendedProductController : ApiController
    {
        private readonly IRecommendedProductWorkflowInvoker _recommendedProductWorkflowInvoker;
        public RecommendedProductController(IRecommendedProductWorkflowInvoker recommendedProductWorkflowInvoker)
        {
            _recommendedProductWorkflowInvoker = recommendedProductWorkflowInvoker;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public RecommendedProductWorkflowResponse Get(string id)
        {
            return _recommendedProductWorkflowInvoker.InvokeWorkflow(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            
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