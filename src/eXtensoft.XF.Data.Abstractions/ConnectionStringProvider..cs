using System;
using System.Collections.Generic;
using System.Text;
using eXtensoft.XF.Core.Abstractions;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration;

namespace eXtensoft.XF.Data.Abstractions
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private IConfiguration _Configuration;
        private Func<string> _GetConnectionString = null;
        public ConnectionStringProvider(Func<string> getConnectionString)
        {
            _GetConnectionString = getConnectionString;
        }

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public ConnectionStringProvider()
        {

        }

        string IConnectionStringProvider.Get()
        {
            throw new NotImplementedException();
        }

        string IConnectionStringProvider.Get<T>()
        {
            throw new NotImplementedException();
        }

        string IConnectionStringProvider.Get<T>(IParameters parameters)
        {
            throw new NotImplementedException();
        }

        string IConnectionStringProvider.Get<T>(T model)
        {
            if (_GetConnectionString == null)
            {
                string typeName = typeof(T).Name.ToLower();
                string key = String.Format("{0}.storage", typeName);
                //return _Configuration.GetConnectionString(key);
                return "";
            }
            else
            {
                return _GetConnectionString();
            }
        }

        string IConnectionStringProvider.Get<T>(T model, IParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
