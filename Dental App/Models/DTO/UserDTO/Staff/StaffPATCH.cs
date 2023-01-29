namespace Dental_App.Models.DTO.UserDTO.Staff
{
    public class StaffPatch : UserPatch
    {
        public long StaffId { get; set; }
        public DateTime Joined { get; set; } = DateTime.Today;
        public string Certification { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public string Languages { get; set; } = string.Empty;
    }
}