using EntryPoint.DTOs;

namespace EntryPoint.Services;

public interface ICompanyService
{
    CompanyDto GetCompanyById(int companyId);
    List<CompanyDto> GetCompanies();
    CompanyDto CreateCompany(CompanyDto company);
    CompanyDto UpdateCompany(CompanyDto company);
    void DeleteCompanyWithId(int companyId);
}