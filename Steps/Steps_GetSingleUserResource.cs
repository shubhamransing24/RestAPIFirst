
using TechTalk.SpecFlow;
using Test2222.Models;
using Test2222.Models.Request;
using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;

namespace Test2222.Steps
{
    [Binding]
     class Steps_GetSingleUserResource
    {
        private const string BASE_URL = "https://reqres.in/";
        private RestResponse response;
        private readonly GetSingleUserResourcesRequest getsingleuserresourcesrequest;
        private readonly GetSingleUserResponse getsingleuserresponse;

        public Steps_GetSingleUserResource(GetSingleUserResourcesRequest getsingleuserresourcesrequest,GetSingleUserResponse getsingleuserresponse)
        {
            this.getsingleuserresourcesrequest = getsingleuserresourcesrequest;
            this.getsingleuserresponse = getsingleuserresponse;

        }
        [Given(@"I Request For Getting Single User Resource")]
        public async Task GivenIRequestForGettingSingleUserResourceAsync()
        {
            var api = new Demo();
            response = await api.GetSingleUsersResources(BASE_URL);
        }

        [Then(@"I Validate Response for Single User Resource")]
        public void ThenIValidateResponseForSingleUserResource()
        {
            var content = HandleContent.GetContent<GetSingleUserResourceRes>(response);
            getsingleuserresourcesrequest.data = new GetSingleUserResourcesRequest.Data();
            getsingleuserresourcesrequest.support = new GetSingleUserResourcesRequest.Support();
            getsingleuserresourcesrequest.data.id = 2;
            getsingleuserresourcesrequest.data.name = "fuchsia rose";
            getsingleuserresourcesrequest.data.year = 2001;
            getsingleuserresourcesrequest.data.color = "#C74375";
            getsingleuserresourcesrequest.data.pantone_value = "17-2031";
            getsingleuserresourcesrequest.support.url = "https://reqres.in/#support-heading";
            getsingleuserresourcesrequest.support.text = "To keep ReqRes free, contributions towards server costs are appreciated!";
            Assert.AreEqual(getsingleuserresourcesrequest.data.id, content.data.id);
            Assert.AreEqual(getsingleuserresourcesrequest.data.name, content.data.name);
            Assert.AreEqual(getsingleuserresourcesrequest.data.year, content.data.year);
            Assert.AreEqual(getsingleuserresourcesrequest.data.pantone_value, content.data.pantone_value);
            Assert.AreEqual(getsingleuserresourcesrequest.support.url, content.support.url);
            Assert.AreEqual(getsingleuserresourcesrequest.support.text, content.support.text);
        }

    }
}
