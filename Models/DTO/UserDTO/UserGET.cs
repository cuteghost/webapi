namespace Models.DTO.UserDTO
{
    public class UserGet
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? JMBG { get; set; }
        public DateTime birthDate { get; set; }
        public int Gender { get; set; }

    }
}
