
using NUnit.Framework;
using TechTalk.SpecFlow;
using Test2222.Models.Request;
using Test2222.Models;
using RestSharp;
using System.Net;

namespace Test2222.Steps
{
    [Binding]
    class Steps_RegisterNewUser
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly RegisterNewUserReq registerNewUser;
        private readonly RegisterNewUserRes registerNewUserRes;
        private readonly RegisterNewUserUnsuccessfullRes registerNewUserUnsuccessfullRes;
        private readonly DeleteUserResponse deleteUserRes;
        public HttpStatusCode statusCode;
        private RestResponse response;
        public Steps_RegisterNewUser(RegisterNewUserReq registerNewUser, RegisterNewUserRes registerNewUserRes, RegisterNewUserUnsuccessfullRes registerNewUserUnsuccessfullRes,DeleteUserResponse deleteUserRes)       
        {
            this.registerNewUser = registerNewUser;
            this.registerNewUserRes = registerNewUserRes;
            this.registerNewUserUnsuccessfullRes = registerNewUserUnsuccessfullRes;
            this.deleteUserRes = deleteUserRes;
        }
        [Given(@"I input Email for register ""(.*)""")]
        public void GivenIInputEmail(string Email)
        {
            registerNewUser.email = Email;
        }

        [Given(@"I input Password for register ""(.*)""")]
        public void GivenIInputPassword(string password)
        {
            registerNewUser.password = password;
        }

        [When(@"I send Create New Account Request")]
        public async System.Threading.Tasks.Task WhenISendCreateAccountRequestAsync()
        {
            var api = new Demo();
            response = await api.RegisterNewUser(BASE_URL, registerNewUser);
        }

        [Then(@"Validate Account is created successfully")]
        public void ThenValidateAccountIsCreated()
        {
            var content = HandleContent.GetContent<RegisterNewUserRes>(response);
            registerNewUserRes.id = 4;
            Assert.AreEqual(registerNewUserRes.id, content.id);
            registerNewUserRes.token ="QpwL5tke4Pnpja7X4";
            Assert.AreEqual(registerNewUserRes.token, content.token);

        }
        [Then(@"Validate Err Message ""(.*)""")]
        public void ThenValidateErrMessage(string errmessage)
        {
            var content = HandleContent.GetContent<RegisterNewUserUnsuccessfullRes>(response);
            registerNewUserUnsuccessfullRes.error = errmessage;
            Assert.AreEqual(registerNewUserUnsuccessfullRes.error, content.error);
        }
        [When(@"I send Delete User Request")]

        public async System.Threading.Tasks.Task WhenISend()
        {
            var api = new Demo();
            response = await api.DeleteUserRequest(BASE_URL);
          
        }

        [Then(@"Validate Delete Responce")]
        public void ThenValidateDeleteResponce()
        {
          
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(204, code);

        }

    }
}
