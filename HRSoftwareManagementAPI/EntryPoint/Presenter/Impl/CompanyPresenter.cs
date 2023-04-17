using AutoMapper;
using Core.UseCases;
using Core.UseCases.Entities;
using EntryPoint.DTOs;

namespace EntryPoint.Presenter.Impl;

public class CompanyPresenter : ICompanyPresenter
{
    private readonly IReadCompanyUseCase _readCompanyUseCase;
    private readonly ISaveCompanyUseCase _saveCompanyUseCase;
    private readonly IDeleteCompanyUseCase _deleteCompanyUseCase;

    private readonly IMapper _mapper;

    public CompanyPresenter(IMapper mapper, IReadCompanyUseCase readCompanyUseCase,
        ISaveCompanyUseCase saveCompanyUseCase, IDeleteCompanyUseCase deleteCompanyUseCase)
    {
        _mapper = mapper;
        _readCompanyUseCase = readCompanyUseCase;
        _saveCompanyUseCase = saveCompanyUseCase;
        _deleteCompanyUseCase = deleteCompanyUseCase;
    }

    public CompanyDto GetCompanyById(int companyId)
    {
        return _mapper.Map<CompanyDto>(_readCompanyUseCase.GetCompanyById(companyId));
    }

    public List<CompanyDto> GetCompanies()
    {
        return _mapper.Map<List<CompanyDto>>(_readCompanyUseCase.GetCompanies());
    }

    public CompanyDto CreateCompany(CompanyDto company)
    {
        return _mapper.Map<CompanyDto>(_saveCompanyUseCase.CreateCompany(_mapper.Map<Company>(company)));
    }

    public CompanyDto UpdateCompany(CompanyDto company)
    {
        return _mapper.Map<CompanyDto>(_saveCompanyUseCase.UpdateCompany(_mapper.Map<Company>(company)));
    }

    public void DeleteCompanyWithId(int companyId)
    {
        _deleteCompanyUseCase.DeleteCompanyWithId(companyId);
    }
}