using Newtonsoft.Json;
using ParrotFrankEntities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParrotFrankHelpers
{
    public class APIConsume
    {
        public async Task<HttpResponseMessage> APICall(HttpMethod method, string url, object parameters, string token = null,
                    int timeOut = 30, string contentTypeHeader = "application/json")
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(timeOut) })
                {
                    var myContent = JsonConvert.SerializeObject(parameters);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentTypeHeader));
                    if(token != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    }
                    var builder = new UriBuilder(new Uri(url));
                    HttpRequestMessage request = new HttpRequestMessage(method, builder.Uri);
                    request.Content = new StringContent(myContent, Encoding.UTF8, "application/json");
                    
                    return await client.SendAsync(request);
                };
            }     
            catch(ApiException ex)
            {                
                
            }
            return null;
        }
    }
}
