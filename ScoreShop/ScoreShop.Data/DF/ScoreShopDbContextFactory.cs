using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScoreShop.Data.DF
{
    public class ScoreShopDbContextFactory : IDesignTimeDbContextFactory<ScoreShopDbContext>
    {
        public ScoreShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ScoreShopSlutionDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<ScoreShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ScoreShopDbContext(optionsBuilder.Options);
        }
    }
}
