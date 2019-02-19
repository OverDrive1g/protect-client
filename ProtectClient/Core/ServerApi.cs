using ProtectClient.Core.DAO;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtectClient.Core
{
    class ServerApi
    {
        const string BaseUrl = "http://localhost:8080/";

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new System.Uri(BaseUrl);
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                ApplicationException twilioException = new ApplicationException(message, response.ErrorException);
                throw twilioException;
            }
            return response.Data;
        }


        public LoginResult Login(string email, string password)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = "/api/authorization"
            };

            Dictionary<string, string> body = new Dictionary<string, string>();
            body.Add("email", email);
            body.Add("password", password);

            request.JsonSerializer = new JsonSerializer();
            request.RequestFormat = DataFormat.Json;

            request.AddBody(body);

            return Execute<LoginResult>(request);
        }
    }
}
