using System;

namespace Envelope
{
    public class Envelope : IEnvelope, IEnvelopeComparable
    {
        public double Height { get; }
        public double Width { get; }

        public Envelope(double height, double width)
        {
            if(height <= 0 && width <= 0)
            {
                throw new ArgumentException();
            }

            Height = height;
            Width = width;
        }

        public bool IsContains(IEnvelope secondEnvelope)
        {
            return (Height > secondEnvelope.Height)&& (Width > secondEnvelope.Width);
        }


    }
}
