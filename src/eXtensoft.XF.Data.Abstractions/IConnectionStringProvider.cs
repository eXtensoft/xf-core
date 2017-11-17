using eXtensoft.XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Data.Abstractions
{
    public interface IConnectionStringProvider
    {
        string Get();
        string Get<T>();

        string Get<T>(IParameters parameters);

        string Get<T>(T model);

        string Get<T>(T model, IParameters parameters);
    }
}
