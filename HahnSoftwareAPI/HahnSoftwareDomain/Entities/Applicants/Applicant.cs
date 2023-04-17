using HahnSoftwareDomain.Base;
using HahnSoftwareDomain.Entities.Payments;

namespace HahnSoftwareDomain.Entities.Applicants;

public partial class Applicants : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Role { get; set; }
    public Assessment? Assessment { get; set; }
}