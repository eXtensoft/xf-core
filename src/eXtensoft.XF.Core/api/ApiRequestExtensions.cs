﻿using eXtensoft.XF.Core.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;

namespace eXtensoft.XF.Core
{
    public static class ApiRequestExtensions
    {
        public static void AddHeaders<T>(this ApiRequest<T> request, Func<IEnumerable<Tuple<string,string>>> addHeaders) where T : class, new()
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            HashSet<string> hs = new HashSet<string>();
            if (request.Headers != null)
            {
                foreach (Tuple<string,string> header in request.Headers)
                {
                    if (hs.Add(header.Item1))
                    {
                        list.Add(header);
                    }
                }
            }
            foreach (Tuple<string,string> header in addHeaders())
            {
                if (hs.Add(header.Item1))
                {
                    list.Add(header);
                }
            }
            request.Headers = list;
        }

        public static HttpClient HttpClient<T>(this ApiRequest<T> request) where T : class, new()
        {
            HashSet<string> hs = new HashSet<string>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(String.Format("{0}://{1}", request.Protocol.ToString(), request.RootUrl));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            foreach (Tuple<string,string> header in request.Headers)
            {
                if (hs.Add(header.Item1))
                {
                    client.DefaultRequestHeaders.Add(header.Item1, header.Item2);
                }
                
            }
            return client;
        }

        public static string ComposeUrl<T>(this ApiRequest<T> request) where T : class, new()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(request.Url);
            if (request.RouteParameter != null)
            {
                sb.Append( "/" + request.RouteParameter.ToString());
            }
            else if(request.QueryString.Count > 0)
            {
                int i = 0;
                sb.Append("?");
                foreach (var item in request.QueryString)
                {
                    if (i++ > 0)
                    {
                        sb.Append("&");
                    }
                    sb.AppendFormat("{0}={1}", item.Key, item.Value.ToString());
                }
            }
            return sb.ToString();
        }

        public static HttpContent Content<T>(this ApiRequest<T> request) where T : class, new()
        {
            HttpContent content = null;
            if (request.Model != null)
            {
                string json = JsonConvert.SerializeObject(request.Model);
                content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            return content;
        }



        public static void Set<T>(this ApiRequest<T> request, T model,IParameters parameters) where T : class, new()
        {
            if (parameters != null)
            {
                request.Set(parameters);
            }
            if (model != null)
            {
                request.Set(model);
            }
        }
        public static void Set<T>(this ApiRequest<T> request,IParameters parameters) where T : class, new()
        {
            if (parameters != null)
            {
                if (parameters.Count() == 1)
                {

                }
                else
                {
                    int i = 0;
                    foreach (var key in parameters)
                    {
                        //request.QueryString.Add(key, parameters[key]);
                    }
                }

            }
        }

        public static void Set<T>(this ApiRequest<T> request, T model) where T : class, new()
        {
            request.Model = model;
        }

    }
}
