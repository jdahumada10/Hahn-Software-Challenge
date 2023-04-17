namespace HahnSoftwareDomain.Entities.Exceptions;

[Serializable]
public class ApplicantException : Exception
{
    public ApplicantException()
    {
    }

    public ApplicantException(string message)
        : base(message)
    {
    }
}