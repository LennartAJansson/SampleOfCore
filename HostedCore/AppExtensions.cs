using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HostedCore
{
    public static class AppExtensions
    {
        public static IHost UseMyService(this IHost host)
        {
            IServiceScope scope = host.Services.CreateScope();
            scope.ServiceProvider
                .GetRequiredService<IMyService>()
                .RunMyService();
            return host;
        }
    }
}