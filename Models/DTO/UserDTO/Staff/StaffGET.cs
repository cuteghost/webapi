namespace Models.DTO.UserDTO.Staff;
public class StaffGet : UserGet
{
    public string Certification {get;set;} = string.Empty;
    public string Languages{get;set;} = string.Empty;
    public long StaffId { get; set; }
}
