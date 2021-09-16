using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using xyzAPIlibreria.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using xyzAPIlibreria.Data;
using Microsoft.EntityFrameworkCore;
using xyzAPIlibreria.IService;
using xyzAPIlibreria.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;

namespace xyzAPIlibreria
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
            {
                //JwtConfig
                services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

                //DATABASECONTEXT!!!????
                services.AddDbContext<ApiDbContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("sql10436778")
                    ));

                //Enable CORS
                services.AddCors(c =>
                {
                    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                });

                //JSON serializer

                services.AddControllersWithViews().AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                    = new DefaultContractResolver());
                
                //AuthOptions
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                    .AddJwtBearer(jwt =>
                    {
                        var Key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

                        jwt.SaveToken = true;
                        jwt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Key),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            RequireExpirationTime = false
                        };
                    });

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApiDbContext>();

                services.AddControllers();

                services.AddScoped<IUserService, UserService>();

                services.AddVersionedApiExplorer(c =>
                {
                    c.GroupNameFormat = "'v'VVV";
                    c.SubstituteApiVersionInUrl = true;
                    c.AssumeDefaultVersionWhenUnspecified = true;
                    c.DefaultApiVersion = new ApiVersion(1, 0);

                });

                services.AddApiVersioning(c =>
                {
                    c.ReportApiVersions = true;
                    c.AssumeDefaultVersionWhenUnspecified = true;
                    c.DefaultApiVersion = new ApiVersion(1, 0);
                });

                services.AddSwaggerGen(c =>
                {
                    
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "xyzAPIlibreria", Version = "v1", Description = "RestApiCrud para gestion de libreria" });
                    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        Scheme = "basic",
                        In = ParameterLocation.Header,
                        Description = "Basic Auth Header"
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[]{}
                    }

                });
                });

                services.AddAuthentication("BasicAuthentication")
                    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
                
                services.AddRouting();

            }

            
                
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Enalbe CORS

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "xyzAPIlibreria v1"));
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c=>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestService");
            });
            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}