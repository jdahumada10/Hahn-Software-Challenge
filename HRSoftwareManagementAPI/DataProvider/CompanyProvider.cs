using Core.Providers;
using Core.UseCases.Entities;
using DataProvider.Adapters;

namespace DataProvider;

public class CompanyProvider : ICompanyProvider
{
    private readonly CompanyAdapter _companyAdapter;

    public CompanyProvider(CompanyAdapter companyAdapter)
    {
        _companyAdapter = companyAdapter;
    }

    public Company GetCompanyById(int companyId)
    {
        return _companyAdapter.GetCompanyById(companyId);
    }

    public List<Company> GetCompanies()
    {
        return _companyAdapter.GetCompanies();
    }

    public Company CreateCompany(Company company)
    {
        return _companyAdapter.CreateCompany(company);
    }
    
    public Company UpdateCompany(Company company)
    {
        return _companyAdapter.UpdateCompany(company);
    }

    public void DeleteCompany(Company company)
    {
        _companyAdapter.DeleteCompany(company);
    }
}