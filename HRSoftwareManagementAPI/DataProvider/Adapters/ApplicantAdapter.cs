using AutoMapper;
using Core.UseCases.Entities;
using DataProvider.Database.Models;
using DataProvider.Database.Repositories;

namespace DataProvider.Adapters;

public class ApplicantAdapter
{
    private readonly IApplicantRepository _applicantRepository;
    
    private IMapper Mapper { get; }

    public ApplicantAdapter(IApplicantRepository applicantRepository, IMapper mapper)
    {
        _applicantRepository = applicantRepository;
        Mapper = mapper;
    }
    
    public List<Applicant> GetApplicantsByCompanyId(int companyId)
    {
        return Mapper.Map<List<Applicant>>(_applicantRepository.GetAllByCompanyId(companyId));
    }
    
    public Applicant CreateApplicant(Applicant applicant)
    {
        var applicantToSave = Mapper.Map<ApplicantModel>(applicant);
        applicantToSave.Company = null;
        var response = _applicantRepository.Add(applicantToSave);
        _applicantRepository.Save();
        return Mapper.Map<Applicant>(response);
    }
    
    public Applicant UpdateApplicant(Applicant applicant)
    {
        var applicantToUpdate = Mapper.Map<ApplicantModel>(applicant);
        _applicantRepository.Update(applicantToUpdate);
        _applicantRepository.Save();
        return Mapper.Map<Applicant>(applicantToUpdate);
    }

    public Applicant GetApplicantById(int? applicantId)
    {
        return Mapper.Map<Applicant>(_applicantRepository.GetApplicantById(applicantId));
    }

    public void DeleteApplicantWithId(Applicant applicant)
    {
        var mappedApplicant = Mapper.Map<ApplicantModel>(applicant);
        _applicantRepository.DeleteApplicant(mappedApplicant);
        _applicantRepository.Save();
    }
}