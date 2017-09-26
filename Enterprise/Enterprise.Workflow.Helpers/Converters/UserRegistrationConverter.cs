using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise.Workflows.Helpers.Converters.Abstract;
using Enterprise.Workflows.Models.Responses;

namespace Enterprise.Workflows.Helpers.Converters
{
    public class UserRegistrationConverter:IUserRegistrationConverter
    {
        public UserRegistrationWorkflowResponse ConvertToResponse(IDictionary<string, object> dictionary)
        {
            return new UserRegistrationWorkflowResponse()
            {
                Result = Convert.ToBoolean(dictionary["Result"]),
                ListSameRecord = (string[])dictionary["ListSameRecord"]
            };
        }
    }
}
