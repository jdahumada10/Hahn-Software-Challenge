using Core.UseCases.Entities;

namespace Core.UseCases;

public interface ISaveApplicantUseCase
{
    Applicant CreateApplicant(Applicant applicant);
    Applicant UpdateApplicant(Applicant applicant);
}