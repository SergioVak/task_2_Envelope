using System;
using Serilog;

namespace Envelope
{
    public class EnvelopeApp
    {
        private readonly EnvelopeUI _userInterface;
        private EnvelopeValidator _validator;

        private IEnvelope _firstEnvelope;
        private IEnvelope _secondEnvelope;

        public EnvelopeApp()
        {
            _userInterface = new EnvelopeUI();
            _validator = new EnvelopeValidator();
        }

        public void Start()
        {
            bool isActive = true;

            do
            {
                try
                {
                    _firstEnvelope = GetEnvelope(TextMessages.INPUT_PARAMETERS_FOR_FIRST_ENVELOPE);
                    _secondEnvelope = GetEnvelope(TextMessages.INPUT_PARAMETERS_FOR_SECOND_ENVELOPE);

                    string result = GetResultOfContains(_firstEnvelope, _secondEnvelope);

                    _userInterface.ShowResult(result);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(TextMessages.WRONG_PARAMETERS);
                    Log.Logger.Error($"{ex.Message} EnvelopeApp.Start");
                }

                isActive = _userInterface.RunAgain();
            }
            while (isActive);
        }

        private Envelope GetEnvelope(string infoForUser)
        {
            bool isValid = false;

            Envelope envelope = new Envelope();

            while (!isValid)
            {
                string[] split = _userInterface.GetInputForEnvelope(infoForUser).Split(' ');

                double height = Convert.ToDouble(split[0]);
                double width = Convert.ToDouble(split[1]);

                envelope = new Envelope(height, width);

                isValid = _validator.Validate(envelope).IsValid;

                if (!isValid)
                {
                    _userInterface.ShowInformation(TextMessages.WRONG_PARAMETERS);
                    Log.Logger.Error($"{TextMessages.WRONG_PARAMETERS} EnvelopeApp.GetEnvelope");
                }
            }

            return envelope;
        }

        private string GetResultOfContains(IEnvelope first, IEnvelope second)
        {
            string result = string.Empty;

            if (first.CanContains(second))
            {
                result = TextMessages.POSITIVE_RESULT_FOR_FIRST_ENVELOPE;
            }
            else if (second.CanContains(first))
            {
                result = TextMessages.POSITIVE_RESULT_FOR_SECOND_ENVELOPE;
            }
            else
            {
                result = TextMessages.NEGATIVE_RESULT_FOR_BOTH_ENVELOPES;
            }

            return result;
        }
    }
}
