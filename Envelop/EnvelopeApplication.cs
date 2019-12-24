using System;
using Serilog;

namespace Envelope
{
    public class EnvelopeApp
    {
        private const int COUNT_PARAMETERS = 2;
        private const int POSITIVE_COUNT_FOR_ARGS = 4;

        private readonly EnvelopeUI _userInterface;

        public EnvelopeApp()
        {
            _userInterface = new EnvelopeUI();
        }

        public void Start(string[] args)
        {
            do
            {
                IEnvelopeComparable firstEnvelope;
                IEnvelopeComparable secondEnvelope;

                ContainmentResult result;

                try
                {
                    if(args.Length != 0)
                    {
                        if(args.Length != POSITIVE_COUNT_FOR_ARGS)
                        {
                            throw new ArgumentException();
                        }
                        else
                        {
                            firstEnvelope = GetEnvelope(Convert.ToDouble(args[0])
                                , Convert.ToDouble(args[1]));

                            secondEnvelope = GetEnvelope(Convert.ToDouble(args[2])
                                , Convert.ToDouble(args[3]));
                        }
                    }
                    else
                    {
                        string[] inputFirst = _userInterface
                        .GetInputForEnvelope(TextMessages.INPUT_PARAMETERS_FOR_FIRST_ENVELOPE).Split(' ');

                        string[] inputSecond = _userInterface
                            .GetInputForEnvelope(TextMessages.INPUT_PARAMETERS_FOR_SECOND_ENVELOPE).Split(' ');

                        double[] parametersForFirst = ConvertToDoubleInput(inputFirst);
                        double[] parametersForSecond = ConvertToDoubleInput(inputSecond);

                        firstEnvelope = GetEnvelope(parametersForFirst[0], parametersForFirst[1]);
                        secondEnvelope = GetEnvelope(parametersForSecond[0], parametersForSecond[1]);
                    }

                    result = GetResultOfContains(firstEnvelope, secondEnvelope);

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

                Array.Clear(args, 0, args.Length);
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
