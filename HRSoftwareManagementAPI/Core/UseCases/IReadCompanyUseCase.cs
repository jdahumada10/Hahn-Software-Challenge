using Core.UseCases.Entities;

namespace Core.UseCases;

public interface IReadCompanyUseCase
{
    Company? GetCompanyById(int companyId);
    List<Company> GetCompanies();
}