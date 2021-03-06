﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Core.Abstractions
{
    public interface IPage
    {
        int Count { get; }
        int Size { get; }
        int Index { get; }
        int Total { get; set; }
        string Marker { get; set; }
        string Sort { get; set; }
    }
}
