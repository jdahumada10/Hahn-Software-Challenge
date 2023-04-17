using Core.UseCases.Entities;

namespace Core.Providers;

public interface ICompanyProvider
{
    Company GetCompanyById(int companyId);
    List<Company> GetCompanies();
    Company CreateCompany(Company company);
    Company UpdateCompany(Company company);
    void DeleteCompany(Company company);
}