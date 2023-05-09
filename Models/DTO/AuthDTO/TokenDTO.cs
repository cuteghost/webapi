using System.ComponentModel.DataAnnotations;

namespace Models.DTO.AuthDTO
{
    public class TokenDTO
    {
        public string Email { get; set;}
        public string Token { get; set;}
    }
}