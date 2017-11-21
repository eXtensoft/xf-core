using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Data.Abstractions
{
    public interface IResponseFactory
    {
        DataResponse<T> Create<T>() where T : class, new();
    }
}
