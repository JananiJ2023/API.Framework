using API.Framework;
using API.Framework.Models;
using API.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace API.Test
{
    [Binding]
    public class UpdateUserTestStepDefinitions : Reusable
    {
        private readonly CreateUserReq createUserReq;

        public UpdateUserTestStepDefinitions(CreateUserReq createUserReq)
        {
            this.createUserReq = createUserReq;
        }

        [When(@"I send update user request")]
        public async Task WhenISendUpdateUserRequest()
        {
            var api = new Demo();
            response = await api.UpdateUser(baseUrl, createUserReq, updateUserEndpoint);
        }

        [Then(@"validate user is updated")]
        public void ThenValidateUserIsUpdated()
        {
            var content = HandleContent.GetContent<UpdateUserRes>(response);
            Assert.AreEqual("Morpheus", content.Name);
            Assert.AreEqual("Student", content.Job);
        }
    }
}
