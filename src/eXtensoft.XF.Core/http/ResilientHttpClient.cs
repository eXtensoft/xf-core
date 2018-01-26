//using eXtensoft.XF.Core.Abstractions;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace eXtensoft.XF.Core.Http
//{
//    public class ResilientHttpClient : IHttpClient
//    {
//        HttpClient IHttpClient.Client { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//        // okay, the resilienthttpclient needs to know the Policy[] intended for the given ApiDataService<T>
//        // there is NOTHING SPECIAL about the HttpClient
//        // online, it is recommended that there be only 1 HttpClient (Per url?, per RootURL?, perhaps per <T> url?)
//        // the 'ResilientHttpClient' is ONLY responsible for Resiliency
//        // in all other aspects, it must be accessible as simple HttpClient
//        // the actual publicly called http methods MUST be identical, so that the Standard and Resilient HttpClient wrapper
//        // classes both look the exact same from the calling code's perspective

//        // so, first create the interface code, hook up the caller, and then implement the Standard, Resilient wrappers

//        // bigotted api taxonomy provides single url for DGPP methods.  ApiDataService<T> implementation MUST
//        //   be able to override url paths at will, or accept default for the <T>.
//        //   each HTTP.Method (DGPP) must be able to override HttpRequest Header, Content, Url (including QueryString)
//        //   each HTTP.Method, upon HttpResponseMessage, MUST be able to override default IsOkay=>SetStatus
//        //   the ApiDataService<T> must include an IHttpClientFactory constructor parameter
//        // the IHttpClientFactory must have a 'CreateHttpClient<T>() method, and an override (Func<PolicyWrap> policyWrap) so
//        //   that the ApiDataService<T> MAY override configurable

//        // IHttpClientFactory at the top level has several settings:
//        //   useResilientHttpClient (true,false,explicit)
//        //     true: use ApiDataService<T> settings, <T> configuration, global configuration, fallback configuration
//        //     false: use StandardHttpClient
//        //     explicit: use <T> configuration, StandardHttpClient




//        //public ResilientHttpClient(Func<string, IEnumerable<Policy>> policyCreator, ILogger<ResilientHttpClient> logger, IHttpContextAccessor httpContextAccessor)
//        //{
//        //}
//        Task<HttpResponseMessage> IHttpClient.DeleteAsync(string url)
//        {
//            throw new NotImplementedException();
//        }

//        Task<HttpResponseMessage> IHttpClient.GetAsync(string url, HttpCompletionOption completionOption)
//        {
//            throw new NotImplementedException();
//        }

//        Task<HttpResponseMessage> IHttpClient.PostAsync(string url, HttpContent httpContent)
//        {
//            throw new NotImplementedException();
//        }

//        Task<HttpResponseMessage> IHttpClient.PutAsync(string url, HttpContent httpContent)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
