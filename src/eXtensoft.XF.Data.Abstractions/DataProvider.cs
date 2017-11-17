using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eXtensoft.XF.Core.Abstractions;

namespace eXtensoft.XF.Data.Abstractions
{
    public class DataProvider : IDataProvider
    {
        private IDataProviderResolver _Resolver;
        public DataProvider(IDataProviderResolverFactory resolverFactory)
        {
            _Resolver = resolverFactory.GetResolver();
        }
        IResponse<T> IDataProvider.Delete<T>(IParameters parameters)
        {
            IDataProvider<T> provider = _Resolver.Resolve<T>(parameters);
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(IDataProvider<T>));
            }
            return provider.Delete(parameters);
        }

        Task<IResponse<T>> IDataProvider.DeleteAsync<T>(IParameters parameters)
        {
            IDataProvider<T> provider = _Resolver.Resolve<T>(parameters);
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(IDataProvider<T>));
            }
            return provider.DeleteAsync(parameters);
        }

        IResponse<T> IDataProvider.Get<T>(IParameters parameters)
        {
            IDataProvider<T> provider = _Resolver.Resolve<T>(parameters);
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(IDataProvider<T>));
            }
            return provider.Get(parameters);
        }

        Task<IResponse<T>> IDataProvider.GetAsync<T>(IParameters parameters)
        {
            IDataProvider<T> provider = _Resolver.Resolve<T>(parameters);
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(IDataProvider<T>));
            }
            return provider.GetAsync(parameters);
        }

        IResponse<T> IDataProvider.Post<T>(T model)
        {
            IDataProvider<T> provider = _Resolver.Resolve<T>(model);
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(IDataProvider<T>));
            }
            return provider.Post(model);
        }

        Task<IResponse<T>> IDataProvider.PostAsync<T>(T model)
        {
            IDataProvider<T> provider = _Resolver.Resolve<T>(model);
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(IDataProvider<T>));
            }
            return provider.PostAsync(model);
        }

        IResponse<T> IDataProvider.Put<T>(T model, IParameters parameters)
        {
            IDataProvider<T> provider = _Resolver.Resolve<T>(model, parameters);
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(IDataProvider<T>));
            }
            return provider.Put(model, parameters);
        }

        Task<IResponse<T>> IDataProvider.PutAsync<T>(T model, IParameters parameters)
        {
            IDataProvider<T> provider = _Resolver.Resolve<T>(parameters);
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(IDataProvider<T>));
            }
            return provider.PutAsync(model, parameters);
        }
    }
}
