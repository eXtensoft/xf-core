using eXtensoft.XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Core
{
    public class Parameter : IParameter
    {
        public string Key { get; set; }

        public object Value { get; set; }


    }
}
