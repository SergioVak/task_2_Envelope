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

        public bool RunAgain()
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

        public void ShowResult(string result)
        {
            Console.WriteLine();

            Console.WriteLine(result);

            Console.WriteLine("\n" + new string('-', 50));
        }
    }
}
