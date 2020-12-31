using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using System.Reflection;
using Autofac.Core.NonPublicProperty;
using Autofac.Extras.DynamicProxy;
using System.IO;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using CommandPrompterServer.Helpers;
using CommandPrompterServer.Models.Dao;
using CommandPrompterServer.Services;
using AutoMapper;
using CommandPrompterServer.Models;

namespace CommandPrompterServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Microsfot default configuration using appsettings.json
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            GlobalConfiguration.ImportConfiguration(Configuration);
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).AddControllersAsServices();
            services.AddControllers();
            services.AddQuartz();

            services.AddCors();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerGeneratorOptions.IgnoreObsoleteActions = true;
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CommandPrompter",
                    Version = "v1"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);

                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                    }
                });
            });

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtToken:Issuer"],
                    ValidAudience = Configuration["JwtToken:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtToken:SecretKey"]))
                };
            });

        }

        /// <summary>
        /// core 3.0+ requires this way to replace the default DI container
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfiles());
            });
            IMapper mapper = mapperConfig.CreateMapper();

            builder.RegisterInstance(mapper)
                .As<IMapper>()
                .PropertiesAutowired()
                .AutoWireNonPublicProperties()
                .SingleInstance();

            // Register your own things directly with Autofac
            builder.RegisterType<ServiceInterceptor>()
                .PropertiesAutowired()
                .AutoWireNonPublicProperties()
                .InstancePerDependency();
            builder.RegisterType<ManagerInterceptor>()
                .PropertiesAutowired()
                .AutoWireNonPublicProperties()
                .InstancePerDependency();

            //I use the globalConfiguration instead because to use this i need to register every used class in here which is so tedious.
            //builder.RegisterInstance(Configuration)
            //    .As<IConfiguration>()
            //    .PropertiesAutowired()
            //    .AutoWireNonPublicProperties()
            //    .SingleInstance();
            builder.RegisterType<Helpers.SimpleFileLogger>()
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .AutoWireNonPublicProperties()
                .SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.Contains("Impl"))
                .AutoWireNonPublicProperties()
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .SingleInstance();

            foreach (var controllerType in Assembly.GetExecutingAssembly().ExportedTypes)
                if (controllerType.IsSubclassOf(typeof(Controller)))
                    builder.RegisterType(controllerType).PropertiesAutowired().AutoWireNonPublicProperties()
                        .SingleInstance();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CommandPrompter");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(option => option
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMvc();
        }
    }
}
