using System.ComponentModel.DataAnnotations;

namespace Models.DTO.AuthDTO
{
    public class LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}