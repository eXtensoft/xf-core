using eXtensoft.XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Data.Abstractions
{
    public interface IDataProviderResolver
    {
        IDataService<T> Resolve<T>() where T : class, new();

        IDataService<T> Resolve<T>(IParameters parameters) where T : class, new();

        IDataService<T> Resolve<T>(T model) where T : class, new();

        IDataService<T> Resolve<T>(T model, IParameters parameters) where T : class, new();

    }
}
