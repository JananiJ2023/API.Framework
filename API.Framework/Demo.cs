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

        public async Task<RestResponse> GetUsers(string baseUrl, string getUserEndpoint)
        {
            var client = helper.SetUrl(baseUrl, getUserEndpoint);
            var request = helper.CreateGetRequest();
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> CreateNewUser(string baseUrl, dynamic payload, string createUserEndpoint)
        {
            var client = helper.SetUrl(baseUrl, createUserEndpoint);
            var request = helper.CreatePostRequest<CreateUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> RegisterNewUser(string baseUrl, dynamic payload, string registerUserEndpoint)
        {
            var client = helper.SetUrl(baseUrl, registerUserEndpoint);
            var request = helper.CreatePostRequest<RegisterUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> LoginUser(string baseUrl, dynamic payload, string loginEndpoint)
        {
            var client = helper.SetUrl(baseUrl, loginEndpoint);
            var request = helper.CreatePostRequest<RegisterUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> UpdateUser(string baseUrl, dynamic payload, string updateUserEndpoint)
        {
            var client = helper.SetUrl(baseUrl, updateUserEndpoint);
            var request = helper.CreatePatchRequest<CreateUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> GetSingleUser(string baseUrl, string getSingleUserEndpoint)
        {
            var client = helper.SetUrl(baseUrl, getSingleUserEndpoint);
            var request = helper.CreateGetRequest();
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
    }
}
