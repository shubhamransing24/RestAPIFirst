
using TechTalk.SpecFlow;
using Test2222.Models.Request;
using Test2222.Models;
using RestSharp;
using NUnit.Framework;

namespace Test2222.Steps
{
    [Binding]
    public class Steps_LoginSuccessfull
    {

        private const string BASE_URL = "https://reqres.in/";
        private RestResponse response;
        public readonly LoginRequest loginrequest;
        public readonly LoginRes loginres;


        public Steps_LoginSuccessfull(LoginRequest loginrequest,LoginRes loginres)
        {
            this.loginrequest = loginrequest;
            this.loginres = loginres;
        }
        
        [Given(@"I input Email for Login ""(.*)""")]
        public void GivenIInputEmail(string Email)
        {
           loginrequest.email = Email;
        }

        [Given(@"I input Password for Login ""(.*)""")]
        public void GivenIInputPassword(string password)
        {
            loginrequest.password = password;
        }
        [When(@"I Send Login User Request")]
        public async System.Threading.Tasks.Task WhenISendLoginRequestAsync()
        {
            var api = new Demo();
            response = await api.LoginUser(BASE_URL, loginrequest);
        }

        [Then(@"I Validate Login Successfull")]
        public void ThenIValidateLoginSuccessfull()
        {
            var content = HandleContent.GetContent<LoginRes>(response);
            loginres.token = "QpwL5tke4Pnpja7X4";
            Assert.AreEqual(loginres.token, content.token);
            
        }

    }
}
