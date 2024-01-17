using FoodBoxClassLibrary.Data;
using FrontEnd;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.PostgreSql;

namespace FoodBoxBlazorTest.Tests
{
    public class FoodBoxWebApplicationFacotry : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _dbContainer;
        // private FoodBoxDB _dbContext;
        // public FoodBoxDB dbContext { get => _dbContext; }

        public FoodBoxWebApplicationFacotry()
        {
            var backupFile = Directory.GetFiles("../../../..", "*.sql", SearchOption.AllDirectories)
                .Select(f => new FileInfo(f))
                .OrderByDescending(fi => fi.LastWriteTime)
                .First();

            _dbContainer = new PostgreSqlBuilder()
              .WithImage("postgres")
              .WithPassword("P@ssword!")
              .WithBindMount(backupFile.FullName, "/docker-entrypoint-initdb.d/init.sql")
              .Build();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<FoodBoxDB>));
                //_dbContext = new FoodBoxDB(options => options.UseNpgsql(_dbContainer.GetConnectionString()));
                services.AddDbContext<FoodBoxDB>(options => options.UseNpgsql(_dbContainer.GetConnectionString()));
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
        }
        async Task IAsyncLifetime.DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }
    }
}
