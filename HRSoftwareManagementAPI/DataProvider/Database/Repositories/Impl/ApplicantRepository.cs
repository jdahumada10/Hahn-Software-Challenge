using DataProvider.Database.Contexts;
using DataProvider.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DataProvider.Database.Repositories.Impl;

public class ApplicantRepository : IApplicantRepository
{
    private readonly ApplicantContext _applicantContext;

    public ApplicantRepository(ApplicantContext applicantContext)
    {
        _applicantContext = applicantContext;
    }

    public IEnumerable<ApplicantModel?> GetAllByCompanyId(int companyId)
    {
        return _applicantContext.ApplicantsDbSet.AsNoTracking().Where(x => x.Company!.Id.Equals(companyId)).ToList();
    }

    public ApplicantModel? GetApplicantById(int? applicantId)
    {
        return _applicantContext.ApplicantsDbSet.AsNoTracking().FirstOrDefault(c => c.Id.Equals(applicantId));
    }

    public ApplicantModel Add(ApplicantModel applicant)
    {
        return _applicantContext.ApplicantsDbSet.Add(applicant).Entity;
    }

    public void Update(ApplicantModel applicant)
    {
        if (applicant == null) throw new ArgumentNullException(nameof(applicant));
        _applicantContext.Entry(applicant).State = EntityState.Modified;
    }

    public void Save()
    {
        _applicantContext.SaveChanges();
    }

    public void DeleteApplicant(ApplicantModel applicant)
    {
        _applicantContext.ApplicantsDbSet.Remove(applicant);
    }
}