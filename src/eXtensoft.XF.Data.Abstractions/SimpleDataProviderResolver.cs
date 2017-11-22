using System;
using System.Collections.Generic;
using System.Text;
using eXtensoft.XF.Core.Abstractions;

namespace eXtensoft.XF.Data.Abstractions
{
    public class SimpleDataProviderResolver : IDataProviderResolver
    {
        IDataService<T> IDataProviderResolver.Resolve<T>()
        {
            return GetDataProvider<T>();
        }

        IDataService<T> IDataProviderResolver.Resolve<T>(IParameters parameters)
        {
            return GetDataProvider<T>();
        }

        IDataService<T> IDataProviderResolver.Resolve<T>(T model)
        {
            return GetDataProvider<T>();
        }

        IDataService<T> IDataProviderResolver.Resolve<T>(T model, IParameters parameters)
        {
            return GetDataProvider<T>();
        }

        private IDataService<T> GetDataProvider<T>() where T : class, new()
        {
            return null;
        }
    }
}
