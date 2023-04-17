using HahnSoftwareDomain.Base;
using HahnSoftwareDomain.Entities.Users;

namespace HahnSoftwareDomain.Entities.Companies;

public class Company : BaseEntity
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public ICollection<User> Users { get; set; }
}