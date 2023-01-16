using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Escola_Net_Domain.Model;
using Microsoft.EntityFrameworkCore;
using Escola_Net_Domain.Interfaces;
using Escola_Net_Domain.Repositories;

namespace Escola_Net
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Configuração para retirar os Nulos do Json
            services.AddMvc().AddJsonOptions(op =>
            {
                op.JsonSerializerOptions.IgnoreNullValues = true;
            });

            //Configuração dO SWAGGER
            services.AddSwaggerGen(op =>
            {
                op.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Api Escola Net",
                    Version = "v1",
                    Description = "Serviço da Escola",
                });
            });

            //Configuração de compressão de dados
            services.Configure<GzipCompressionProviderOptions>(op =>
            {
                op.Level = CompressionLevel.Optimal;
            });

            services.AddResponseCompression(op =>
            {
                op.Providers.Add<GzipCompressionProvider>();
            });

            //Criando a Injeção de Dependencia de serviços de Http e contexto de session
            services.AddTransient<HttpClient, HttpClient>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Criando Configuração de Banco de Dados
            services.AddDbContext<ApplicationContext>(op =>
            {
                op.UseNpgsql(Configuration.GetConnectionString("PostgreSQL"));
            });

            services.AddTransient<IPessoaRepository, PessoaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Adicionando a Compressão dos dados
            app.UseResponseCompression();

            //Habilitando o Swagger na API
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Servico Escola Net"));
        }
    }
}
