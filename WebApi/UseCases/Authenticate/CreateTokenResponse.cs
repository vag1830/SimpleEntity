using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Authenticate
{
    public class CreateTokenResponse
    {
        public string Token { get; set; }

        public DateTime Expires { get; set; }
    }
}