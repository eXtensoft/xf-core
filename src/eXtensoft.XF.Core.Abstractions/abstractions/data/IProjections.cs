using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Core.Abstractions
{
    public interface IProjections
    {
        IEnumerable<Type> Schema { get; }

        IEnumerable<IProjection> Items { get; set; }
    }
}
