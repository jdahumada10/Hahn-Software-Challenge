using DataProvider.Database.Models;

namespace DataProvider.Database.Repositories;

public interface ICompanyRepository
{
    CompanyModel? GetCompanyById(int companyId);
    IEnumerable<CompanyModel?> GetAll();
    CompanyModel Add(CompanyModel company);
    void Update(CompanyModel companyModel);
    void Save();
    void DeleteCompany(CompanyModel company);
}