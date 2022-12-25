
using RestSharp;
using Test2222.Models.Request;
using System.Threading.Tasks;

namespace Test2222
{
    public class Demo
    {
        private Helper helper;

        public Demo()
        {
            helper = new Helper();
        }
        public async Task<RestResponse> GetUsers(string baseUrl)
        {
            //helper.AddCertificate("", "");
            var client = helper.SetUrl(baseUrl, "api/users?page=2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> GetDelayedResponce(string baseUrl)
        {
            //helper.AddCertificate("", "");
            var client = helper.SetUrl(baseUrl, "api/users?delay=3");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> GetUsersListResource(string baseUrl)
        {
            //helper.AddCertificate("", "");
            var client = helper.SetUrl(baseUrl, "api/unknown");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> GetSingleUsers(string baseUrl)
        {
            //helper.AddCertificate("", "");
            var client = helper.SetUrl(baseUrl, "api/users/2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> GetSingleUsersResources(string baseUrl)
        {
            //helper.AddCertificate("", "");
            var client = helper.SetUrl(baseUrl, "api/unknown/2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> GetSingleUsersResourcesNotFound(string baseUrl)
        {
            //helper.AddCertificate("", "");
            var client = helper.SetUrl(baseUrl, "api/unknown/23");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> GetSingleUsersNotFound(string baseUrl)
        {
            //helper.AddCertificate("", "");
            var client = helper.SetUrl(baseUrl, "api/users/23");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> CreateNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest<CreateUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> UpdateUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users/2");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePutRequest<UpdateUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> UpdateUserPatch(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users/2");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePatchRequest<UpdateUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> DeleteUserRequest(string baseUrl)
        {
            var client = helper.SetUrl(baseUrl, "api/users/2");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreateDeleteRequest();
            var response = await helper.GetResponseAsync(client, request);
          
            return response;
        }
        public async Task<RestResponse> LoginUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/login");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest<LoginRequest>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> RegisterNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/register");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest<RegisterNewUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
    }
}
