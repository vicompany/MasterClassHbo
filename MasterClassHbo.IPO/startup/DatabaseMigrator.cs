using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MasterClassHbo.Ipo.startup
{
    public class DatabaseMigrator : IHostedService
    {
        private int retryCount;
        private readonly ILogger<DatabaseMigrator> logger;
        private readonly IpoRegistrationContext dbContext;

        public DatabaseMigrator(
            ILogger<DatabaseMigrator> logger,
            IServiceProvider serviceProvider)
        {
            this.logger = logger;
            this.dbContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IpoRegistrationContext>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Migration(cancellationToken);
        }

        private async Task Migration(CancellationToken cancellationToken)
        {
            try
            {
                this.logger.LogInformation("Starting database migration.");

                await this.dbContext.Database.MigrateAsync(cancellationToken); 

                this.logger.LogInformation("Database migration completed.");
            }
            catch (Exception ex)
            {
                this.logger.LogWarning(ex, "Migration failed.. trying again in 15 seconds");
                Thread.Sleep(1000 * 15);
                this.retryCount++;
                this.logger.LogWarning(ex, $"Retrying for the {this.retryCount}th time");
                await Migration(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
