namespace cw3_kontenery.Exceptions;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}