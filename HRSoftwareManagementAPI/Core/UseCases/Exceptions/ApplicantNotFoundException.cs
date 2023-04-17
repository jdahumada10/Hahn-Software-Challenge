using System.Runtime.Serialization;

namespace Core.UseCases.Exceptions;

[Serializable]
public class ApplicantNotFoundException : Exception
{
    public ApplicantNotFoundException()
    {
    }

    public ApplicantNotFoundException(string message) : base(message)
    {
    }

    public ApplicantNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ApplicantNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}