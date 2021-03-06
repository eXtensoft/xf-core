﻿using System.Collections.ObjectModel;

namespace eXtensoft.XF.Core
{
    public class ParameterCollection : KeyedCollection<string, Parameter>
    {
        protected override string GetKeyForItem(Parameter item)
        {
            return item.Key;
        }
    }
}
