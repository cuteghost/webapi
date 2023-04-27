using System.ComponentModel.DataAnnotations;

namespace Models.DTO.BlogDTO;
public class BlogPatch
{
    public long Id { get; set; }
    [MaxLength(50)]
    [MinLength(5)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(4000)]
    [MinLength(100)]
    public string Content { get; set; } = string.Empty;
    public long CreatorId { get; set; } 
}
