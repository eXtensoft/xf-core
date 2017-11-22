using eXtensoft.XF.Core.Abstractions;
using eXtensoft.XF.Data.Abstractions;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Data.Common;

namespace eXtensoft.XF.Data
{
    //[InheritedExport(typeof(ITypeMap))]
    public abstract class MySqlDataProvider<T> : IDataService<T> where T : class, new()
    {
        private const string _ErrorMessage = "MySql Data Error";

        public IConnectionStringProvider ConnectionStringProvider { get; set; }

        public ILogger Logger { get; set; }

        public IResponseFactory ResponseFactory { get; set; }

        protected string ErrorMessage { get { return GetGeneralErorMessage(); } }

        protected virtual string GetGeneralErorMessage()
        {
            return _ErrorMessage;
        }

        public MySqlDataProvider(
            IConnectionStringProvider connectionStringProvider,
            IResponseFactory responseFactory,
            ILogger logger)
        {
            ConnectionStringProvider = connectionStringProvider;
            ResponseFactory = responseFactory;
            Logger = logger;
        }

        public MySqlDataProvider()
        {

        }

        IResponse<T> IDataService<T>.Delete(IParameters parameters)
        {
            return Delete(parameters);
        }

        Task<IResponse<T>> IDataService<T>.DeleteAsync(IParameters parameters)
        {
            return DeleteAsync(parameters);
        }

        IResponse<T> IDataService<T>.Get(IParameters parameters)
        {
            return Get(parameters);
        }

        Task<IResponse<T>> IDataService<T>.GetAsync(IParameters parameters)
        {
            return GetAsync(parameters);
        }

        IResponse<T> IDataService<T>.Post(T model)
        {
            return Post(model);
        }

        Task<IResponse<T>> IDataService<T>.PostAsync(T model)
        {
            return PostAsync(model);
        }

        IResponse<T> IDataService<T>.Put(T model, IParameters parameters)
        {
            return Put(model, parameters);
        }

        Task<IResponse<T>> IDataService<T>.PutAsync(T model, IParameters parameters)
        {
            return PutAsync(model, parameters);
        }



        protected virtual IResponse<T> Delete(IParameters parameters)
        {
            var response = CreateResponse();
            try
            {
                using (MySqlConnection cn = GetConnection())
                {
                    cn.Open();
                    using (MySqlCommand cmd = cn.CreateCommand())
                    {
                        InitializeDeleteCommand(cmd, parameters);
                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i == 0)
                            {
                                response.SetStatus(i, false);
                            }
                            else
                            {
                                response.SetStatus(i, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters);
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, parameters);
            }
            return response;
        }

        protected virtual async Task<IResponse<T>> DeleteAsync(IParameters parameters)
        {
            var response = CreateResponse();
            try
            {
                using (MySqlConnection cn = GetConnection())
                {
                    await cn.OpenAsync().ConfigureAwait(false);
                    using (MySqlCommand cmd = cn.CreateCommand())
                    {
                        InitializeGetCommand(cmd, parameters);
                        try
                        {
                            var o = await cmd.ExecuteNonQueryAsync();
                            bool b = o > 0;
                            response.SetStatus(o, b);
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters);
                        }
                    }
                }
                response.TrySetPage<T>(parameters);
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex,  parameters);
            }
            return response;
        }

        protected virtual IResponse<T> Get(IParameters parameters)
        {
            var response = CreateResponse();
            try
            {
                using (MySqlConnection cn = GetConnection())
                {
                    cn.Open();
                    using (MySqlCommand cmd = cn.CreateCommand())
                    {
                        InitializeGetCommand(cmd, parameters);
                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                Borrow(reader, response.Items);
                            }
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters);
                        }
                    }
                }
                response.TrySetPage<T>(parameters);
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, parameters);
            }
            return response;
        }

        protected virtual async Task<IResponse<T>> GetAsync(IParameters parameters)
        {
            var response = CreateResponse();
            try
            {
                using (MySqlConnection cn = GetConnection())
                {
                    await cn.OpenAsync().ConfigureAwait(false);
                    using (MySqlCommand cmd = cn.CreateCommand())
                    {
                        InitializeGetCommand(cmd, parameters);
                        try
                        {
                            DbDataReader reader = await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.Default);
                            Borrow(reader, response.Items);
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters);
                        } 
                    }
                }
                response.TrySetPage<T>(parameters);
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, parameters);
            }
            return response;
        }

        protected virtual IResponse<T> Post(T model)
        {
            var response = CreateResponse();
            try
            {
                using (MySqlConnection cn = GetConnection())
                {
                    cn.Open();
                    using (MySqlCommand cmd = cn.CreateCommand())
                    {
                        InitializePostCommand(cmd, model);
                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                Borrow(reader, response.Items);
                            }
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, model);
            }
            return response;
        }

        protected virtual async Task<IResponse<T>> PostAsync(T model)
        {
            var response = CreateResponse();
            try
            {
                using (MySqlConnection cn = GetConnection())
                {
                    await cn.OpenAsync().ConfigureAwait(false);
                    using (MySqlCommand cmd = cn.CreateCommand())
                    {
                        InitializePostCommand(cmd, model);
                        try
                        {
                            DbDataReader reader = await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.Default);
                            Borrow(reader, response.Items);
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex,model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex,model);
            }
            return response;
        }

        protected virtual IResponse<T> Put(T model, IParameters parameters)
        {
            var response = CreateResponse();
            try
            {
                using (MySqlConnection cn = GetConnection())
                {
                    cn.Open();
                    using (MySqlCommand cmd = cn.CreateCommand())
                    {
                        InitializePutCommand(cmd, model, parameters);
                        try
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                Borrow(reader, response.Items);
                            }
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, parameters);
            }
            return response;
        }

        protected virtual async Task<IResponse<T>> PutAsync(T model, IParameters parameters)
        {
            var response = CreateResponse();
            try
            {
                using (MySqlConnection cn = GetConnection())
                {
                    await cn.OpenAsync().ConfigureAwait(false);
                    using (MySqlCommand cmd = cn.CreateCommand())
                    {
                        InitializePutCommand(cmd, model,parameters);
                        try
                        {
                            DbDataReader reader = await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.Default);
                            Borrow(reader, response.Items);
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters,model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex,parameters,model);
            }
            return response;
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

        protected virtual void Borrow(DbDataReader reader, List<T> list)
        {
            throw new NotImplementedException(nameof(Borrow));
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



        protected virtual DataResponse<T> CreateResponse()
        {
            if (ResponseFactory != null)
            {
                return ResponseFactory.Create<T>();
            }
            else
            {
                return new DataResponse<T>();

            }
            
        }

        private void LogError(Exception ex, IParameters parameters = null)
        {
            if (parameters != null)
            {
                Logger.LogError(ex, ErrorMessage, parameters.ToList());
            }
            else
            {
                Logger.LogError(ex, ErrorMessage, ErrorMessage);
            }


        }
        private void LogError(Exception ex, T model = null)
        {
            if (model != null)
            {
                Logger.LogError(ex, ErrorMessage, model);
            }
            else
            {
                Logger.LogError(ex, ErrorMessage, ErrorMessage);
            }

        }
        private void LogError(Exception ex, IParameters parameters = null, T model = null)
        {
            if(parameters != null)
            {
                Logger.LogError(ex, ErrorMessage, parameters.ToList());
            }
            else if (model != null)
            {
                Logger.LogError(ex, ErrorMessage, model);
            }
            else
            {
                Logger.LogError(ex, ErrorMessage, ErrorMessage);
            }
            
        }

    }
}
