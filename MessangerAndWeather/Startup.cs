using Core.Domain;
using Core.Repoisitory;
using Core.Service;
using infra.Domain;
using infra.Repoisitory;
using infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessangerAndWeather
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
            // Conction DataBase
            services.AddScoped<IDBContext, DBContext>();

            // Add Reposotriy Scoped
            services.AddScoped(typeof(IGenericRepoisitory<>), typeof(GenericRepoisitory<>));
            services.AddScoped<IOthersRepoisitory, OthersRepoisitory>();


            // Add Serveis Scoped
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IOthersService, OthersService>();


            //Extra Api IWeatherForecastService
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            //Email Servis
            services.AddScoped<IEmailService, EmailService>();


            //JWT
            services.AddScoped<IAuthenticationRepoisitory ,AuthenticationRepoisitory>();
            services.AddScoped<IAuthenticationService ,AuthenticationService>();
            services.AddScoped<IOthersService, OthersService>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            ).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });


            services.AddControllers();
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
        }
    }
}
