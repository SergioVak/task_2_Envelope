namespace Envelope
{
    public class Envelope : IEnvelope
    {
        public double Height { get; }
        public double Width { get; }

        public Envelope(double height, double width)
        {
            if (height >= width)
            {
                Height = height;
                Width = width;
            }
            else
            {
                Height = width;
                Width = height;
            }    
        }

        public bool CanContains(IEnvelope secondEnvelope)
        {
            bool result;

            if ((Height > secondEnvelope.Height) && (Width > secondEnvelope.Width))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
