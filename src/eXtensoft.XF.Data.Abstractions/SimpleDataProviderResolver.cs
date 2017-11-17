using System;
using System.Collections.Generic;
using System.Text;
using eXtensoft.XF.Core.Abstractions;

namespace eXtensoft.XF.Data.Abstractions
{
    public class SimpleDataProviderResolver : IDataProviderResolver
    {
        IDataProvider<T> IDataProviderResolver.Resolve<T>()
        {
            return GetDataProvider<T>();
        }

        IDataProvider<T> IDataProviderResolver.Resolve<T>(IParameters parameters)
        {
            return GetDataProvider<T>();
        }

        IDataProvider<T> IDataProviderResolver.Resolve<T>(T model)
        {
            return GetDataProvider<T>();
        }

        IDataProvider<T> IDataProviderResolver.Resolve<T>(T model, IParameters parameters)
        {
            return GetDataProvider<T>();
        }

        private IDataProvider<T> GetDataProvider<T>() where T : class, new()
        {
            return null;
        }
    }
}
