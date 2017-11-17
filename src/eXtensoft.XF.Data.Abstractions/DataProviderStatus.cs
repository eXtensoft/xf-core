﻿using eXtensoft.XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.XF.Data.Abstractions
{
    public class DataProviderStatus : IStatus
    {
        public int HttpCode { get; set; }
        public string ReturnCode { get; set; }
        public string Message { get; set; }
        public string SystemMessage { get; set; }

        int IStatus.HttpCode { get { return HttpCode; } }
        string IStatus.ReturnCode { get { return ReturnCode; } }
        string IStatus.Message { get { return Message; } }
        string IStatus.SystemMessage { get { return SystemMessage; } }

    }
}
