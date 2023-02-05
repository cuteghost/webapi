namespace Dental_App.Models.DTO.BlogDTO;
public class BlogPatch
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public long CreatorId { get; set; } 
}
