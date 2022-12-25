using RestSharp;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Test2222.Models;
using Test2222.Models.Request;
using NUnit.Framework;
using System.Net;

namespace Test2222.Steps
{
    [Binding]
    class Steps_GettingUserNotFoundResponse
    {
        private RestResponse response;
        private const string BASE_URL = "https://reqres.in/";
        private readonly GetSingleUserNotFoundRequest getsingleusernotfoundrequest;
        private readonly GetSingleUserNotFoundResponse getsingleusernotfoundresponse;
        public HttpStatusCode statusCode;
        public Steps_GettingUserNotFoundResponse(GetSingleUserNotFoundRequest getsingleusernotfoundrequest,GetSingleUserNotFoundResponse getsingleusernotfoundresponse)
        {
            this.getsingleusernotfoundrequest = getsingleusernotfoundrequest;
            this.getsingleusernotfoundresponse = getsingleusernotfoundresponse;
        }

        [Given(@"I Send Request For Getting User Which is Not Present")]
        public async Task GivenISendRequestForGettingUserWhichIsNotPresentAsync()
        {
            var api = new Demo();
            response = await api.GetSingleUsersNotFound(BASE_URL);
        }

        [Then(@"I Validate User Not Found Response")]
        public void ThenIValidateUserNotFoundResponse()
        {
            var content = HandleContent.GetContent<GetSingleUserResponse>(response);

            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(404, code);


        }


    }
}
