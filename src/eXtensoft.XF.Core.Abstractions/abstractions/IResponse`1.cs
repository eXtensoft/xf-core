using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Core.Abstractions
{
    public interface IResponse<T> : IEnumerable<T> where T : class, new()
    {

        int Count { get; }

        long Elapsed { get; }

        T Model { get; }

        bool IsOkay { get; }

        IStatus Status { get; }

        //void SetStatus(Exception ex, int status);

        //void SetStatus(bool isOkay, int status);

        //void SetStatus(bool isOkay, int status, int affectedCount);

    }
}
