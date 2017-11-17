using eXtensoft.XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Data.Abstractions
{
    public interface IResponseFactory<T> where T : class, new()
    {
        IResponse<T> Create();
    }
}
