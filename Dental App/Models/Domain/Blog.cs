using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dental_App.Models.Domain;

public class Blog
{
    [Key]
    [Column(TypeName = "bigint")]
    public long Id { get; set; }
    [Required]
    public User Creator { get; set; } = new User();
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Title { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar(max)")]
    [Required]
    public string Content { get; set; } = string.Empty;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; } = DateTime.Now;

}
