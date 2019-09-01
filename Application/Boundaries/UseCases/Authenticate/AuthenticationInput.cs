using System;

namespace Application.Boundaries.UseCases.Authenticate
{
    public class AuthenticationInput
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public AuthenticationInput(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new Exception();
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception();
            }

            UserName = userName;
            Password = password;
        }
    }
}