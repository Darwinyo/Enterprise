using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Activities;
using Enterprise.Workflows.User;
using System.Collections.Generic;
using Enterprise.Workflows.Invoker.User.Abstraction;
using Enterprise.Framework.BusinessLogics.User;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.BusinessLogics.User.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Workflows.Invoker.User
{
    public class UserWorkflowInvoker : IUserWorkflowInvoker
    {
        private readonly UserLoginBusinessLogic _userLoginBusinessLogic;
        public UserWorkflowInvoker(UserLoginBusinessLogic userLoginBusinessLogic)
        {
            _userLoginBusinessLogic = userLoginBusinessLogic;
        }
        public void UserLoginRegistration(Tbl_User_Login userLogin)
        {
            Activity activity = new UserRegistrationWorkflow()
            {
                BusinessLogic = new InArgument<UserLoginBusinessLogic>((x) => _userLoginBusinessLogic),
                UserLoginModel = new InArgument<Tbl_User_Login>((x) => userLogin)
            };
            WorkflowInvoker workflowInvoker = new WorkflowInvoker(activity);
            IDictionary<string, object> result = workflowInvoker.Invoke();
            
        }
    }
}
