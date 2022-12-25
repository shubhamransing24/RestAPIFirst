using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using Test2222.Models;
using Test2222.Models.Request;
namespace Test2222.Steps
{
    [Binding]
    public class Steps_CreateUser
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUserReq createUserReq;
        private RestResponse response;

        public Steps_CreateUser(CreateUserReq createUserReq)
        {
            this.createUserReq = createUserReq;
        }

        [Given(@"I input name ""(.*)""")]
        public void GivenIInputName(string name)
        {
            createUserReq.name = name;
        }

        [Given(@"I input role ""(.*)""")]
        public void GivenIInputRole(string role)
        {
            createUserReq.job = role;
        }

        [When(@"I send create user request")]
        public async System.Threading.Tasks.Task WhenISendCreateUserRequestAsync()
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
