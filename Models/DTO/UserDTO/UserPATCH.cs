using System.ComponentModel.DataAnnotations;
using Models.Domain;

namespace Models.DTO.UserDTO
{
    public class UserPatch
    {
        public long Id { get; set; }
        [MaxLength(15)]
        [MinLength(3)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        [MaxLength(13)]
        [MinLength(13)]
        public string JMBG { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(16)]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
    }
}
