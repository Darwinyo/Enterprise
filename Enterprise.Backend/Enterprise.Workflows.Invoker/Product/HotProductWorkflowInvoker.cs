using System;
using System.Collections.Generic;
using Enterprise.Workflows.Product;
using System.Activities;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.BusinessLogics.Periode.Abstract;
using Enterprise.Workflows.Helpers.Converters.Abstract;
using Enterprise.Workflows.Invoker.Abstract;
using Enterprise.Workflows.Models.Responses;

namespace Enterprise.Workflows.Invoker.Product
{
    public class HotProductWorkflowInvoker: IHotProductWorkflowInvoker
    {
        private readonly IHotProductBusinessLogic _hotProductBusinessLogic;
        private readonly IPeriodeBusinessLogic _periodeBusinessLogic;
        private readonly IHotProductConverter _hotProductConverter;
        public HotProductWorkflowInvoker(IHotProductBusinessLogic hotProductBusinessLogic, IPeriodeBusinessLogic periodeBusinessLogic,IHotProductConverter hotProductConverter)
        {
            _hotProductBusinessLogic = hotProductBusinessLogic;
            _periodeBusinessLogic = periodeBusinessLogic;
            _hotProductConverter = hotProductConverter;
        }
        public HotProductWorkflowResponse InvokeWorkflow(string dateString)
        {
            Activity activity = new HotProductWorkflow()
            {
                DateString = dateString,
                HotProductBusinessLogic = new InArgument<IHotProductBusinessLogic>((x) => _hotProductBusinessLogic),
                PeriodeBusinessLogic = new InArgument<IPeriodeBusinessLogic>((x) => _periodeBusinessLogic)
            };
            WorkflowInvoker workflowInvoker = new WorkflowInvoker(activity);
            IDictionary<string,object> dictionary= workflowInvoker.Invoke();
            return _hotProductConverter.ConvertToResponse(dictionary);
        }
    }
}
