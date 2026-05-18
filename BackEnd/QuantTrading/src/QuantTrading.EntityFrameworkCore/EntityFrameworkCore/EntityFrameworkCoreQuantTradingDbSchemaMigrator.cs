using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuantTrading.Data;
using Volo.Abp.DependencyInjection;

namespace QuantTrading.EntityFrameworkCore;

public class EntityFrameworkCoreQuantTradingDbSchemaMigrator
    : IQuantTradingDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreQuantTradingDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the QuantTradingDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<QuantTradingDbContext>()
            .Database
            .MigrateAsync();
    }
}
