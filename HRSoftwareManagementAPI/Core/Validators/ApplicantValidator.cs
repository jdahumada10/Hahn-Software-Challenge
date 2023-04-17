using Core.UseCases.Entities;
using Core.UseCases.Exceptions;

namespace Core.Validators;

public class ApplicantValidator
{
    private ApplicantValidator()
    {
    }
    
    private static readonly string[] EnabledStatus = {"InProgress", "Rejected", "Accepted"};

    public static void VerifyApplicantInfo(string? status)
    {
        if (!EnabledStatus.Contains(status))
        {
            throw new ApplicantStateException($"Invalid State: {status} is not part of the valid states ({EnabledStatus})");
        }
    }
    
    public static void VerifyApplicantCompany(Applicant applicant)
    {
        if (applicant.Company == null)
        {
            throw new InconsistentObjectException("Applicant needs a company");
        }
    }
}