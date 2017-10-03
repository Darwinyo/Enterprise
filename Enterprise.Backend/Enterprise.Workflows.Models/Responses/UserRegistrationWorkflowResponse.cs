using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.Workflows.Models.Responses
{
    public class UserRegistrationWorkflowResponse
    {
        public bool Result { get; set; }
        public IEnumerable<string> ListSameRecord { get; set; }
    }
}
