using Core.Providers;
using Core.UseCases.Exceptions;

namespace Core.UseCases.Impl;

public class DeleteApplicantUseCase : IDeleteApplicantUseCase
{
    private readonly IApplicantProvider _applicantProvider;
    private readonly IReadApplicantUseCase _readApplicantUseCase;

    public DeleteApplicantUseCase(IApplicantProvider applicantProvider, IReadApplicantUseCase readApplicantUseCase)
    {
        _applicantProvider = applicantProvider;
        _readApplicantUseCase = readApplicantUseCase;
    }

    public void DeleteApplicantWithId(int applicantId)
    {
        var applicant = _readApplicantUseCase.GetApplicantById(applicantId);
        if (applicant == null)
        {
            throw new ApplicantNotFoundException($"Applicant with ID:{applicantId} not found");
        }
        _applicantProvider.DeleteApplicantWithId(applicant);
    }
}