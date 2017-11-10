using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.Demo.Data
{
    public static class DataExtensions
    {
        public static string Concat(this IEnumerable<string> list, char delimiter)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var item in list)
            {
                if (!String.IsNullOrWhiteSpace(item))
                {
                    if (i++ > 0)
                    {
                        sb.Append(delimiter);
                    }
                    sb.Append(item.Trim());
                }  
            }
            return sb.ToString();
        }
    }
}
