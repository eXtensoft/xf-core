using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Core.Abstractions
{
    public interface IMessageContext
    {
        IEnumerable<IProperty> Properties { get; set; }
    }
}
