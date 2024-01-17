using Bunit;
using FluentAssertions.Common;
using FrontEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.PostgreSql;
using Xunit;

namespace TestFrontEnd;

public class FrontEndTestContext : TestContext, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer;

    public FrontEndTestContext()
    {
        _dbContainer = new PostgreSqlBuilder()
            .WithImage("postgres")
            .WithPassword("Strong_password_123!")
            .Build();

        Services.AddDbContextFactory<FoodBoxDB>(options => options.UseNpgsql(_dbContainer.GetConnectionString()));
       /* Services.AddScoped<WeatherForecastService>();*/
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();

        var dbContext = Services.GetRequiredService<FoodBoxDB>();
        await dbContext.Database.MigrateAsync();
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }
}