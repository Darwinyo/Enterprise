using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.API.Models.Responses
{
    public class UserRegistrationWorkflowResponse
    {
        public bool Result { get; set; }
        public string[] ListSameRecord { get; set; }
    }
}
