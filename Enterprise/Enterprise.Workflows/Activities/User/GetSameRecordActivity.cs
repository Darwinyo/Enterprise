﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.BusinessLogics.User;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.BusinessLogics.User.Abstract;

namespace Enterprise.Workflows.Activities.User
{

    public sealed class GetSameRecordActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<UserLoginBusinessLogic> UserLoginBusinessLogic { get; set; }
        public InArgument<Tbl_User_Login> UserLogin { get; set; }
        public OutArgument<string[]> ListSameRecord { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            UserLoginBusinessLogic userLoginBusinessLogic = UserLoginBusinessLogic.Get(context);
            ListSameRecord.Set(context, userLoginBusinessLogic.GetSameRecord(UserLogin.Get(context)));
        }
    }
}
