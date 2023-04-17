using Core.Providers;
using Core.UseCases.Entities;
using Core.Validators;

namespace Core.UseCases.Impl;

public class SaveCompanyUseCase : ISaveCompanyUseCase
{
    private readonly ICompanyProvider _companyProvider;

    private readonly IReadCompanyUseCase _readCompanyUseCase;

    public SaveCompanyUseCase(ICompanyProvider companyProvider, IReadCompanyUseCase readCompanyUseCase)
    {
        _companyProvider = companyProvider;
        _readCompanyUseCase = readCompanyUseCase;
    }

    public Company CreateCompany(Company company)
    {
        ValidateApplicantsStatus(company);
        return _companyProvider.CreateCompany(company);
    }
    
    public Company UpdateCompany(Company company)
    {
        ValidateApplicantsStatus(company);
        return _readCompanyUseCase.GetCompanyById(company.Id) != null ? _companyProvider.UpdateCompany(company) : _companyProvider.CreateCompany(company);
    }

    private static void ValidateApplicantsStatus(Company company)
    {
        foreach (var applicant in company.Applicants)
        {
            ApplicantValidator.VerifyApplicantInfo(applicant.ProcessStatus);
        }
    }
}