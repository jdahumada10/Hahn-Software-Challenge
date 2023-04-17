using System.Runtime.Serialization;

namespace Core.UseCases.Exceptions;

[Serializable]
public class InconsistentObjectException : Exception
{
    public InconsistentObjectException()
    {
    }

    public InconsistentObjectException(string message) : base(message)
    {
    }

    public InconsistentObjectException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected InconsistentObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}