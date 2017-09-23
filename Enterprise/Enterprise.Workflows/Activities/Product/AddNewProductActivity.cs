using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.BusinessLogics.Product.Abstract;

namespace Enterprise.Workflows.Activities.Product
{

    public sealed class AddNewProductActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<Tbl_Product> Product { get; set; }
        public InArgument<IProductBusinessLogic> ProductBusinessLogic { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            IProductBusinessLogic productBusinessLogic = ProductBusinessLogic.Get(context);
            productBusinessLogic.AddNewProduct(Product.Get(context));
            productBusinessLogic.SaveProduct();
        }
    }
}
