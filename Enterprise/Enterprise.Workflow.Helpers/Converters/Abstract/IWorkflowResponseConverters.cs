using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Workflow.Helpers.Converters.Abstract
{
    public interface IWorkflowResponseConverters<T,TDictionary> where TDictionary:IDictionary<string,object>
    {
        T ConvertToResponse(TDictionary dictionary);
    }
}
