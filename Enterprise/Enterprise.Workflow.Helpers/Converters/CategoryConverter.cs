using Enterprise.Workflows.Helpers.Converters.Abstract;
using Enterprise.Workflows.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Workflows.Helpers.Converters
{
    public class CategoryConverter : ICategoryConverter
    {
        public CategoryWorkflowResponse ConvertToResponse(IDictionary<string, object> dictionary)
        {
            return new CategoryWorkflowResponse
            {
                IsExists = Convert.ToBoolean(dictionary["IsExists"])
            };
        }
    }
}
