using eXtensoft.XF.Core.Abstractions;
using eXtensoft.XF.Data.Abstractions;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace eXtensoft.XF.Data
{
    //[InheritedExport(typeof(ITypeMap))]
    public abstract class MySqlDataProvider<T> : IDataProvider<T> where T : class, new()
    {

        public IConnectionStringProvider ConnectionStringProvider { get; set; }

        public ILogger Logger { get; set; }

        public IResponseFactory<T> ResponseFactory { get; set; }

        IResponse<T> IDataProvider<T>.Delete(IParameters parameters)
        {
            return Delete(parameters);
        }

        Task<IResponse<T>> IDataProvider<T>.DeleteAsync(IParameters parameters)
        {
            return DeleteAsync(parameters);
        }

        IResponse<T> IDataProvider<T>.Get(IParameters parameters)
        {
            return Get(parameters);
        }

        Task<IResponse<T>> IDataProvider<T>.GetAsync(IParameters parameters)
        {
            return GetAsync(parameters);
        }

        IResponse<T> IDataProvider<T>.Post(T model)
        {
            return Post(model);
        }

        Task<IResponse<T>> IDataProvider<T>.PostAsync(T model)
        {
            return PostAsync(model);
        }

        IResponse<T> IDataProvider<T>.Put(T model, IParameters parameters)
        {
            return Put(model, parameters);
        }

        Task<IResponse<T>> IDataProvider<T>.PutAsync(T model, IParameters parameters)
        {
            return PutAsync(model, parameters);
        }



        protected virtual IResponse<T> Delete(IParameters parameters)
        {
            IResponse<T> response = CreateResponse();
            using (MySqlConnection cn = GetConnection())
            {
                cn.Open();
                using (MySqlCommand cmd = cn.CreateCommand())
                {

                    InitializeDeleteCommand(cmd, parameters);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Borrow(reader,response.)
                    }
                }
            }

            return response;
        }

        protected virtual Task<IResponse<T>> DeleteAsync(IParameters parameters)
        {
            throw new NotImplementedException(nameof(DeleteAsync));
        }

        protected virtual IResponse<T> Get(IParameters parameters)
        {
            throw new NotImplementedException(nameof(Get));
        }

        protected virtual Task<IResponse<T>> GetAsync(IParameters parameters)
        {
            throw new NotImplementedException(nameof(GetAsync));
        }

        protected virtual IResponse<T> Post(T model)
        {
            throw new NotImplementedException(nameof(Post));
        }

        protected virtual Task<IResponse<T>> PostAsync(T model)
        {
            throw new NotImplementedException(nameof(PostAsync));
        }

        protected virtual IResponse<T> Put(T model, IParameters parameters)
        {
            throw new NotImplementedException(nameof(Put));
        }

        protected virtual Task<IResponse<T>> PutAsync(T model, IParameters parameters)
        {
            throw new NotImplementedException(nameof(PutAsync));
        }



        protected virtual void InitializeDeleteCommand(MySqlCommand cmd, IParameters parameters)
        {
            throw new NotImplementedException(nameof(InitializeDeleteCommand));
        }

        protected virtual void InitializeGetCommand(MySqlCommand cmd, IParameters parameters)
        {
            throw new NotImplementedException(nameof(InitializeGetCommand));
        }

        protected virtual void InitializePostCommand(MySqlCommand cmd, T model)
        {
            throw new NotImplementedException(nameof(InitializePostCommand));
        }

        protected virtual void InitializePutCommand(MySqlCommand cmd, T model, IParameters parameters)
        {
            throw new NotImplementedException(nameof(InitializePutCommand));
        }

        protected virtual MySqlConnection GetConnection()
        {
            MySqlConnection connection = null;

            if (ConnectionStringProvider == null)
            {
                throw new NullReferenceException(nameof(ConnectionStringProvider));
            }

            string connectionString = ConnectionStringProvider.Get<T>();
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new NullReferenceException(nameof(connectionString));
            }

            connection = new MySqlConnection(connectionString);
            if (connection == null)
            {
                throw new NullReferenceException(nameof(connection));
            }

            return connection;
        }



        protected virtual IResponse<T> CreateResponse()
        {
            if (ResponseFactory != null)
            {
                return ResponseFactory.Create();
            }
            else
            {
                return new DataResponse<T>();

            }
            
        }



    }
}
