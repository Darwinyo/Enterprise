using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise.Workflow.Helpers.Converters.Abstract;
using Enterprise.API.Models.Responses;
namespace Enterprise.Workflow.Helpers.Converters
{
    public class UserRegistrationConverter : IWorkflowResponseConverters<UserRegistrationWorkflowResponse, IDictionary<string, object>>
    {
        public UserRegistrationWorkflowResponse ConvertToResponse(IDictionary<string, object> dictionary)
        {
            return new UserRegistrationWorkflowResponse();
        }
    }
}
