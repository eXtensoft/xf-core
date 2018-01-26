using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eXtensoft.XF.Core.Abstractions
{
    public interface IExecutionContext<T> where T : class, new()
    {
        T Execute(Func<T> action);
        //T Execute(Func<CancellationToken, T> action);
        Task<T> ExecuteAsync(Func<Task<T>> action);
        //Task<T> ExecuteAsync(Func<CancellationToken, Task<T>> action, CancellationToken cancellationToken);
    }
}
