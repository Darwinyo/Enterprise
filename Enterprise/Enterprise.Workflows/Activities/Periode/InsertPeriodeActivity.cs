using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Enterprise.Framework.DataLayers;
using Enterprise.Framework.BusinessLogics.Periode.Abstract;

namespace Enterprise.Workflows.Activities.Periode
{

    public sealed class InsertPeriodeActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<TblPeriode> Periode { get; set; }
        public InArgument<IPeriodeBusinessLogic> PeriodeBusinessLogic { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            IPeriodeBusinessLogic periodeBusinessLogic = PeriodeBusinessLogic.Get(context);
            periodeBusinessLogic.InsertPeriode(Periode.Get(context));
            periodeBusinessLogic.SavePeriode();
        }
    }
}
