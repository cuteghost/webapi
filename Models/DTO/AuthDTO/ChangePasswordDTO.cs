using System.ComponentModel.DataAnnotations;

namespace Models.DTO.AuthDTO
{
    public class ChangePasswordDTO
    {
        [Required]
        [DataType(DataType.Password)]
        public string oldPassword { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }
    }
}