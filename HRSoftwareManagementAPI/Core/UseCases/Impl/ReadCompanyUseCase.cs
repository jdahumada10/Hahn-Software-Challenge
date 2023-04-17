using Core.Providers;
using Core.UseCases.Entities;

namespace Core.UseCases.Impl;

public class ReadCompanyUseCase : IReadCompanyUseCase
{
    private readonly ICompanyProvider _companyProvider;

    public ReadCompanyUseCase(ICompanyProvider companyProvider)
    {
        _companyProvider = companyProvider;
    }

    public Company GetCompanyById(int companyId)
    {
        return _companyProvider.GetCompanyById(companyId);
    }

    public List<Company> GetCompanies()
    {
        return _companyProvider.GetCompanies();
    }
}