using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise.API.Models.Responses
{
    public class UserLoginResponse
    {
        public string UserKey { get; set; }
        public string UserLogin { get; set; }
        public bool IsLogged { get; set; }
    }
}
