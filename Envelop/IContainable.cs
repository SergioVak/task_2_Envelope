namespace Envelope
{
    public interface IContainable
    {
        double Height { get;}
        double Width { get; }

        bool CanContains(IContainable container);
    }
}
