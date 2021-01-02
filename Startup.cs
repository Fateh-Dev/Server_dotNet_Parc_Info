using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionParcInformatique.Authentication;
using GestionParcInformatique.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace GestionParcInformatique
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
            services.AddDbContext<GParcInfoContext>(x => x.UseSqlite("Data Source=GParcInfo.db"));
            services.AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = "Learning ASP.Net Core 3.0 Rest-API",
                            Version = "v1",
                            Description = "Demonstrating auto-generated API documentation",
                            Contact = new OpenApiContact
                            {
                                Name = "Djehient Fateh",
                                Email = "fateh@mail.com",
                            },
                            License = new OpenApiLicense
                            {
                                Name = "MIT",
                            }
                        });
                    });
            services.AddControllers();
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options=>options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                            options => Configuration.Bind("JwtSettings", options))
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => Configuration.Bind("CookieSettings", options));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IEtatRepo, SqlEtatRepo>();
            services.AddScoped<IMarqueRepo, SqlMarqueRepo>();
            services.AddScoped<IModelArticleRepo, SqlModelArticleRepo>();
            services.AddScoped<ICategorieRepo, SqlCategorieRepo>();
            services.AddScoped<ICouleurRepo, SqlCouleurRepo>();
            services.AddScoped<ITypeArticleRepo, SqlTypeArticleRepo>();
            services.AddScoped<ITypeDocumentRepo, SqlTypeDocumentRepo>();
            services.AddScoped<ITypeMouvementRepo, SqlTypeMouvementRepo>();
            services.AddScoped<IUniteMesureRepo, SqlUniteMesureRepo>();
            services.AddScoped<IMagasinRepo, SqlMagasinRepo>();
            services.AddScoped<IPersonneRepo, SqlPersonneRepo>();
            services.AddScoped<IArticleRepo, SqlArticleRepo>();
            services.AddScoped<IServiceRepo, SqlServiceRepo>();
            services.AddScoped<IDocumentRepo, SqlDocumentRepo>();
            services.AddScoped<IOperationArticleRepo, SqlOperationArticleRepo>();
            services.AddScoped<IModeConsommationRepo, SqlModeConsommationRepo>();

            // For Identity  
            services.AddIdentity<GestionParcInformatique.Models.Utilisateur, IdentityRole>()
                .AddEntityFrameworkStores<GParcInfoContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x=>x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                     "Gestion Material Informatiques");
                c.RoutePrefix = string.Empty;
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
