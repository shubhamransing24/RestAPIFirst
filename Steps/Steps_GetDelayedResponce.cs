
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Test2222.Models;
using Test2222.Models.Request;
using NUnit.Framework;

namespace Test2222.Steps
{
    [Binding]
     class Steps_GetDelayedResponce
      {
        private RestResponse response;
        private const string BASE_URL = "https://reqres.in/";
        private readonly GetDelayedResRequest getdelayedrequest;
        private readonly GetDelayedResponce getdelayedresponce;
       public Steps_GetDelayedResponce(GetDelayedResRequest getdelayedrequest,GetDelayedResponce getdelayedresponce)
        {
            this.getdelayedrequest = getdelayedrequest;
            this.getdelayedresponce = getdelayedresponce;
        }
        [Given(@"I Request For Getting Users But Delayed")]
        public async Task GivenIRequestForGettingUsersButDelayedAsync()
        {
            var api = new Demo();
            response = await api.GetDelayedResponce(BASE_URL);

        }

        [Then(@"I Validate The Delayed Responce")]
        public void ThenIValidateTheDelayedResponce()
        {
            var content = HandleContent.GetContent<GetDelayedResponce>(response);
            getdelayedrequest.page = 1;
            getdelayedrequest.per_page = 6;
            getdelayedrequest.total = 12;
            getdelayedrequest.total_pages = 2;
            Models.Request.GetDelayedResRequest.Datum d1= new Models.Request.GetDelayedResRequest.Datum();
            d1.id = 1;
            d1.email = "george.bluth@reqres.in";
            d1.first_name = "George";
            d1.last_name = "Bluth";
            getdelayedrequest.data = new List<Models.Request.GetDelayedResRequest.Datum>();
            getdelayedrequest.data.Add(d1);
            Assert.AreEqual(getdelayedrequest.data[0].id, content.data[0].id);
            Assert.AreEqual(getdelayedrequest.data[0].email, content.data[0].email);
            Assert.AreEqual(getdelayedrequest.data[0].first_name, content.data[0].first_name);
            Assert.AreEqual(getdelayedrequest.data[0].last_name, content.data[0].last_name);

        }

    }

}
