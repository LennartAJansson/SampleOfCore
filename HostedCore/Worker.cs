using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostedCore
{
    public class Worker : IHostedService
    {
        private readonly ILogger<Worker> logger;
        private readonly IConfiguration configuration;
        private readonly IEnumerable<IMyService> myServices;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, IEnumerable<IMyService> myServices)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.myServices = myServices;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogDebug("Starting worker, db is: {db}...", configuration.GetConnectionString("MyConnection"));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (myServices.Any(s => s.Name == "Base"))
                myServices.First(s => s.Name == "Base").RunMyService();

            if (myServices.Any(s => s.Name == "Extended"))
                myServices.First(s => s.Name == "Extended").RunMyService();

            logger.LogTrace("Stopping worker...");
            return Task.CompletedTask;
        }
    }
}