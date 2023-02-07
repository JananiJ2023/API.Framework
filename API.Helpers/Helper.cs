using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class Helper
    {
        private RestClient client;
        private RestRequest request;

        public RestClient SetUrl(string baseUrl, string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);
            return client;

        }

        public RestRequest CreateGetRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreatePostRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public async Task<RestResponse> GetResponseAsync(RestClient restClient, RestRequest restRequest)
        {
            return await restClient.ExecuteAsync(restRequest);
        }
    }
}
