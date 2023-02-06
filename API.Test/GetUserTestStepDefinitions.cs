using API.Framework;
using API.Framework.Models;
using API.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace API.Test
{
    [Binding]
    public class GetUserTestStepDefinitions
    {
        private const string BASE_URL = "https://reqres.in/";
        private RestResponse response;

        [Given(@"list user request is sent")]
        public void GivenListUserRequestIsSent()
        {
           
        }

        [Then(@"verify if ""([^""]*)"" ""([^""]*)"" is present in the list")]
        public async System.Threading.Tasks.Task ThenVerifyIfIsPresentInTheList(string first_name, string last_name)
        {
            var api = new Demo();
            response = await api.GetUsers(BASE_URL);
            var content = HandleContent.GetContent<Data>(response);
            Assert.AreEqual(first_name, content.first_name);
            Assert.AreEqual(last_name, content.last_name);

        }
    }
}
