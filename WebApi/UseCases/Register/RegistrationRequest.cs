using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Register
{
    public class RegistrationRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}