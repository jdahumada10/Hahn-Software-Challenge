using Core.UseCases.Entities;

namespace Core.Providers;

public interface IApplicantProvider
{
    List<Applicant> GetApplicantsByCompanyId(int companyId);
    Applicant GetApplicantById(int? applicantId);
    Applicant CreateApplicant(Applicant applicant);
    Applicant UpdateApplicant(Applicant applicant);
    void DeleteApplicantWithId(Applicant applicant);
}