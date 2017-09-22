using Enterprise.Framework.DataLayers;
using Enterprise.Workflows.Invoker.User.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Enterprise.Workflows.Client.Controllers
{
    public class UserRegistrationController : ApiController
    {
        private readonly IUserWorkflowInvoker _userWorkflowInvoker;
        public UserRegistrationController(IUserWorkflowInvoker userWorkflowInvoker)
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
        public void Post([FromBody]string value)
        {
            Tbl_User_Login login = new Tbl_User_Login()
            {
                User_Login = "Darwin"
            };
            _userWorkflowInvoker.UserLoginRegistration(login);
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