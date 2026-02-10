namespace QuantoEra.IPCA.Exceptions;

public class IpcaProviderException : Exception
{
    public IpcaProviderException(string message, Exception? rootCause = null): base(message, rootCause) {}
}