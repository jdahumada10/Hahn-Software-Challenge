using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataProvider.Database.Models;

[Table("applicant", Schema = "dbo")]
public class ApplicantModel
{
    [Key] public int? Id { get; set; }
    [Column("first_name")] public string? FirstName { get; set; }
    [Column("last_name")] public string? LastName { get; set; }
    [Column("role")] public string? Role { get; set; }
    [Column("email")] public string? Email { get; set; }
    [Column("process_status")] public string? ProcessStatus { get; set; }
    [Column("company_id")] public int CompanyId { get; set; }
    public CompanyModel? Company { get; set; }
}