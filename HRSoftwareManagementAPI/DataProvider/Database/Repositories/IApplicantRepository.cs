using DataProvider.Database.Models;

namespace DataProvider.Database.Repositories;

public interface IApplicantRepository
{
    IEnumerable<ApplicantModel?> GetAllByCompanyId(int companyId);
    ApplicantModel? GetApplicantById(int? applicantId);
    ApplicantModel Add(ApplicantModel applicant);
    void Update(ApplicantModel applicant);
    void Save();
    void DeleteApplicant(ApplicantModel applicant);
}