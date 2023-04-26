using Dental_App.Models.Domain;

namespace Dental_App.Models.DTO.UserDTO
{
    public class UserPatch
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string JMBG { get; set; } = string.Empty;
        public Gender Gender { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
