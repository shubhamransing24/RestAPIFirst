
using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Test2222.Models;
using Test2222.Models.Request;
namespace Test2222.Steps
{
    [Binding]
    class Steps_GetSingleResourceUserNotFound
    {
        private const string BASE_URL = "https://reqres.in/";
        private RestResponse response;
        public HttpStatusCode statusCode;
        private readonly GetSingleResourceUserNotFoundRequest singleuserresourcenotfoundreq;
        private readonly GetSingleResourceUserNotFoundRes singleuserresourcenotfoundres;
        public Steps_GetSingleResourceUserNotFound(GetSingleResourceUserNotFoundRequest singleuserresourcenotfoundreq,GetSingleResourceUserNotFoundRes singleuserresourcenotfoundres)
        {
            this.singleuserresourcenotfoundreq = singleuserresourcenotfoundreq;
            this.singleuserresourcenotfoundres = singleuserresourcenotfoundres;
        }
        [Given(@"I Requet for Single  Resource User")]
        public async Task GivenIRequetForSingleResourceUserAsync()
        {
            var api = new Demo();
            response = await api.GetSingleUsersResourcesNotFound(BASE_URL);

        }

        [Then(@"I Validate the Responce for the Resource user")]
        public void ThenIValidateTheResponceForTheResourceUser()
        {
            var content = HandleContent.GetContent<GetSingleResourceUserNotFoundRes>(response);
            statusCode = response.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(404, code);

        }

    }
}
