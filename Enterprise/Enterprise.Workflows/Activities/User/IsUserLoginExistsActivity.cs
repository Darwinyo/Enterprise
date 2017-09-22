using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.BusinessLogics.User;

namespace Enterprise.Workflows.Activities.User
{

    public sealed class IsUserLoginExistsActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string[]> ListSameRecord { get; set; }
        public InArgument<UserLoginBusinessLogic> UserLoginBusinessLogic { get; set; }

        public OutArgument<bool> Result { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            Result.Set(context, UserLoginBusinessLogic.Get(context).IsUserLoginExists(ListSameRecord.Get(context)));
        }
    }
}
