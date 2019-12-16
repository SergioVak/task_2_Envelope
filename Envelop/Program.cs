using System;
using Serilog;

namespace Envelope
{
    public class Program
    {
        static void Main(string[] args)
        {
            EnvelopeApp _app = new EnvelopeApp();

            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
               .WriteTo.File("log.txt").CreateLogger();

            try
            {
                _app.Start();
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"{ex.Message} Main");
            }
        }
    }
}
