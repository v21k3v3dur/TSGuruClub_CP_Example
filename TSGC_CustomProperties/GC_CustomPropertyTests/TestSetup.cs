using NUnit.Framework;
using Serilog;
using Serilog.Events;

namespace GC_CustomPropertyTests
{

    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            // Configure Serilog to write log messages to the console
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            // Close and flush the log when the tests are finished
            Log.CloseAndFlush();
        }
    }
}
