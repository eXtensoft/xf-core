using eXtensoft.XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Data.Abstractions
{
    public interface IDataProviderResolver
    {
        IDataProvider<T> Resolve<T>() where T : class, new();

        IDataProvider<T> Resolve<T>(IParameters parameters) where T : class, new();

        IDataProvider<T> Resolve<T>(T model) where T : class, new();

        IDataProvider<T> Resolve<T>(T model, IParameters parameters) where T : class, new();

    }
}
