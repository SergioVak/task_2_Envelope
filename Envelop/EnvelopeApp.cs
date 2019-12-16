using System;
using Serilog;

namespace Envelope
{
    public class EnvelopeApp
    {
        private readonly EnvelopeUI _userInterface;

        private IEnvelope _firstEnvelope;
        private IEnvelope _secondEnvelope;

        public EnvelopeApp()
        {
            _userInterface = new EnvelopeUI();
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
                    Log.Logger.Error($"{ex.Message} SequenceApp.Start");
                }

                isActive = _userInterface.RunAgain();
            }
            while (isActive);
        }

        private Envelope GetEnvelope(string infoForUser)
        {
            string[] split = _userInterface.GetInputForEnvelope(infoForUser).Split(' ');

            double height = Convert.ToDouble(split[0]);
            double width = Convert.ToDouble(split[1]);

            return new Envelope(height, width);
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
