namespace RealState.Infrastructure.SQLDataAccess
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public partial class RealstateContext
    {
        private readonly IConfigurationRoot configuration;

        public RealstateContext()
        {
            this.configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DataBaseConnection"));
            }
        }
    }
}
