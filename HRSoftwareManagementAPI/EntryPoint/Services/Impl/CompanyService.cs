using EntryPoint.DTOs;
using EntryPoint.Presenter;

namespace EntryPoint.Services.Impl;

public class CompanyService : ICompanyService
{
    private readonly ICompanyPresenter _companyPresenter;

    public CompanyService(ICompanyPresenter companyPresenter)
    {
        _companyPresenter = companyPresenter;
    }

    public CompanyDto GetCompanyById(int companyId)
    {
        return _companyPresenter.GetCompanyById(companyId);
    }

    public List<CompanyDto> GetCompanies()
    {
        return _companyPresenter.GetCompanies();
    }

    public CompanyDto CreateCompany(CompanyDto company)
    {
        return _companyPresenter.CreateCompany(company);
    }

    public CompanyDto UpdateCompany(CompanyDto company)
    {
        return _companyPresenter.UpdateCompany(company);
    }

    public void DeleteCompanyWithId(int companyId)
    {
        _companyPresenter.DeleteCompanyWithId(companyId);
    }
}