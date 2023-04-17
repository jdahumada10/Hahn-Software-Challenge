using Core.UseCases.Entities;

namespace Core.UseCases;

public interface ISaveCompanyUseCase
{
    Company CreateCompany(Company company);
    Company UpdateCompany(Company company);
}