using System;
using System.Web.Script.Serialization;
using ProtectClient.Core.Protect;
using RestSharp;

namespace ProtectLib.Protect
{
    public class AuthProtect: BaseProtect
    {
        private RestClient _restClient;
        private string _accessToken;

        public AuthProtect()
        {
            _accessToken = "";
            _restClient = new RestClient("http://localhost:3000");
            
        }

        public override void init()
        {
            throw new System.NotImplementedException();
        }

        public override bool validate()
        {
            throw new System.NotImplementedException();
        }

        public bool login(string login, string password)
        {
            var request = new RestRequest("login");
            var body = new LoginRequest
            {
                login = login, password = password
            };
            
            var json = new JavaScriptSerializer().Serialize(body);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            
            var response = _restClient.Post<LoginResponse>(request);
            if (response.Data.ok)
            {
                _accessToken = response.Data.token;
            }
            return response.Data.ok;
        }

        private class LoginRequest
        {
            public string login { get; set; }
            public string password { get; set; }
        }

        private class LoginResponse
        {
            public bool ok { get; set; }
            public string token { get; set; }
            public string error { get; set; }
        }
        
    }
}