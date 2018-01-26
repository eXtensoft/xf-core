using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eXtensoft.XF.Core.Abstractions
{
    public class ExecutionContext<T> : IExecutionContext<T> where T : class, new()
    {
        T IExecutionContext<T>.Execute(Func<T> action)
        {
            throw new NotImplementedException();
        }

        //T IExecutionContext<T>.Execute(Func<CancellationToken, T> action)
        //{
        //    throw new NotImplementedException();
        //}

        Task<T> IExecutionContext<T>.ExecuteAsync(Func<Task<T>> action)
        {
            throw new NotImplementedException();
        }

        //Task<T> IExecutionContext<T>.ExecuteAsync(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        protected virtual T Execute(Func<T> action)
        {
            return action();
        }

        protected virtual Task<T> Execute(Func<Task<T>> action)
        {
            return action();
        }



    }
}
