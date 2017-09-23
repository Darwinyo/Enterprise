using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Workflows.Invoker.Abstract
{
    public interface IBaseWorkflowInvoker<TResult> where TResult : class
    {
        TResult InvokeWorkflow();
    }
    public interface IBaseWorkflowInvoker<TResult, T1> where TResult : class
    {
        TResult InvokeWorkflow(T1);
    }
    public interface IBaseWorkflowInvoker<TResult, T1, T2> where TResult : class
    {
        TResult InvokeWorkflow(T1 t1,T2 t2);
    }
    public interface IBaseWorkflowInvoker<TResult, T1, T2, T3> where TResult : class
    {
        TResult InvokeWorkflow(T1 t1,T2 t2,T3 t3);
    }
    public interface IBaseWorkflowInvoker<TResult, T1, T2, T3, T4> where TResult : class
    {
        TResult InvokeWorkflow(T1 t1, T2 t2, T3 t3,T4 t4);
    }
    public interface IBaseWorkflowInvoker<TResult, T1, T2, T3, T4, T5> where TResult : class
    {
        TResult InvokeWorkflow(T1 t1, T2 t2, T3 t3, T4 t4,T5 t5);
    }
    public interface IBaseWorkflowInvoker<TResult, T1, T2, T3, T4, T5, T6> where TResult : class
    {
        TResult InvokeWorkflow(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5,T6 t6);
    }
}
