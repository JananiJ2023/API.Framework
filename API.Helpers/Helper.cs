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

        private Dictionary<string, string> headers = new Dictionary<string, string>
        {
            {"Accept", "application/json"}
        };
        public RestClient SetUrl(string baseUrl, string endpoint)
        {
            var url = Path.Combine(baseUrl, endpoint);
            client = new RestClient(url);
            return client;
        }

        public  RestRequest CreateGetRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Get
            };

            request.AddHeaders(headers);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreateDeleteRequest()
        {
            request = new RestRequest()
            {
                Method = Method.Delete
            };

            request.AddHeaders(headers);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreatePostRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeaders(headers);
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        public RestRequest CreatePatchRequest<T>(T payload) where T : class
        {
            request = new RestRequest()
            {
                Method = Method.Patch
            };
            request.AddHeaders(headers);
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
