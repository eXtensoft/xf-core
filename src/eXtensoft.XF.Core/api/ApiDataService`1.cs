using eXtensoft.XF.Core.Abstractions;
using eXtensoft.XF.Data.Abstractions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace eXtensoft.XF.Core
{
    public abstract class ApiDataService<T> : IDataService<T> where T : class, new()
    {

        public ILogger Logger { get; set; }

        public IResponseFactory ResponseFactory { get; set; }

        public HttpClient HttpClient { get; set; }

        public IExecutionContext<HttpResponseMessage> ExecutionContext { get; set; }

        IResponse<T> IDataService<T>.Delete(IParameters parameters)
        {            
            var apiRequest = GenerateApiRequest<T>(HttpVerb.DELETE).Set(parameters);
            ApiResponse<T> apiResponse = Execute<T>(apiRequest, ParseMany<T>);
            var response = CreateResponse();
            SetResponseDelete(apiResponse, response);
            return response;
        }

        Task<IResponse<T>> IDataService<T>.DeleteAsync(IParameters parameters)
        {
            var apiRequest = GenerateApiRequest<T>(HttpVerb.DELETE).Set(parameters);
            ApiResponse<T> apiResponse = ExecuteAsync<T>(apiRequest, ParseMany<T>).Result;
            var response = CreateResponse();
            SetResponseDelete(apiResponse, response);
            return new Task<IResponse<T>>(()=>response);
        }

        IResponse<T> IDataService<T>.Get(IParameters parameters)
        {           
            var apiRequest = GenerateApiRequest<T>(HttpVerb.GET).Set(parameters);
            ApiResponse<T> apiResponse = Execute<T>(apiRequest, ParseMany<T>);
            var response = CreateResponse();
            SetResponseGet(apiResponse, response);
            return response;
        }

        Task<IResponse<T>> IDataService<T>.GetAsync(IParameters parameters)
        {
            var apiRequest = GenerateApiRequest<T>(HttpVerb.GET).Set(parameters);
            ApiResponse<T> apiResponse = ExecuteAsync<T>(apiRequest, ParseMany<T>).Result;
            IResponse<T> response = CreateResponse();
            SetResponseGet(apiResponse, response);
            return new Task<IResponse<T>>(()=>response);
        }

        IResponse<T> IDataService<T>.Post(T model)
        {
            var apiRequest = GenerateApiRequest<T>(HttpVerb.POST).Set(model);
            ApiResponse<T> apiResponse = Execute<T>(apiRequest,ParseOne<T>);
            var response = CreateResponse();
            SetResponsePost(apiResponse, response);
            return response;
        }

        Task<IResponse<T>> IDataService<T>.PostAsync(T model)
        {
            var apiRequest = GenerateApiRequest<T>(HttpVerb.POST).Set(model);
            ApiResponse<T> apiResponse = ExecuteAsync<T>(apiRequest, ParseMany<T>).Result;
            IResponse<T> response = CreateResponse();
            SetResponsePost(apiResponse, response);
            return new Task<IResponse<T>>(() => response);
        }

        IResponse<T> IDataService<T>.Put(T model, IParameters parameters)
        {
            var apiRequest = GenerateApiRequest<T>(HttpVerb.PUT).Set(model,parameters);
            ApiResponse<T> apiResponse = Execute<T>(apiRequest, ParseOne<T>);
            var response = CreateResponse();
            SetResponsePut(apiResponse,response);
            return response;
        }

        Task<IResponse<T>> IDataService<T>.PutAsync(T model, IParameters parameters)
        {
            var apiRequest = GenerateApiRequest<T>(HttpVerb.PUT).Set(parameters);
            ApiResponse<T> apiResponse = ExecuteAsync<T>(apiRequest, ParseMany<T>).Result;
            IResponse<T> response = CreateResponse();
            SetResponsePut(apiResponse, response);
            return new Task<IResponse<T>>(() => response);
        }


        private ApiRequest<T> GenerateApiRequest<T>(HttpVerb httpVerb = HttpVerb.GET) where T : class, new()
        {
            ApiRequest<T> request = new ApiRequest<T>()
            {
                QueryString = new Dictionary<string, object>(),
                HttpVerb = httpVerb
            };
            InitializeRequest(request);
            return request;
        }

        //protected virtual void SetParameters(ApiRequest<T> request,IParameters parameters)
        //{
        //    request.Set(parameters);
        //}


        protected virtual void InitializeRequest<T>(ApiRequest<T> request) where T : class, new()
        {
            request.Protocol = Protocol.Http;
            request.RootUrl = "http://localhost:51376/api";
            //request.Url = ResolveUrl<T>(request.HttpVerb);
            request.AddHeaders(AddDefaultHeaders);
        }


        protected virtual string ResolveUrl<T>(HttpVerb httpVerb)
        {
            string url = String.Empty;
            T t = Activator.CreateInstance<T>();
            string key = t.GetType().Name;
            //if (ApiConstants.Url.endpointMaps.ContainsKey(key))
            //{
            //    url = ApiConstants.Url.endpointMaps[key];
            //}
            return url;
        }

        protected virtual List<Tuple<string, string>> AddDefaultHeaders()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();

            return list;
        }

        protected virtual IResponse<T> CreateResponse()
        {
            if (ResponseFactory != null)
            {
                return ResponseFactory.Create<T>();
            }
            else
            {
                return new DataResponse<T>();

            }

        }

        protected virtual void SetResponseDelete(ApiResponse<T> apiResponse, IResponse<T> dataResponse)
        {
            SetResponse(apiResponse, dataResponse);
        }

        protected virtual void SetResponseGet(ApiResponse<T> apiResponse, IResponse<T> dataResponse)
        {
            SetResponse(apiResponse, dataResponse);
        }

        protected virtual void SetResponsePost(ApiResponse<T> apiResponse, IResponse<T> dataResponse)
        {
            SetResponse(apiResponse, dataResponse);
        }

        protected virtual void SetResponsePut(ApiResponse<T> apiResponse, IResponse<T> dataResponse)
        {
            SetResponse(apiResponse, dataResponse);
        }


        public static async Task<ApiResponse<T>> ExecuteAsync<T>(ApiRequest<T> request, Func<string, IEnumerable<T>> parseJson) where T : class, new()
        {
            ApiResponse<T> response = new ApiResponse<T>() { Request = request, Items = new List<T>() };
            using (var client = request.HttpClient())
            {

                HttpResponseMessage message = null;
                try
                {
                    switch (request.HttpVerb)
                    {
                        case HttpVerb.DELETE:
                            message = await client.DeleteAsync(request.ComposeUrl());
                            break;
                        case HttpVerb.GET:
                            message = await client.GetAsync(request.ComposeUrl(), HttpCompletionOption.ResponseContentRead);
                            break;
                        case HttpVerb.POST:
                            message = await client.PostAsync(request.ComposeUrl(), request.Content());
                            break;
                        case HttpVerb.PUT:
                            message = await client.PutAsync(request.ComposeUrl(), request.Content());
                            break;
                        default:
                            break;
                    }

                }
                catch (Exception ex)
                {
                    response.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    response.StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
                }
                if (message == null)
                {
                }
                else
                {
                    response.StatusCode = response.StatusCode;
                    if (message.IsSuccessStatusCode)
                    {
                        response.IsOkay = true;
                        var task = message.Content.ReadAsStringAsync();
                        if (task != null)
                        {
                            string body = task.Result;
                            if (!String.IsNullOrWhiteSpace(body))
                            {
                                response.Body = body;
                                try
                                {
                                    response.Items = parseJson(body).ToList();
                                }
                                catch (Exception ex)
                                {
                                    response.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                                }

                            }
                        }

                    }
                    else
                    {

                    }
                }
            }
            return response;
        }

        public ApiResponse<T> Execute<T>(ApiRequest<T> request, Func<string, IEnumerable<T>> parseJson) where T : class, new()
        {
            ApiResponse<T> response = new ApiResponse<T>() { Request = request, Items = new List<T>() };
            HttpResponseMessage message = null;
            using (var client = request.HttpClient())
            {
                try
                {
                    switch (request.HttpVerb)
                    {
                        case HttpVerb.DELETE:
                            message = HttpClient.DeleteAsync(request.ComposeUrl()).Result;
                            break;
                        case HttpVerb.GET:
                            message = client.GetAsync(request.ComposeUrl(), HttpCompletionOption.ResponseContentRead).Result;
                            break;
                        case HttpVerb.POST:
                            message = HttpClient.PostAsync(request.ComposeUrl(), request.Content()).Result;
                            break;
                        case HttpVerb.PUT:
                            message = HttpClient.PutAsync(request.ComposeUrl(), request.Content()).Result;
                            break;
                        default:
                            break;
                    }

                }
                catch (Exception ex)
                {
                    response.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                }
            }
                

            if (message == null)
            {
            }
            else
            {
                response.StatusCode = response.StatusCode;
                if (message.IsSuccessStatusCode)
                {
                    response.IsOkay = true;
                    var task = message.Content.ReadAsStringAsync();
                    if (task != null)
                    {
                        string body = task.Result;
                        if (!String.IsNullOrWhiteSpace(body))
                        {
                            response.Body = body;
                            try
                            {
                                response.Items = parseJson(body).ToList();
                            }
                            catch (Exception ex)
                            {
                                response.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                            }

                        }
                    }

                }
                else
                {

                }
            }
            return response;
        }

        private static IEnumerable<T> ParseMany<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        private static IEnumerable<T> ParseOne<T>(string json)
        {
            List<T> list = new List<T>();
            T t = JsonConvert.DeserializeObject<T>(json);
            list.Add(t);
            return list;
        }

        private static void SetResponse(ApiResponse<T> apiResponse, IResponse<T> dataResponse)
        {
            if (apiResponse.IsOkay)
            {
                dataResponse.SetStatus(true);
                dataResponse.Items = apiResponse.Items;
            }
            else
            {
                dataResponse.SetStatus(false, (int)apiResponse.StatusCode);

            }
        }

    }
}
