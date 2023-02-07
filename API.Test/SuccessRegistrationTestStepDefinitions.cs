using API.Framework;
using API.Framework.Models;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using API.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace API.Test
{
    [Binding]
    public class SuccessRegistrationTestStepDefinitions
    {
        private string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        private readonly RegisterUserReq registerUserReq;
        private readonly RegisterUnsuccessfulRes registerUnsuccessfulRes;
        private RestResponse response;

        public SuccessRegistrationTestStepDefinitions(RegisterUserReq registerUserReq)
        {
            this.registerUserReq = registerUserReq;
        }

        [Given(@"I have a valid email ""(.*)"" and password ""(.*)""")]
        public void GivenIHaveAValidEmailAndPassword(string email, string password)
        {
            registerUserReq.Email = email;
            registerUserReq.Password = password;
        }

        [Given(@"I have a valid email ""(.*)"" only")]
        public void GivenIHaveAValidEmailOnly(string email)
        {
            registerUserReq.Email = email;
        }


        [When(@"I post a request")]
        public async Task WhenIPostARequest()
        {
            var api = new Demo();
            response = await api.RegisterNewUser(baseUrl, registerUserReq);
        }

        //[When(@"I post a request to ""(.*)"" endpoint")]
        //public async void WhenIPostARequestToEndpoint(string endpoint)
        //{
        //    var api = new Demo();
        //    response = await api.RegisterNewUser(baseUrl, registerUserReq, endpoint);
        //}


        [Then(@"I should receive ""(.*)"" status description")]
        public void ThenIShouldReceiveStatusCodeAndResponse(string statusDescription)
        {
            Assert.AreEqual(statusDescription, response.StatusDescription);
        }

        [Then(@"I should receive ""(.*)"" Error message")]
        public void ThenIShouldReceiveErrorMessage(string errorMessage)
        {
            var content = HandleContent.GetContent<RegisterUnsuccessfulRes>(response);
            Assert.AreEqual(errorMessage, content.Error);
        }


    }
}
