using eXtensoft.XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Core
{
    public class Parameter : IParameter
    {
        string IParameter.Key { get; set; }

        object IParameter.Value { get; set; }


    }
}
