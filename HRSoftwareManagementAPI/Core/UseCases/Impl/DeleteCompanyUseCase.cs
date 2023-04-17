using Core.Providers;
using Core.UseCases.Exceptions;

namespace Core.UseCases.Impl;

public class DeleteCompanyUseCase : IDeleteCompanyUseCase
{
    private readonly ICompanyProvider _companyProvider;
    private readonly IReadCompanyUseCase _readCompanyUseCase;

    public DeleteCompanyUseCase(ICompanyProvider companyProvider, IReadCompanyUseCase readCompanyUseCase)
    {
        _companyProvider = companyProvider;
        _readCompanyUseCase = readCompanyUseCase;
    }

    public void DeleteCompanyWithId(int companyId)
    {
        var company = _readCompanyUseCase.GetCompanyById(companyId);
        if (company == null)
        {
            throw new CompanyNotFoundException($"Company with ID:{companyId} not found");
        }
        _companyProvider.DeleteCompany(company);
    }
}