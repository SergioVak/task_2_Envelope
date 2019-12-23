namespace Envelope
{
    public interface IEnvelopeComparable : IEnvelope
    {
        bool IsContains(IEnvelope second);
    }
}
