using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.BusinessLogics.User.Abstract;

namespace Enterprise.Workflows.Activities.UserDetails
{

    public sealed class InitInsertUserDetailActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> GuidString { get; set; }
        public InArgument<IUserDetailsBusinessLogic> UserDetailsBusinessLogic { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            IUserDetailsBusinessLogic userDetailsBusinessLogic = UserDetailsBusinessLogic.Get(context);
            userDetailsBusinessLogic.InitInsertUserDetail(GuidString.Get(context));
            userDetailsBusinessLogic.SaveUserDetails();
        }
    }
}
