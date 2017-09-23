using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.DataLayers;

namespace Enterprise.Workflows.Activities.RecommendedProduct
{

    public sealed class GetRecommendedProductByPeriodeIdActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> PeriodeId { get; set; }
        public InArgument<IRecommendedProductBusinessLogic> RecommendedProductBusinessLogic { get; set; }

        public OutArgument<IEnumerable<Tbl_Product>> RecommendedProduct { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            RecommendedProduct.Set(context, RecommendedProductBusinessLogic.Get(context).GetRecommendedProductsByPeriodeId(PeriodeId.Get(context)));
        }
    }
}
