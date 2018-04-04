using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Tarefas.Application.Interfaces;
using Tarefas.Application.Services;
using Tarefas.Domain.Interfaces.Repository.Persistance;
using Tarefas.Domain.Interfaces.Repository.ReadOnly;
using Tarefas.Domain.Interfaces.Services;
using Tarefas.Domain.Services;
using Tarefas.Infrastructure.Data.Context;
using Tarefas.Infrastructure.Data.Interfaces;
using Tarefas.Infrastructure.Data.Repository.Persistance;
using Tarefas.Infrastructure.Data.Repository.ReadOnly;
using Tarefas.Infrastructure.Data.UoW;

namespace Tarefas.Infrastructure.CrossCutting.IoC.Native
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            #region Application Services

            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<ITarefaAppService, TarefaAppService>();

            #endregion

            #region Domain Services

            services.AddScoped<ITarefaService, TarefaService>();

            #endregion

            #region Infra

            services.AddScoped<ITarefaEFRepository, TarefaEFRepository>();
            services.AddScoped<ITarefaDapperRepository, TarefaDapperRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TarefasDapperContext>();
            services.AddScoped<TarefasEFContext>(); 

            #endregion
        }
    }
}
