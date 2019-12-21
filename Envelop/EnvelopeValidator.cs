using FluentValidation;

namespace Envelope
{
    public class EnvelopeValidator : AbstractValidator<Envelope>
    {
        public EnvelopeValidator()
        {
            RuleFor(envelope => envelope.Height).LessThan(double.MaxValue).GreaterThan(0);

            RuleFor(envelope => envelope.Width).LessThan(double.MaxValue).GreaterThan(0);
        }
    }
}
