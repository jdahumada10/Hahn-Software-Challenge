using EntryPoint.DTOs;
using EntryPoint.Presenter;

namespace EntryPoint.Services.Impl;

public class ApplicantService : IApplicantService
{
    private readonly IApplicantPresenter _applicantPresenter;
    
    public ApplicantService(IApplicantPresenter applicantPresenter)
    {
        _applicantPresenter = applicantPresenter;
    }
    
    public List<ApplicantDto> GetApplicantsByCompanyId(int companyId)
    {
        return _applicantPresenter.GetApplicantsByCompanyId(companyId);
    }

    public ApplicantDto CreateApplicant(ApplicantDto applicant)
    {
        return _applicantPresenter.CreateApplicant(applicant);
    }

    public ApplicantDto UpdateApplicant(ApplicantDto applicant)
    {
        return _applicantPresenter.UpdateApplicant(applicant);
    }

    public void DeleteApplicantWithId(int applicantId)
    {
        _applicantPresenter.DeleteApplicantWithId(applicantId);
    }
}