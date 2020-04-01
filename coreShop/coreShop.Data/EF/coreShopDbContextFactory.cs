using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace coreShop.Data.EF
{
    public class coreShopDbContextFactory : IDesignTimeDbContextFactory<coreShopDbContext>
    {
        public coreShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("coreShopSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<coreShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new coreShopDbContext(optionsBuilder.Options);
        }
    }
}
