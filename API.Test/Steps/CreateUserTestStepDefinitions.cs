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
    public class CreateUserTestStepDefinitions
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUserReq createUserReq;
        private RestResponse response;

        public CreateUserTestStepDefinitions(CreateUserReq createUserReq)
        {
            this.createUserReq = createUserReq;
        }

        [Given(@"I input name ""([^""]*)""")]
        public void GivenIInputName(string name)
        {
            createUserReq.name = name;

        }

        [Given(@"I input role ""([^""]*)""")]
        public void GivenIInputRole(string role)
        {
            createUserReq.job = role;

        }

        [When(@"I send create user request")]
        public async System.Threading.Tasks.Task WhenISendCreateUserRequest()
        {
            var api = new Demo();
            response = await api.CreateNewUser(BASE_URL, createUserReq);

        }

        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var content = HandleContent.GetContent<CreateUserRes>(response);
            Assert.AreEqual(createUserReq.name, content.name);
            Assert.AreEqual(createUserReq.job, content.job);
        }



    }
}
