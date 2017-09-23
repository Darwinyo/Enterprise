﻿using System.Threading.Tasks;
using System.Activities;
using System.Collections.Generic;
using Enterprise.Framework.BusinessLogics.User;
using Enterprise.API.Models.Responses;
using Enterprise.Framework.BusinessLogics.User.Abstract;
using Enterprise.Workflows.User;
using Enterprise.Workflows.Helpers.Converters.Abstract;
using Enterprise.Workflows.Invoker.Abstract;
using System;

namespace Enterprise.Workflows.Invoker.User
{
    public class UserRegistrationWorkflowInvoker : IUserRegistrationWorkflowInvoker
    {
        private readonly IUserLoginBusinessLogic _userLoginBusinessLogic;
        private readonly IUserRegistrationConverter _userRegistrationConverter;
        public UserRegistrationWorkflowInvoker(UserLoginBusinessLogic userLoginBusinessLogic,IUserRegistrationConverter userRegistrationConverter)
        {
            _userLoginBusinessLogic = userLoginBusinessLogic;
            _userRegistrationConverter = userRegistrationConverter;
        }
        
        public UserRegistrationWorkflowResponse InvokeWorkflow(object userLogin)
        {
            Activity activity = new UserRegistrationWorkflow()
            {
                UserLoginBusinessLogic = new InArgument<IUserLoginBusinessLogic>((x) => _userLoginBusinessLogic),
                UserLoginObject = new InArgument<object>((x) => userLogin)
            };
            WorkflowInvoker workflowInvoker = new WorkflowInvoker(activity);
            IDictionary<string, object> result = workflowInvoker.Invoke();
            return _userRegistrationConverter.ConvertToResponse(result);
        }
    }
}