namespace Envelope
{
    public interface IEnvelope
    {
        double Height { get;}
        double Width { get; }

        bool CanContains(IEnvelope container);
    }
}
