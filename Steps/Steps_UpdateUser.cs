using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Test2222.Models;
using Test2222.Models.Request;
using NUnit.Framework;
namespace Test2222.Steps
{
    [Binding]
    public class Steps_UpdateUser
    {
        private const string BASE_URL = "https://reqres.in/";
        private RestResponse response;
        public readonly UpdateUserReq updateuserreq;
        public readonly UpdateUserRes updateuserres;
        public Steps_UpdateUser(UpdateUserReq updateuserreq,UpdateUserRes updateuserres)
        {
            this.updateuserreq = updateuserreq;
            this.updateuserres = updateuserres;

        }
        [Given(@"I Input Name For Update ""(.*)""")]
        public void GivenIInputNameForUpdate(string name)
        {
            updateuserreq.name = name;
        }

        [Given(@"I Input Job For Update ""(.*)""")]
        public void GivenIInputJobForUpdate(string job)
        {
            updateuserreq.job = job;
        }

        [When(@"I Send Request For Update")]
        public async System.Threading.Tasks.Task WhenISendUpdateUserRequestAsync()
        {
            var api = new Demo();
            response = await api.UpdateUser(BASE_URL, updateuserreq);
        }

        [Then(@"I Validate the Response")]
        public void ThenIValidateTheResponse()
        {
            var content = HandleContent.GetContent<UpdateUserRes>(response);
            Assert.AreEqual(updateuserreq.job, content.job);
            Assert.AreEqual(updateuserreq.name, content.name);

            
        }
        [When(@"I Send Request For Update using Patch")]
        public async System.Threading.Tasks.Task WhenISendUpdateUserRequestUseingPatchAsync()
        {
            var api = new Demo();
            response = await api.UpdateUser(BASE_URL, updateuserreq);
        }



    }

}

