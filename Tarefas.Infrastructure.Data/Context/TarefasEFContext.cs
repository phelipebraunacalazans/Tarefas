using Microsoft.EntityFrameworkCore;
using System.IO;
using Tarefas.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Tarefas.Infrastructure.Data.EntityConfig;
using Eventos.IO.Infra.Data.Extensions;

namespace Tarefas.Infrastructure.Data.Context
{
    public class TarefasEFContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new TarefasConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")    //como se fosse um app.config
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            
            //Colocar no csproj
            //<PackageReference Include="Microsoft.Extensions.Configuration.FileExtension" Version="1.1.0" />
        }

    }
}
