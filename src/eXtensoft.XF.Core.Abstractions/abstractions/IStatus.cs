using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Core.Abstractions
{
    public interface IStatus
    {
        int Code { get; }

        string Message { get; }


    }
}
