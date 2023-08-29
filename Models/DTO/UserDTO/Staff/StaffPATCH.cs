using System.ComponentModel.DataAnnotations;

namespace Models.DTO.UserDTO.Staff
{
    public class StaffPatch : UserPatch
    {
        public long StaffId { get; set; }
        public DateTime Joined { get; set; } = DateTime.Today;
    }
}