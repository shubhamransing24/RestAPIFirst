
using RestSharp;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Test2222.Models.Request;
using Test2222.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test2222.Steps
{
    [Binding]
    class Steps_ListResource
    {
        private RestResponse response;
        private const string BASE_URL = "https://reqres.in/";
        private readonly ListResourceRequest listresourcerequest;
        private readonly ListResourceRes listresourceres;
        public Steps_ListResource(ListResourceRequest listresourcerequest,ListResourceRes listresourceres)
        {
            this.listresourcerequest = listresourcerequest;
            this.listresourceres = listresourceres;
        }
        [Given(@"I Request For Getting Resource")]
        public async Task GivenIRequestForGettingResourceAsync()
        {
            var api = new Demo();
            response = await api.GetUsersListResource(BASE_URL);
        }

        [Then(@"I Validate Response for List Resource")]
        public void ThenIValidateResponseForListResource()
        {
            var content = HandleContent.GetContent<ListResourceRes>(response);
            listresourcerequest.page = 1;
            listresourcerequest.per_page = 6;
            listresourcerequest.total = 12;
            listresourcerequest.total_pages = 2;
            Models.Request.ListResourceRequest.Datum d1 = new Models.Request.ListResourceRequest.Datum();
            d1.id = 1;
            d1.name = "cerulean";
            d1.year = 2000;
            d1.color = "#98B2D1";
            d1.pantone_value = "15-4020";
            listresourcerequest.data = new List<Models.Request.ListResourceRequest.Datum>();
            listresourcerequest.data.Add(d1);
            Assert.AreEqual(listresourcerequest.data[0].id, content.data[0].id);
            Assert.AreEqual(listresourcerequest.data[0].name, content.data[0].name);
            Assert.AreEqual(listresourcerequest.data[0].year, content.data[0].year);
            Assert.AreEqual(listresourcerequest.data[0].color, content.data[0].color);
            Assert.AreEqual(listresourcerequest.data[0].pantone_value, content.data[0].pantone_value);

        }

    }
}
