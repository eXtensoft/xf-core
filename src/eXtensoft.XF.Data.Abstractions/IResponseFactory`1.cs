using eXtensoft.XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Data.Abstractions
{
    public interface IResponseFactory<T> where T : class, new()
    {
        DataResponse<T> Create();
    }
}
