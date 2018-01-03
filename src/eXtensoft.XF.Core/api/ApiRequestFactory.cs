
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eXtensoft.XF.Core
{
    public static class ApiRequestFactory
    {

        
        public static ApiRequest Create(string rootUrl, string url,string httpVerb, string protocol = "http")
        {
            ApiRequest request = new ApiRequest() { RootUrl = rootUrl,Url = url, HttpVerb = httpVerb, Protocol = protocol };

            return request;
        }



    }
}
