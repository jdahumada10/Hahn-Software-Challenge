using EntryPoint.DTOs;

namespace EntryPoint.Services;

public interface IApplicantService
{
    List<ApplicantDto> GetApplicantsByCompanyId(int companyId);
    ApplicantDto CreateApplicant(ApplicantDto applicant);
    ApplicantDto UpdateApplicant(ApplicantDto applicant);
    void DeleteApplicantWithId(int applicantId);
}