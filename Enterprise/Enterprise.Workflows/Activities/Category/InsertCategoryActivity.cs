using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.BusinessLogics.Product.Abstract;

namespace Enterprise.Workflows.Activities.Category
{

    public sealed class InsertCategoryActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<Tbl_Category> Category { get; set; }
        public InArgument<ICategoryBusinessLogic> CategoryBusinessLogic { get; set; }
        
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            ICategoryBusinessLogic categoryBusinessLogic = CategoryBusinessLogic.Get(context);
            categoryBusinessLogic.InsertCategory(Category.Get(context));
            categoryBusinessLogic.SaveCategory();
        }
    }
}
