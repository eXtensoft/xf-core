﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Core.Abstractions
{
    public interface ITypeMap
    {
        Type ModelType { get; }

        Type DataProviderType { get; }
    }
}
