using Enterprise.API.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Workflows.Invoker.Abstract
{
    public interface ICategoryWorkflowInvoker : IBaseWorkflowInvoker<CategoryWorkflowResponse, object> { }
    public interface IHotProductWorkflowInvoker : IBaseWorkflowInvoker<HotProductWorkflowResponse> { }
    public interface IInsertProductWorkflowInvoker : IBaseWorkflowInvoker<InsertProductWorkflowResponse, object> { }
    public interface IRecommendedProductWorkflowInvoker : IBaseWorkflowInvoker<RecommendedProductWorkflowResponse, string> { }
    public interface IUserRegistrationWorkflowInvoker : IBaseWorkflowInvoker<UserRegistrationWorkflowResponse, object> { }
}
