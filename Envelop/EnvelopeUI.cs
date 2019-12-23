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

        public void ShowResult(IEnvelope first, IEnvelope second, ContainmentResult result)
        {
            Console.WriteLine();

            switch(result)
            {
                case ContainmentResult.PositiveFirst:

                    ShowEnvelope(first, TextMessages.FIRST);
                    Console.WriteLine(TextMessages.POSITIVE_RESULT);
                    ShowEnvelope(second, TextMessages.SECOND);

                    break;

                case ContainmentResult.PositiveSecond:

                    ShowEnvelope(second, TextMessages.SECOND);
                    Console.Write(TextMessages.POSITIVE_RESULT);
                    ShowEnvelope(first, TextMessages.FIRST);

                    break;

                case ContainmentResult.NegativeBoth:

                    Console.WriteLine(TextMessages.NEGATIVE_RESULT_FOR_BOTH_ENVELOPES);
                    break;

                default:

                    Log.Logger.Information($"UI default. ShowResult {result}");
                    break;

            }

            Console.WriteLine("\n" + new string('-', 50));
        }

        public void ShowInformation(string information)
        {
            Console.WriteLine(information);
        }

        private void ShowEnvelope(IEnvelope envelope, string numberOfEnvelope)
        {
            Console.Write($"{numberOfEnvelope} envelope ({envelope.Height} : { envelope.Width}) ");
        }
    }
}
