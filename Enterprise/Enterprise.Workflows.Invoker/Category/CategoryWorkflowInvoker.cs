using Enterprise.Workflows.Invoker.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise.API.Models.Responses;
using Enterprise.Workflows.Category;
using System.Activities;
using Enterprise.Framework.BusinessLogics.Product.Abstract;
using Enterprise.Workflows.Helpers.Converters;
using Enterprise.Workflows.Helpers.Converters.Abstract;

namespace Enterprise.Workflows.Invoker.Category
{
    public class CategoryWorkflowInvoker : ICategoryWorkflowInvoker
    {
        private readonly ICategoryBusinessLogic _categoryBusinessLogic;
        private readonly ICategoryConverter _categoryConverter;
        public CategoryWorkflowInvoker(ICategoryBusinessLogic categoryBusinessLogic, ICategoryConverter categoryConverter)
        {
            _categoryBusinessLogic = categoryBusinessLogic;
            _categoryConverter = categoryConverter;
        }
        public CategoryWorkflowResponse InvokeWorkflow(object categoryObject)
        {
            Activity activity = new CategoryWorkflow()
            {
                CategoryBusinessLogic = new InArgument<ICategoryBusinessLogic>((x) => _categoryBusinessLogic),
                CategoryObject = new InArgument<object>((x) => categoryObject)
            };
            WorkflowInvoker workflowInvoker = new WorkflowInvoker(activity);
            IDictionary<string, object> dictionary = workflowInvoker.Invoke();
            return _categoryConverter.ConvertToResponse(dictionary);
        }
    }
}
