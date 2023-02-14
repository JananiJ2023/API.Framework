using API.Framework;
using API.Framework.Models;
using API.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace API.Test
{
    [Binding]
    public class GetSingleUserTestStepDefinitions : Reusable
    {
        [Given(@"that I have sent the GET request to get single user")]
        public async Task GivenThatIHaveSentTheGETRequestToGetSingleUser()
        {
            var api = new Demo();
            response = await api.GetSingleUser(baseUrl, getSingleUserEndpoint);
        }

        [Then(@"the response should have (.*), (.*), (.*) and (.*)")]
        public void ThenTheResponseShouldDetails(int id, string email, string first_name, string last_name)
        {
            var content = HandleContent.GetContent<GetSingleUserRes>(response);
            Assert.IsTrue(content.Data.id.Equals(id));
            Assert.IsTrue(content.Data.email.Equals(email));
            Assert.IsTrue(content.Data.first_name.Equals(first_name));
            Assert.IsTrue(content.Data.last_name.Equals(last_name));

        }
    }
}
