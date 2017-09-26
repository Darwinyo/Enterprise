using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.DataLayers.DTOs.Product;

namespace Enterprise.Workflows.Activities.HotProduct
{

    public sealed class GetHotProductByPeriodeIdActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> PeriodeId { get; set; }
        public InArgument<IHotProductBusinessLogic> HotProductBusinessLogic { get; set; }

        public OutArgument<IEnumerable<ProductCardDTO>> HotProduct { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            HotProduct.Set(context, HotProductBusinessLogic.Get(context).GetHotProductsByPeriodeId(PeriodeId.Get(context)));
        }
    }
}
