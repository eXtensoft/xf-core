using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Data.Abstractions
{
    public class DataProviderResolverFactory : IDataProviderResolverFactory
    {
        IDataProviderResolver IDataProviderResolverFactory.GetResolver()
        {
            return null;
        }
    }
}
