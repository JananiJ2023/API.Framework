using API.Framework.Models;
using API.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Framework
{
    public class Demo
    {
        private Helper helper;

        public Demo()
        {
            helper = new Helper();
        }

        public async Task<RestResponse> GetUsers(string baseUrl)
        {
            var client = helper.SetUrl(baseUrl, "api/users?page=2");
            var request = helper.CreateGetRequest();
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> CreateNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users");
            var request = helper.CreatePostRequest<CreateUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> RegisterNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/register");
            var request = helper.CreatePostRequest<RegisterUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> LoginUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/login");
            var request = helper.CreatePostRequest<RegisterUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> UpdateUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/user/2");
            var request = helper.CreatePatchRequest<CreateUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
    }
}
