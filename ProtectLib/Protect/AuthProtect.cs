using System;
using ProtectClient.Core.Protect;
using RestSharp;

namespace ProtectLib.Protect
{
    public class AuthProtect: BaseProtect
    {
        private RestClient restClient;
        private string accessToken;

        public AuthProtect()
        {
            restClient = new RestClient("http://localhost:3000");
        }

        public override void init()
        {
            throw new System.NotImplementedException();
        }

        public override bool validate()
        {
            throw new System.NotImplementedException();
        }

        public bool login(string name, string password)
        {
            return false;
        }
    }
}