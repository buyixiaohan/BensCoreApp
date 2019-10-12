using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MikesBank.LogProvider;
using MikesBank.Models;
using Swashbuckle.AspNetCore.Swagger;
using VMD.RESTApiResponseWrapper.Core.Extensions;

namespace MikesBank
{
    /// <summary>
    /// 参考文档：Web API - Adding Swagger, SQL Server, Logging and Export to Excel
    /// https://www.codeproject.com/Articles/5205692/Web-API-Adding-Swagger-SQL-Server-Logging-and-Expo
    /// </summary>
    /// <remarks>
    /// Entity Framework with Audit Tables
    /// https://www.codeproject.com/Articles/5216095/Entity-Framework-with-Audit-Tables
    /// </remarks>
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
            this.env = env;
        }

        private IHostingEnvironment env { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            var pathIncludeXmlComments = $@"{env.ContentRootPath}\{env.ApplicationName}.xml";
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "MikesBank API",
                    Description = "采用net core 2.2开发"
                });

                if (System.IO.File.Exists(pathIncludeXmlComments))
                {
                    c.IncludeXmlComments(pathIncludeXmlComments);
                }
            });

            var connectionString = Configuration.GetConnectionString("MyDatabase");
            services.AddDbContext<MyDbContext>(op => op.UseSqlServer(connectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();


            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //启用中间件服务对swagger-ui，指定Swagger JSON终结点
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MikesBank API");
                c.RoutePrefix = string.Empty;
                c.InjectJavascript("Scripts/SwaggerUI/swagger_lang.js");
                //D:\Github\00 lanlive\MikesBank\MikesBank\Scripts\SwaggerUI\swagger_lang.js
            });
            app.UseAPIResponseWrapperMiddleware();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddContext(LogLevel.Information, Configuration.GetConnectionString("MyDatabase"));
        }
    }
}
