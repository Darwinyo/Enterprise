using Enterprise.Workflows.Helpers.Converters.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise.API.Models.Responses;

namespace Enterprise.Workflows.Helpers.Converters
{
    public class CategoryConverter : ICategoryConverter
    {
        public CategoryWorkflowResponse ConvertToResponse(IDictionary<string, object> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
