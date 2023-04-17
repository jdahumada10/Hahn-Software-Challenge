using System.ComponentModel.DataAnnotations;

namespace EntryPoint.DTOs;

public class ApplicantDto
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public string? ProcessStatus { get; set; }
    public int CompanyId { get; set; }
}