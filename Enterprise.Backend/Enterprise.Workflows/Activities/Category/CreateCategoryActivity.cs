using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Workflows.Activities.Category
{

    public sealed class CreateCategoryActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<object> CategoryObject { get; set; }
        public InArgument<ICategoryBusinessLogic> CategoryBusinessLogic { get; set; }
        public OutArgument<TblCategory> Category { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            Category.Set(context, CategoryBusinessLogic.Get(context).CreateCategory(CategoryObject.Get(context)));
        }
    }
}
