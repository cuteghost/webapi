namespace Dental_App.Models.DTO.UserDTO.Staff
{
    public class StaffPost : UserPost
    {
        public DateTime Joined { get; set; } = DateTime.Today;
        public string Certification { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public string Languages { get; set; } = string.Empty;
    }
}
