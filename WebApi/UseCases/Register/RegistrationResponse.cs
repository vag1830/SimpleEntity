using System;

namespace WebApi.UseCases.Register
{
    internal class RegistrationResponse
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}