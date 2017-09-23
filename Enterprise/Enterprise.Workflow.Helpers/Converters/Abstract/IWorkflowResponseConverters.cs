using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Workflows.Helpers.Converters.Abstract
{
    public interface IWorkflowResponseConverters<T,TDictionary>
    {
        T ConvertToResponse(TDictionary dictionary);
    }
}
