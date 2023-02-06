using API.Framework;
using API.Framework.Models;
using API.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace API.Test
{
    [Binding]
    public class GetUserTestStepDefinitions
    {
        private string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
        private RestResponse response;
        private string userName;

        [Given(@"that I have sent the GET request to get users")]
        public async Task GivenThatIHaveSentTheGETRequestToGetUsers()
        {
            var api = new Demo();
            response = await api.GetUsers(baseUrl);
        }

        [When(@"I receive the response")]
        public void WhenIReceiveTheResponse()
        {
            //response received in previous step.  No action required
        }

        [Then(@"the response should contain ""(.*)""")]
        public void ThenTheResponseShouldContain(string name)
        {
            userName = name;
            
            var content = HandleContent.GetContent<ListOfUsers>(response);
            var userNames = content.Data.Select(d => d.first_name + " " + d.last_name).ToList();
            Assert.IsTrue(userNames.Contains(userName), "Expected user not found");
        }
    }
}
