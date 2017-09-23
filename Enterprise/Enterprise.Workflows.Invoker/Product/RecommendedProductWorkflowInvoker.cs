using Enterprise.Workflows.Invoker.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise.API.Models.Responses;
using System.Activities;
using Enterprise.Workflows.Product;
using Enterprise.Framework.BusinessLogics.Periode.Abstract;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Workflows.Helpers.Converters.Abstract;

namespace Enterprise.Workflows.Invoker.Product
{
    public class RecommendedProductWorkflowInvoker : IRecommendedProductWorkflowInvoker
    {
        private readonly IPeriodeBusinessLogic _periodeBusinessLogic;
        private readonly IRecommendedProductBusinessLogic _recommendedProductBusinessLogic;
        private readonly IRecommendedProductConverter _recommendedProductConverter;
        public RecommendedProductWorkflowInvoker(IPeriodeBusinessLogic periodeBusinessLogic, IRecommendedProductBusinessLogic recommendedProductBusinessLogic,IRecommendedProductConverter recommendedProductConverter)
        {
            _recommendedProductBusinessLogic = recommendedProductBusinessLogic;
            _periodeBusinessLogic = periodeBusinessLogic;
        }
        public RecommendedProductWorkflowResponse InvokeWorkflow(string dateString)
        {
            Activity activity = new RecommendedProductWorkflow()
            {
                DateString = dateString,
                PeriodeBusinessLogic = new InArgument<IPeriodeBusinessLogic>((x) => _periodeBusinessLogic),
                RecommendedBusinessLogic = new InArgument<IRecommendedProductBusinessLogic>((x) => _recommendedProductBusinessLogic)
            };
            WorkflowInvoker workflowInvoker = new WorkflowInvoker(activity);
            IDictionary<string, object> dictionary = workflowInvoker.Invoke();
            return _recommendedProductConverter.ConvertToResponse(dictionary);
        }
    }
}
