using Core.UseCases.Entities;

namespace Core.UseCases;

public interface IReadApplicantUseCase
{
    List<Applicant> GetApplicantsByCompanyId(int companyId);
    Applicant? GetApplicantById(int? applicantId);
}