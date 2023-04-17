using EntryPoint.DTOs;

namespace EntryPoint.Presenter;

public interface ICompanyPresenter
{
    CompanyDto GetCompanyById(int companyId);
    List<CompanyDto> GetCompanies();
    CompanyDto CreateCompany(CompanyDto company);
    CompanyDto UpdateCompany(CompanyDto company);
    void DeleteCompanyWithId(int companyId);
}