using FluentValidation;

namespace Envelope
{
    public class EnvelopeValidator : AbstractValidator<Envelope>
    {
        public EnvelopeValidator()
        {
            RuleFor(envelope => envelope.Height).LessThan(envelope => double.MaxValue).GreaterThan(envelope => 0);

            RuleFor(envelope => envelope.Width).LessThan(envelope => double.MaxValue).GreaterThan(envelope => 0);
        }
    }
}
