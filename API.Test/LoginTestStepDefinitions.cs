using API.Framework;
using API.Framework.Models;
using API.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace API.Test
{
    [Binding]
    public class LoginTestStepDefinitions : Reusable
    {
        private readonly RegisterUserReq registerUserReq;

        public LoginTestStepDefinitions(RegisterUserReq registerUserReq)
        {
            this.registerUserReq = registerUserReq;
        }

        [When(@"I post a request to login endpoint")]
        public async Task WhenIPostARequestToLoginEndpoint()
        {
            var api = new Demo();
            response = await api.LoginUser(baseUrl, registerUserReq);
        }

        [Then(@"I should receive ""(.*)"" for login API status description")]
        public void ThenIShouldReceiveStatusCodeAndResponse(string statusDescription)
        {
            Assert.AreEqual(statusDescription, response.StatusDescription);
        }

        [Then(@"I should receive token")]
        public void ThenIShouldReceiveToken()
        {
            var content = HandleContent.GetContent<LoginSuccessRes>(response);
            Assert.IsNotNull(content.Token, "Token is not received");
        }


        [Then(@"I should receive ""(.*)"" Error message for login")]
        public void ThenIShouldReceiveErrorMessage(string errorMessage)
        {
            VerifyErrorMessage(errorMessage);
        }

    }
}
