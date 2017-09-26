using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.BusinessLogics.User;
using Enterprise.Framework.BusinessLogics.User.Abstract;

namespace Enterprise.Workflows.Activities.User
{

    public sealed class RegisterUserActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<TblUserLogin> UserLogin { get; set; }
        public InArgument<IUserLoginBusinessLogic> UserLoginBusinessLogic { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            IUserLoginBusinessLogic userLoginBusinessLogic = UserLoginBusinessLogic.Get(context);
            TblUserLogin userLogin = UserLogin.Get(context);
            userLogin.UserLoginId = Guid.NewGuid().ToString();
            userLoginBusinessLogic.RegisterUser(userLogin);
            userLoginBusinessLogic.SaveUser();
        }
    }
}
