using Core.Providers;
using Core.UseCases.Entities;
using Core.UseCases.Exceptions;
using Core.Validators;

namespace Core.UseCases.Impl;

public class SaveApplicantUseCase : ISaveApplicantUseCase
{
    private readonly IApplicantProvider _applicantProvider;

    private readonly IReadApplicantUseCase _readApplicantUseCase;

    private readonly IReadCompanyUseCase _readCompanyUseCase;

    public SaveApplicantUseCase(IApplicantProvider applicantProvider, IReadApplicantUseCase readApplicantUseCase,
        IReadCompanyUseCase readCompanyUseCase)
    {
        _applicantProvider = applicantProvider;
        _readApplicantUseCase = readApplicantUseCase;
        _readCompanyUseCase = readCompanyUseCase;
    }

    public Applicant CreateApplicant(Applicant applicant)
    {
        ApplicantValidator.VerifyApplicantInfo(applicant.ProcessStatus);
        ApplicantValidator.VerifyApplicantCompany(applicant);
        return _applicantProvider.CreateApplicant(applicant);
    }

    public Applicant UpdateApplicant(Applicant applicant)
    {
        ApplicantValidator.VerifyApplicantInfo(applicant.ProcessStatus);
        var applicantInDb = _readApplicantUseCase.GetApplicantById(applicant.Id);
        if (applicantInDb != null)
        {
            applicant.Company = applicantInDb.Company;
            return _applicantProvider.UpdateApplicant(applicant);
        }

        ApplicantValidator.VerifyApplicantCompany(applicant);
        var applicantCompany = _readCompanyUseCase.GetCompanyById(applicant.Company!.Id);
        applicant.Company = applicantCompany;
        return _applicantProvider.CreateApplicant(applicant);
    }
}