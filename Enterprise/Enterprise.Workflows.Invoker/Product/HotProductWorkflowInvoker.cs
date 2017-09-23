using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise.Workflows.Invoker.Product.Abstract;
using Enterprise.API.Models.Responses;
using Enterprise.Workflows.Product;
using System.Activities;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Framework.BusinessLogics.Periode.Abstract;
using Enterprise.Workflows.Helpers.Converters.Abstract;

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
        public HotProductWorkflowResponse GetHotProducts(string dateString)
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
