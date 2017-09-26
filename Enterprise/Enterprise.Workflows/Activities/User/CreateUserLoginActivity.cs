using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.BusinessLogics.User;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.BusinessLogics.User.Abstract;

namespace Enterprise.Workflows.Activities.User
{

    public sealed class CreateUserLoginActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<object> UserLoginObject { get; set; }
        public InArgument<IUserLoginBusinessLogic> UserLoginBusinessLogic { get; set; }

        public OutArgument<TblUserLogin> UserLoginModel { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            IUserLoginBusinessLogic userLoginBusinessLogic = UserLoginBusinessLogic.Get(context);
            UserLoginModel.Set(context, userLoginBusinessLogic.CreateUserLogin(UserLoginObject.Get(context)));
        }
    }
}
