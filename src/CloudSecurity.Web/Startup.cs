using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CloudSecurity.Infrastructure.Logging;
using System.IO;

namespace CloudSecurity.Web
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true; //если равно false, то SSL при отправке токена не используется.
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        //указывает, будет ли валидироваться издать при валидации токена
                        ValidateIssuer = true,
                        //строка, представляющая издатель
                        ValidIssuer = AuthOptions.ISSUER,

                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthOptions.AUDIENCE,
                        // будет ли валидироваться время существование 
                        ValidateLifetime = true,

                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // если проект в процессе разработки
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                // установка обработчика ошибок
                //app.UseExceptionHandler("/Home/Error");
            }

            app.UseDefaultFiles();
            // установка обработчика статических файлов
            app.UseStaticFiles();

            // установка аутентификации пользователя на основе JWT Token
            app.UseAuthentication();
            // Установка компонентов MVC для обработки запроса
            app.UseMvc();

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory() + "\\LogFiles\\", "logger.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");

            app.Run(async (context) =>
            {
                logger.LogInformation("Processing request {0}", context.Request.Path);
            });

        }
    }
}
