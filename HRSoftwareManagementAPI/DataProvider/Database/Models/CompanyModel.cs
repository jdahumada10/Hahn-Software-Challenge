using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataProvider.Database.Models;

[Table("company", Schema = "dbo")]
public class CompanyModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("name")] public string? Name { get; set; }
    [Column("address")] public string? Address { get; set; }
    [Column("email")] public string? Email { get; set; }
    public virtual ICollection<ApplicantModel>? Applicants { get; set; }
}