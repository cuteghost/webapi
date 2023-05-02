using System.ComponentModel.DataAnnotations;

namespace Models.DTO.Auth
{
    public class LoginRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
    }
}
