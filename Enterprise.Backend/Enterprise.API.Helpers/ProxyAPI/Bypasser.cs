using Enterprise.API.Helpers.Consts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.API.Helpers.ProxyAPI
{
    public abstract class Bypasser<T,T1> where T:class
    {
        public async virtual Task<T> PostAction(string url,T1 t1)
        {
            T type;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(WorkflowServiceClient.BaseUrl);
                string content = JsonConvert.SerializeObject(t1);
                var contentData = new StringContent(content, Encoding.UTF8, MediaTypes.Application_Json);
                HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, contentData).Result;
                type= JsonConvert.DeserializeObject<T>(await httpResponseMessage.Content.ReadAsStringAsync());
            }
            return type;
        }
        public virtual T GetAction(string url)
        {
            T type;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(WorkflowServiceClient.BaseUrl);
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(url).Result;
                type = JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            }
            return type;
        }
    }
}
