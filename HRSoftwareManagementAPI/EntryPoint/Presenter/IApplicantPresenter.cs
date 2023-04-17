using EntryPoint.DTOs;

namespace EntryPoint.Presenter;

public interface IApplicantPresenter
{
    List<ApplicantDto> GetApplicantsByCompanyId(int companyId);
    ApplicantDto CreateApplicant(ApplicantDto applicant);
    ApplicantDto UpdateApplicant(ApplicantDto applicant);
    void DeleteApplicantWithId(int applicantId);
}