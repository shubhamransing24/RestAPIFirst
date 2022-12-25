
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Test2222.Models.Request;
using RestSharp;
using System.Threading.Tasks;
using NUnit.Framework;
using Test2222.Models;

namespace Test2222.Steps
{
    [Binding]
    class Steps_GetListOfUsers
    {
        private RestResponse response;
        private const string BASE_URL = "https://reqres.in/";



        private readonly GetListOfUsersRequest getlistofusersrequest;
        private readonly GetListOfUsersRes getlistofusersresponse;
        public Steps_GetListOfUsers(GetListOfUsersRequest getlistofusersrequest)
        {
            this.getlistofusersrequest = getlistofusersrequest;
           

        }

        [Given(@"I send Get request for Getting List")]
        public async Task GivenISendGetRequestForGettingListAsync()
        {
            var api = new Demo();
            response = await api.GetUsers(BASE_URL);


        }

        [When(@"I Validate data for Get Request")]
        public void WhenIValidateDataForGetRequest()
        {
            var content = HandleContent.GetContent<GetListOfUsersRes>(response);
            getlistofusersrequest.Page = 2;
            Assert.AreEqual(getlistofusersrequest.Page, content.Page);
            getlistofusersrequest.Per_Page = 6;
            Assert.AreEqual(getlistofusersrequest.Per_Page, content.Per_Page);
            getlistofusersrequest.Total = 12;
            Assert.AreEqual(getlistofusersrequest.Total, content.Total);
            getlistofusersrequest.Total_Pages = 2;
            Assert.AreEqual(getlistofusersrequest.Total_Pages, content.Total_Pages);
            Models.Request.Datum d1 = new Models.Request.Datum();
            d1.Id = 7;
            d1.Email = "michael.lawson@reqres.in";
            d1.First_Name = "Michael";
            d1.Last_Name = "Lawson";
            getlistofusersrequest.Data = new List<Models.Request.Datum>();
            getlistofusersrequest.Data.Add(d1);
            
            Assert.AreEqual(getlistofusersrequest.Data[0].Id, content.Data[0].Id);
            Assert.AreEqual(getlistofusersrequest.Data[0].Email, content.Data[0].Email);
            Assert.AreEqual(getlistofusersrequest.Data[0].First_Name, content.Data[0].First_Name);
            Assert.AreEqual(getlistofusersrequest.Data[0].Last_Name, content.Data[0].Last_Name);
         
            



        }
    }

}