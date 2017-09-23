using Enterprise.Workflows.Invoker.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise.API.Models.Responses;
using System.Activities;
using Enterprise.Workflows.Product;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Workflows.Helpers.Converters.Abstract;

namespace Enterprise.Workflows.Invoker.Product
{
    public class InsertProductWorkflowInvoker : IInsertProductWorkflowInvoker
    {
        private readonly IProductBusinessLogic _productBusinessLogic;
        private readonly IInsertProductConverter _insertProductConverter;
        public InsertProductWorkflowInvoker(IProductBusinessLogic productBusinessLogic, IInsertProductConverter insertProductConverter)
        {
            _productBusinessLogic = productBusinessLogic;
            _insertProductConverter = insertProductConverter;
        }
        public InsertProductWorkflowResponse InvokeWorkflow(object productObject)
        {
            Activity activity = new InsertProductWorkflow()
            {
                ProductBusinessLogic = new InArgument<IProductBusinessLogic>((x) => _productBusinessLogic),
                ProductObject = new InArgument<object>((x) => productObject)
            };
            WorkflowInvoker workflowInvoker = new WorkflowInvoker(activity);
            IDictionary<string, object> dictionary = workflowInvoker.Invoke();
            return _insertProductConverter.ConvertToResponse(dictionary);
        }
    }
}
