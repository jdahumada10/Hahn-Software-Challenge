namespace Core.UseCases.Entities;

public class Applicant
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }
    public string? Email { get; set; }
    public string? ProcessStatus { get; set; }
    public Company? Company { get; set; }
}