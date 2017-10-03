using Enterprise.Workflows.Invoker.Abstract;
using Enterprise.Workflows.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Enterprise.Workflows.Client.Controllers.User
{
    public class UserRegistrationController : ApiController
    {
        private readonly IUserRegistrationWorkflowInvoker _userWorkflowInvoker;
        public UserRegistrationController(IUserRegistrationWorkflowInvoker userWorkflowInvoker)
        {
            _userWorkflowInvoker = userWorkflowInvoker;
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
        public UserRegistrationWorkflowResponse Post([FromBody]object value)
        {
            return  _userWorkflowInvoker.InvokeWorkflow(value);
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