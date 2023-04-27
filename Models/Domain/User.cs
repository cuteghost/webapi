using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Domain;

public class User
{
    [Key]
    [Column(TypeName ="bigint")]
    public long Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(15)]
    [MinLength(3)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    [MinLength(3)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [Column(TypeName ="date")]
    public DateTime BirthDate { get; set; }
    [Required]
    [Column(TypeName ="nvarchar")]
    [MaxLength(13)]
    [MinLength(13)]
    public string JMBG { get; set; } = string.Empty;
    [Column(TypeName ="smallint")]
    public Gender Gender { get; set; }
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(30)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [Column(TypeName = "nvarchar")]
    [MaxLength(16)]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
}
public enum Gender
{
    Male = 0,
    Female = 1
}
