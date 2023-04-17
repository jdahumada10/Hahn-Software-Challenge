using System.Runtime.Serialization;

namespace Core.UseCases.Exceptions;

[Serializable]
public class ApplicantStateException : Exception
{
    public ApplicantStateException()
    {
    }

    public ApplicantStateException(string message) : base(message)
    {
    }

    public ApplicantStateException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ApplicantStateException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}