using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.BusinessLogics.Product.Abstract;

namespace Enterprise.Workflows.Activities.Category
{

    public sealed class IsCategoryExistsActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> CategoryName { get; set; }
        public InArgument<ICategoryBusinessLogic> CategoryBusinessLogic { get; set; }
        public OutArgument<bool> IsExists { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            IsExists.Set(context, CategoryBusinessLogic.Get(context).IsCategoryExists(CategoryName.Get(context)));
        }
    }
}
