using API.Framework;
using API.Framework.Models;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using API.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace API.Test
{
    [Binding]
    public class SuccessRegistrationTestStepDefinitions : Reusable
    {
        private readonly RegisterUserReq registerUserReq;
        
        public SuccessRegistrationTestStepDefinitions(RegisterUserReq registerUserReq)
        {
            this.registerUserReq = registerUserReq;
        }

        [Given(@"I have a valid email ""(.*)"" and password ""(.*)""")]
        public void GivenIHaveAValidEmailAndPassword(string email, string password)
        {
            email = ConfigurationManager.AppSettings["loginusername"];
            password = ConfigurationManager.AppSettings["loginpassword"];

            registerUserReq.Email = email;
            registerUserReq.Password = password;
        }

        [Given(@"I have a valid email ""(.*)"" only")]
        public void GivenIHaveAValidEmailOnly(string email)
        {
            email = ConfigurationManager.AppSettings["loginusername"];
            registerUserReq.Email = email;
        }


        [When(@"I post a request")]
        public async Task WhenIPostARequest()
        {
            var api = new Demo();
            response = await api.RegisterNewUser(baseUrl, registerUserReq, registerUserEndpoint);
        }

        [Then(@"I should receive ""(.*)"" status description")]
        public void ThenIShouldReceiveStatusCodeAndResponse(string statusDescription)
        {
            Assert.AreEqual(statusDescription, response.StatusDescription);
        }

        [Then(@"I should receive ""(.*)"" Error message")]
        public void ThenIShouldReceiveErrorMessage(string errorMessage)
        {
            VerifyErrorMessage(errorMessage);
        }
        [Given(@"I have a invalid email ""(.*)"" and password ""(.*)""")]
        public void GivenIHaveAInvalidEmailAndPassword(string email, string password)
        {
            registerUserReq.Email = email;
            registerUserReq.Password = password;
        }



    }
}
