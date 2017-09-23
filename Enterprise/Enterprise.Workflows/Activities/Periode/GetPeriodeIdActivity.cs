using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.BusinessLogics;
using Enterprise.Framework.BusinessLogics.Periode.Abstract;

namespace Enterprise.Workflows.Activities.Periode
{

    public sealed class GetPeriodeIdActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> DateTime { get; set; }
        public InArgument<IPeriodeBusinessLogic> PeriodeBusinessLogic { get; set; }

        public OutArgument<string> PeriodeId { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            PeriodeId.Set(context, PeriodeBusinessLogic.Get(context).GetPeriodeId(DateTime.Get(context)));
        }
    }
}
