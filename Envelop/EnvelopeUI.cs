using System;
using Serilog;

namespace Envelope
{
    public class EnvelopeUI
    {
        public string GetUserParametersForEnvelope(string informationForUser)
        {
            Console.WriteLine(informationForUser);

            return Console.ReadLine();
        }

        public bool RunAgain()
        {
            string input = string.Empty;
            bool result;

            Console.WriteLine(TextMessages.RUN_AGAIN);
            input = Console.ReadLine();

            switch (input.ToLower())
            {
                case TextMessages.YES:
                case TextMessages.Y:
                    result = true;
                    break;

                case TextMessages.NO:
                case TextMessages.N:
                    result = false;
                    break;

                default:
                    Log.Logger.Information($"UI default. RunAgain {input}");
                    Console.WriteLine(TextMessages.RUN_AGAIN);

                    return RunAgain();
            }

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
