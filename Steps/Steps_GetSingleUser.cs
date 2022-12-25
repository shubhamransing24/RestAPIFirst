using RestSharp;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Test2222.Models;
using Test2222.Models.Request;
using NUnit.Framework;


namespace Test2222.Steps
{
    [Binding]
     class Steps_GetSingleUser
    {
        private const string BASE_URL = "https://reqres.in/";
        private RestResponse response;
        private readonly GetSingleUserRequest getsingleuserrequest;
        private readonly GetSingleUserResponse getsingleuserresponse;
        public Steps_GetSingleUser(GetSingleUserRequest getsingleuserrequest,GetSingleUserResponse getsingleuserresponse)
        {
            this.getsingleuserrequest = getsingleuserrequest;
            this.getsingleuserresponse = getsingleuserresponse;
        }
        
        [Given(@"I Send Request For Getting The Single User")]
        public async Task GivenISendRequestForGettingTheSingleUserAsync()
        {
            var api = new Demo();
            response = await api.GetSingleUsers(BASE_URL);
        }

        [Then(@"I Validate Data For Getting Single User")]
        public void ThenIValidateDataForGettingSingleUser()
        {
            var content = HandleContent.GetContent<GetSingleUserResponse>(response);
            GetSingleUserRequest.Data d1 = new GetSingleUserRequest.Data();
            d1.id = 2;
            d1.email = "janet.weaver@reqres.in";
            d1.first_name = "Janet";
            d1.last_name = "Weaver";
            GetSingleUserRequest.Support s1 = new GetSingleUserRequest.Support();
            s1.url = "https://reqres.in/#support-heading";
            s1.text = "To keep ReqRes free, contributions towards server costs are appreciated!";
            //getsingleuserrequest.data.id = 2;
            //getsingleuserrequest.data.email = "janet.weaver@reqres.in";
            //getsingleuserrequest.data.first_name = "Janet";
            //getsingleuserrequest.data.last_name = "Weaver";
            //getsingleuserrequest.support.url = "https://reqres.in/#support-heading";
            //getsingleuserrequest.support.text = "To keep ReqRes free, contributions towards server costs are appreciated!";
            Assert.AreEqual(d1.id,content.data.id);
            Assert.AreEqual(d1.first_name, content.data.first_name);
            Assert.AreEqual(d1.last_name, content.data.last_name);
            Assert.AreEqual(d1.email, content.data.email);
            Assert.AreEqual(s1.url, content.support.url);
            Assert.AreEqual(s1.text, content.support.text);
            






        }

    }
}
