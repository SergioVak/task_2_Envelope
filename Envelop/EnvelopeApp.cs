using System;
using Serilog;

namespace Envelope
{
    public class EnvelopeApp
    {
        private EnvelopeUI _userInterface;

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
                    string result = GetResultOfContains();
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


        private string GetResultOfContains()
        {
            string result = string.Empty;

            string[] splitForFirstEnvepole = _userInterface.GetUserParametersForEnvelope(TextMessages.INPUT_PARAMETERS_FOR_FIRST_ENVELOPE)
                .Split(' ');
            string[] splitForSecondEnvepole = _userInterface.GetUserParametersForEnvelope(TextMessages.INPUT_PARAMETERS_FOR_SECOND_ENVELOPE)
               .Split(' ');

            double height = Convert.ToDouble(splitForFirstEnvepole[0]);
            double width = Convert.ToDouble(splitForFirstEnvepole[1]);

            Envelope firstEnvelope = new Envelope(height, width);

            height = Convert.ToDouble(splitForSecondEnvepole[0]);
            width = Convert.ToDouble(splitForSecondEnvepole[1]);

            Envelope secondEnvelope = new Envelope(height, width);

            if (firstEnvelope.CanContains(secondEnvelope))
            {
                result = TextMessages.POSITIVE_RESULT_FOR_FIRST_ENVELOPE;
            }
            else if (secondEnvelope.CanContains(firstEnvelope))
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
