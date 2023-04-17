namespace Core.UseCases.Entities;

public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public ICollection<Applicant> Applicants { get; set; }

    public Company()
    {
        Applicants = new List<Applicant>();
    }
    
    public Company(int id)
    {
        Id = id;
        Applicants = new List<Applicant>();
    }
}