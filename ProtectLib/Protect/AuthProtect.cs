using System.Web.Script.Serialization;
using RestSharp;

namespace ProtectLib.Protect
{
    public class AuthProtect: IBaseProtect
    {
        private readonly int _programId;
        private readonly RestClient _restClient;
        private string _accessToken;

        public AuthProtect(int programId)
        {
            _programId = programId; 
            _accessToken = "";
            _restClient = new RestClient("http://localhost:3000");
        }

        public void init()
        {
        }

        public bool validate()
        {
            return validateRequest();
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

        public bool validateRequest()
        {
            if (_accessToken == "")
            {
                return false;
            }
            
            var request = new RestRequest("validate");
            var body = new ValidateRequest {token = _accessToken, program_id = _programId};

            var json = new JavaScriptSerializer().Serialize(body);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            
            var response = _restClient.Post<ValidateResponse>(request);
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

        private class ValidateRequest
        {
            public string token { get; set; }
            public int program_id { get; set; }
        }

        private class ValidateResponse
        {
            public bool ok { get; set; }
        } 
    }
}