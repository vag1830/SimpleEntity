using System;

namespace Application.Boundaries.UseCases.Register
{
    public class RegistrationInput
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public RegistrationInput(string username, string password, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception();
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception();
            }

            UserName = username;
            Password = password;
            Email = email;
        }
    }
}