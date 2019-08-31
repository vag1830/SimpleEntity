using System.ComponentModel.DataAnnotations;

namespace WebApi.UseCases.Authenticate
{
    public class CreateTokenRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}