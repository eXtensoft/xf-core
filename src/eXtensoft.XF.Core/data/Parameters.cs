using eXtensoft.XF.Core.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Core
{
    public class Parameters : IParameters
    {
        void IParameters.Add(string key, object parameterValue)
        {
            throw new NotImplementedException();
        }

        bool IParameters.ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        IEnumerator<IParameter> IEnumerable<IParameter>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        string IParameters.GetStrategyKey()
        {
            throw new NotImplementedException();
        }

        T IParameters.GetValue<T>(string key)
        {
            throw new NotImplementedException();
        }

        bool IParameters.HasStrategy()
        {
            throw new NotImplementedException();
        }

        bool IParameters.TryGetValue<T>(string key, out T t)
        {
            throw new NotImplementedException();
        }
    }
}
