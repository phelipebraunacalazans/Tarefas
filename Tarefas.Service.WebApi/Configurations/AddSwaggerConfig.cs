using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Tarefas.Service.WebApi.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Tarefas API",
                    Description = "API Tarefas",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Py Tech", Email = "phelipebrauna@gmail.com", Url = "http://pytech.com.br" },
                    License = new License { Name = "MIT", Url = "http://pytech.com.br" }
                });

                //s.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            //services.ConfigureSwaggerGen(opt =>
            //{
            //    opt.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            //});
        }
    }
}
