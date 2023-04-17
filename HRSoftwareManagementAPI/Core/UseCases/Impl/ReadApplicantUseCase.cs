using Core.Providers;
using Core.UseCases.Entities;

namespace Core.UseCases.Impl;

public class ReadApplicantUseCase : IReadApplicantUseCase
{
    
    private readonly IApplicantProvider _applicantProvider;

    public ReadApplicantUseCase(IApplicantProvider applicantProvider)
    {
        _applicantProvider = applicantProvider;
    }

    public List<Applicant> GetApplicantsByCompanyId(int companyId)
    {
        return _applicantProvider.GetApplicantsByCompanyId(companyId);
    }

    public Applicant? GetApplicantById(int? applicantId)
    {
        return _applicantProvider.GetApplicantById(applicantId);
    }
}