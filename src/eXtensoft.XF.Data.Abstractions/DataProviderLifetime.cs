using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Data.Abstractions
{
    public enum DataProviderLifetime
    {
        Transient,
        Scoped,
        Singleton,
    }
}
