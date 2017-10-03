using Enterprise.Workflows.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Workflows.Helpers.Converters.Abstract
{
    public interface IUserRegistrationConverter:IWorkflowResponseConverters<UserRegistrationWorkflowResponse, IDictionary<string, object>> { };
    public interface ICategoryConverter : IWorkflowResponseConverters<CategoryWorkflowResponse, IDictionary<string, object>> { };
    public interface IHotProductConverter : IWorkflowResponseConverters<HotProductWorkflowResponse, IDictionary<string, object>> { };
    public interface IInsertProductConverter : IWorkflowResponseConverters<InsertProductWorkflowResponse, IDictionary<string, object>> { };
    public interface IRecommendedProductConverter : IWorkflowResponseConverters<RecommendedProductWorkflowResponse, IDictionary<string, object>> { };
}
