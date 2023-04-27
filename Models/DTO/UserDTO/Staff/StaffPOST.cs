using System.ComponentModel.DataAnnotations;

namespace Models.DTO.UserDTO.Staff
{
    public class StaffPost : UserPost
    {
        public DateTime Joined { get; set; } = DateTime.Today;
        [MaxLength(4000)]
        [MinLength(3)]
        public string Certification { get; set; } = string.Empty;
        [MaxLength(4000)]
        [MinLength(3)]
        public string Education { get; set; } = string.Empty;
        [MaxLength(4000)]
        [MinLength(3)]
        public string Languages { get; set; } = string.Empty;
    }
}
