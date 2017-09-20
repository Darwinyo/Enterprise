using Enterprise.Workflows.Invoker.User;
using Enterprise.Workflows.Invoker.User.Abstraction;
using Enterprise.Workflows.Invoker.UserRegistrationWorkflowService;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Enterprise.WCF.Client.Controllers
{
    public class UserRegistrationController : ApiController
    {
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
        public async Task<StartRegistrationResponse> Post([FromBody]object value)
        {
            JObject jObject = (JObject)value;
            IUserWorkflowInvoker _userWorkflowInvoker = (IUserWorkflowInvoker)jObject["_userWorkflowInvoker"];
            return await _userWorkflowInvoker.UserLoginRegistration(value);
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