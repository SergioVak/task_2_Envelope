using System;
using Serilog;

namespace Envelope
{
    public class EnvelopeUI
    {
        public string GetInputForEnvelope(string informationForUser)
        {
            Console.WriteLine(informationForUser);

            return Console.ReadLine();
        }

        public bool IsRunAgain()
        {
            bool reAsk = false;
            bool result = false;

            do
            {
                string input = string.Empty;

                Console.WriteLine(TextMessages.RUN_AGAIN);
                input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case TextMessages.YES:
                    case TextMessages.Y:
                        result = true;
                        reAsk = false;

                        break;

                    case TextMessages.NO:
                    case TextMessages.N:
                        result = false;
                        reAsk = false;

                        break;

                    default:
                        Log.Logger.Information($"UI default. RunAgain {input}");
                        Console.WriteLine(TextMessages.WRONG_INPUT);
                        Console.WriteLine();

                        reAsk = true;

                        break;
                }
            }
            while (reAsk);

            return result;
        }

        public void ShowResult(ContainmentResult result)
        {
            Console.WriteLine();

            switch(result)
            {
                case ContainmentResult.PositiveFirst:

                    Console.WriteLine(TextMessages.POSITIVE_RESULT_FOR_FIRST_ENVELOPE);
                    break;

                case ContainmentResult.PositiveSecond:

                    Console.WriteLine(TextMessages.POSITIVE_RESULT_FOR_SECOND_ENVELOPE);
                    break;

                case ContainmentResult.NegativeBoth:

                    Console.WriteLine(TextMessages.NEGATIVE_RESULT_FOR_BOTH_ENVELOPES);
                    break;

                default:

                    //TODO log
                    break;

            }

            Console.WriteLine("\n" + new string('-', 50));
        }

        public void ShowInformation(string information)
        {
            Console.WriteLine(information);
        }
    }
}
