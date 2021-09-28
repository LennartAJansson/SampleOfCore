using Microsoft.Extensions.Logging;

namespace HostedCore
{
    public class MyService : IMyService
    {
        private readonly ILogger<MyService> logger;
        public string Name { get; } = "Base";

        public MyService(ILogger<MyService> logger)
        {
            this.logger = logger;
        }

        public void RunMyService()
        {
            logger.LogInformation("Running like hell...");
        }
    }

    public class MyService2 : IMyService
    {
        private readonly ILogger<MyService2> logger;
        public string Name { get; } = "Extended";

        public MyService2(ILogger<MyService2> logger)
        {
            this.logger = logger;
        }

        public void RunMyService()
        {
            logger.LogInformation("Running like hell...");
        }
    }
}