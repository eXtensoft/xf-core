using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Data.Abstractions
{
    public class DataResponseFactory : IResponseFactory
    {
        DataResponse<T> IResponseFactory.Create<T>()
        {
            return new DataResponse<T>() { };
        }
    }
}
