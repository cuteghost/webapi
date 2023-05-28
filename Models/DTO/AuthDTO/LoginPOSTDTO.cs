using System.ComponentModel.DataAnnotations;

namespace Models.DTO.AuthDTO
{
    public class LoginPOSTDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}

    }
}