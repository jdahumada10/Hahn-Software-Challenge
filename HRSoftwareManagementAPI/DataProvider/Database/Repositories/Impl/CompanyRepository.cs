using DataProvider.Database.Contexts;
using DataProvider.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DataProvider.Database.Repositories.Impl;

public sealed class CompanyRepository : ICompanyRepository
{
    private readonly CompanyContext _companyContext;

    public CompanyRepository(CompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public CompanyModel? GetCompanyById(int companyId)
    {
        return _companyContext.CompaniesDbSet.AsNoTracking().FirstOrDefault(c => c.Id.Equals(companyId));
    }

    public IEnumerable<CompanyModel?> GetAll()
    {
        return _companyContext.CompaniesDbSet
            .Include(x => x.Applicants)
            .ToList();
    }

    public CompanyModel Add(CompanyModel company)
    {
        return _companyContext.CompaniesDbSet.Add(company).Entity;
    }

    public void Update(CompanyModel companyModel)
    {
        if (companyModel == null) throw new ArgumentNullException(nameof(companyModel));
        _companyContext.Entry(companyModel).State = EntityState.Modified;
    }

    public void Save()
    {
        _companyContext.SaveChanges();
    }

    public void DeleteCompany(CompanyModel company)
    {
        _companyContext.CompaniesDbSet.Remove(company);
    }
}