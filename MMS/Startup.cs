using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MMS.DAL;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMS.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using MMS.BLL.Interfaces;
using MMS.BLL.Managers;
using MMS.BLL.Helpers;

namespace MMS
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MMS", Version = "v1" });
            });

            services.AddDbContext<DB_Context>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnStringTest")));
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<ITokenHelper, TokenHelper>();
            services.AddTransient<InitialSeed>();

            services
                .AddIdentity<User, Role>()
                .AddEntityFrameworkStores<DB_Context>()
                .AddDefaultTokenProviders();
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("AuthScheme", jwt =>
                {
                    jwt.RequireHttpsMetadata = true;
                    jwt.SaveToken = true;
                    var secret = Configuration.GetSection("Jwt").GetSection("Token").Get<String>();
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),

                        ValidateLifetime = true,

                     };

                    jwt.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            /*
             * "Admin",
                "Moderator",
                "User",
                "ArmyManager",
                "StateManager",
                "ConflictManager"
             */

            services.AddAuthorization(x =>
            {
                x.AddPolicy("Admin", policy => policy.RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthSchema").Build());
                x.AddPolicy("User", policy => policy.RequireRole("User").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthSchema").Build());
                x.AddPolicy("Moderator", policy => policy.RequireRole("Moderator").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthSchema").Build());
                x.AddPolicy("ArmyManager", policy => policy.RequireRole("ArmyManager").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthSchema").Build());
                x.AddPolicy("StateManager", policy => policy.RequireRole("StateManager").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthSchema").Build());
                x.AddPolicy("ConflictManager", policy => policy.RequireRole("ConflictManager").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthSchema").Build());

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InitialSeed initialSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MMS v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(app => app.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            initialSeed.CreateRoles();
        }



    }
}
