using AutoMapper;
using Core.UseCases.Entities;
using DataProvider.Database.Models;
using DataProvider.Database.Repositories;

namespace DataProvider.Adapters;

public class CompanyAdapter
{
    private readonly ICompanyRepository _companyRepository;
    private IMapper Mapper { get; }

    public CompanyAdapter(IMapper mapper, ICompanyRepository companyRepository)
    {
        Mapper = mapper;
        _companyRepository = companyRepository;
    }

    public Company GetCompanyById(int companyId)
    {
        return Mapper.Map<Company>(_companyRepository.GetCompanyById(companyId));
    }

    public List<Company> GetCompanies()
    {
        return Mapper.Map<List<Company>>(_companyRepository.GetAll());
    }

    public Company CreateCompany(Company company)
    {
        var companyToSave = Mapper.Map<CompanyModel>(company);
        var response = _companyRepository.Add(companyToSave);
        _companyRepository.Save();
        return Mapper.Map<Company>(response);
    }
    
    public Company UpdateCompany(Company company)
    {
        var companyToUpdate = Mapper.Map<CompanyModel>(company);
        _companyRepository.Update(companyToUpdate);
        _companyRepository.Save();
        return Mapper.Map<Company>(companyToUpdate);
    }

    public void DeleteCompany(Company company)
    {
        var companyModel = Mapper.Map<CompanyModel>(company);
        _companyRepository.DeleteCompany(companyModel);
        _companyRepository.Save();
    }
}