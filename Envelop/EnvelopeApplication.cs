using System;
using Serilog;

namespace Envelope
{
    public class EnvelopeApp
    {
        private const int COUNT_PARAMETERS = 2;

        private readonly EnvelopeUI _userInterface;

        public EnvelopeApp()
        {
            _userInterface = new EnvelopeUI();
        }

        public void Start()
        {
            do
            {
                try
                {
                    string[] inputFirst = _userInterface
                        .GetInputForEnvelope(TextMessages.INPUT_PARAMETERS_FOR_FIRST_ENVELOPE).Split(' ');

                    string[] inputSecond = _userInterface
                        .GetInputForEnvelope(TextMessages.INPUT_PARAMETERS_FOR_SECOND_ENVELOPE).Split(' ');

                    double[] parametersForFirst = ConvertToDoubleInput(inputFirst);
                    double[] parametersForSecond = ConvertToDoubleInput(inputSecond);

                    IEnvelopeComparable firstEnvelope = GetEnvelope(parametersForFirst[0], parametersForFirst[1]);
                    IEnvelopeComparable secondEnvelope = GetEnvelope(parametersForSecond[0], parametersForSecond[1]);


                    ContainmentResult result = GetResultOfContains(firstEnvelope, secondEnvelope);

                    _userInterface.ShowResult(firstEnvelope, secondEnvelope, result);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(TextMessages.WRONG_PARAMETERS);
                    Log.Logger.Error($"{ex.Message} EnvelopeApp.Start");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(TextMessages.WRONG_PARAMETERS);
                    Log.Logger.Error($"{ex.Message} EnvelopeApp.Start");
                }
            }
            while (_userInterface.IsRunAgain());
        }

        private double[] ConvertToDoubleInput(string[] split)
        {
            if(split.Length != COUNT_PARAMETERS)
            {
                throw new ArgumentException("Invalid arguments for envelope");
            }
        
            double[] result = new double[2];

            result[0] = Convert.ToDouble(split[0]);
            result[1] = Convert.ToDouble(split[1]);

            return result;
        }

        private Envelope GetEnvelope(double height, double width)
        {
            EnvelopeValidator validator = new EnvelopeValidator();

            Envelope envelope = new Envelope(height, width);

            if (validator.Validate(envelope).IsValid)
            {
                return envelope;
            }

            throw new ArgumentException("Invalid arguments for envelope");
        }

        private ContainmentResult GetResultOfContains
            (IEnvelopeComparable first, IEnvelopeComparable second)
        {
            ContainmentResult result;

            if (first.IsContains(second)) 
            {
                result = ContainmentResult.PositiveFirst;
            }
            else if (second.IsContains(first))
            {
                result = ContainmentResult.PositiveSecond;
            }
            else
            {
                result = ContainmentResult.NegativeBoth;
            }

            return result;
        }
    }
}
