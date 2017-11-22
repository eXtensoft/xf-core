﻿using eXtensoft.XF.Core.Abstractions;
using eXtensoft.XF.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace eXtensoft.XF.Data.SqlServer
{
    //[InheritedExport(typeof(ITypeMap))]
    public abstract class SqlServerDataProvider<T> : IDataProvider<T> where T : class, new()
    {
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
            throw new NotImplementedException(nameof(Delete));
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


        protected virtual void InitializeDeleteCommand(SqlCommand cmd, IParameters parameters)
        {
            throw new NotImplementedException();
        }

        protected virtual void InitializeGetCommand(SqlCommand cmd, IParameters parameters)
        {
            throw new NotImplementedException();
        }

        protected virtual void InitializePostCommand(SqlCommand cmd, T model)
        {
            throw new NotImplementedException();
        }

        protected virtual void InitializePutCommand(SqlCommand cmd, T model, IParameters p)
        {
            throw new NotImplementedException();
        }








        protected virtual void Borrow(SqlDataReader reader, List<T> list)
        {

        }




    }
}