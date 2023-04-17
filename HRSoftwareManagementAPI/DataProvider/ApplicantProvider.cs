using Core.Providers;
using Core.UseCases.Entities;
using DataProvider.Adapters;

namespace DataProvider;

public class ApplicantProvider : IApplicantProvider
{
    private readonly ApplicantAdapter _applicantAdapter;

    public ApplicantProvider(ApplicantAdapter applicantAdapter)
    {
        _applicantAdapter = applicantAdapter;
    }

    public List<Applicant> GetApplicantsByCompanyId(int companyId)
    {
        return _applicantAdapter.GetApplicantsByCompanyId(companyId);
    }

    public Applicant GetApplicantById(int? applicantId)
    {
        return _applicantAdapter.GetApplicantById(applicantId);
    }

    public Applicant CreateApplicant(Applicant applicant)
    {
        return _applicantAdapter.CreateApplicant(applicant);
    }

    public Applicant UpdateApplicant(Applicant applicant)
    {
        return _applicantAdapter.UpdateApplicant(applicant);
    }

    public void DeleteApplicantWithId(Applicant applicant)
    {
        _applicantAdapter.DeleteApplicantWithId(applicant);
    }
}