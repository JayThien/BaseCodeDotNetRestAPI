using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ApplicationDomain.Entities;
using AspNetCore.EmailSender;
using AspNetCore.Mvc;
using AspNetCore.Mvc.JwtBearer;
using AspNetCore.UnitOfWork.EntityFramework;
using AutoMapper;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json;
using System.Threading.Tasks;
using ApplicationDomain.AuthenticationDomain;
using ApplicationDomain.Infrastructures.Extensions;
using ApplicationDomain.Infrastructures.Helper;
using ApplicationDomain.Infrastructures.Helper.ExceptionHelper;
using ApplicationDomain.Infrastructures.Http;
using ApplicationDomain.Infrastructures.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var EFConnectionString = Configuration.GetConnectionString("DefaultConnection");
            var jwtSecurityKey = Configuration.GetValue<string>("Security:Jwt:SecurityKey");
            var tokenTimeOutMinutes = Configuration.GetValue<long>("Security:Jwt:TokenTimeOutMinutes");
            services.Configure<FormOptions>(options => {
                options.BufferBody = true;
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = int.MaxValue;
            });
            services.AddOptions();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
            //services.AddMvcCore().AddApiExplorer();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Description =
            //            "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.ApiKey,
            //        In = ParameterLocation.Header,
            //        Scheme = "Bearer"
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            //            },
            //            new string[] {}
            //        }
            //    });
            //    c.DocInclusionPredicate((docName, apiDesc) =>
            //    {
            //        // Filter out 3rd party controllers
            //        var assemblyName = ((ControllerActionDescriptor)apiDesc.ActionDescriptor).ControllerTypeInfo.Assembly.GetName().Name;
            //        var currentAssemblyName = GetType().Assembly.GetName().Name;
            //        return currentAssemblyName == assemblyName;
            //    });

            //});
            services.AddCors();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<SendMail>(Configuration.GetSection("SendMailForgetPass"));
            services.Configure<SendMailOTP>(Configuration.GetSection("SendMailOTP"));
            services.Configure<SendMailGuests>(Configuration.GetSection("SendMailGuests"));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //JwtConfigService(services);
            MappingScopeService(services);
            services.AddControllers();

            //services.AddHttpContextAccessor();
            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
               options.UseSqlServer(EFConnectionString, sqlServerOptions =>
               {
                   sqlServerOptions.EnableRetryOnFailure();
               });
            });

            //// Add UoW 
            services.AddUnitOfWork<ApplicationDbContext>();
            //// Add Identity
            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders(); // protection provider responsible for generating an email confirmation token or a password reset token
            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Password settings
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequireLowercase = false;

            //    // Lockout settings
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(tokenTimeOutMinutes);
            //    options.Lockout.MaxFailedAccessAttempts = 10;
            //    options.Lockout.AllowedForNewUsers = true;

            //    // User settings
            //    options.User.RequireUniqueEmail = true;

            //    options.SignIn.RequireConfirmedEmail = true;
            //});

            services.AddAutoMapper(typeof(ApplicationDomain.AssemplyMarker));

            //services.Configure<FormOptions>(o =>
            //{
            //    o.ValueLengthLimit = int.MaxValue;
            //    o.MultipartBodyLengthLimit = int.MaxValue;
            //    o.MemoryBufferThreshold = int.MaxValue;
            //});
            // Add Jwt Bearer
            // IMPORTANCE: AddJwtBearerAuthentication should be added after services.AddIdentity, to replaced Authentication config in Identity
            services.AddJwtBearerAuthentication(options =>
            {
                options.SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecurityKey));
                options.TokenTimeOutMinutes = tokenTimeOutMinutes;
            });

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddSingleton<IEmailSender, EmailSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStaticHttpContext();
            app.UseCors(x => x.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseAuthentication();

            app.UseExceptionHandler(
                builder =>
                {
                    builder.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                context.Response.AddApplicationError(error.Error.Message);
                                await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                            }
                        });
                });

            MiddlewareConfig(app, loggerFactory);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OBC system v1"));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHub<SignalRHubService>("/api/SignalR");
            });
        }

        //private void JwtConfigService(IServiceCollection services)
        //{
        //    var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:SecurityKey"]));
        //    var issurer = Configuration["Jwt:JwtIssuerOptions:Issuer"];
        //    var audience = Configuration["Jwt:JwtIssuerOptions:Audience"];

        //    var tokenValidationParameters = new TokenValidationParameters
        //    {
        //        //The signing key must match !
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = signingKey,

        //        //Validate the JWT Issuer (iss) claim
        //        ValidateIssuer = true,
        //        ValidIssuer = issurer,

        //        //validate the JWT Audience (aud) claim

        //        ValidateAudience = true,
        //        ValidAudience = audience,

        //        //validate the token expiry
        //        ValidateLifetime = true,

        //        //
        //        RequireExpirationTime = true,

        //        // If you  want to allow a certain amout of clock drift
        //        ClockSkew = TimeSpan.Zero

        //    };

        //    // Make authentication compulsory across the board (i.e. shut
        //    // down EVERYTHING unless explicitly opened up).
        //    services.AddMvc(config =>
        //    {
        //        var policy = new AuthorizationPolicyBuilder()
        //                         .RequireAuthenticatedUser()
        //                         //.AddRequirements(new PermissionsRequirement())
        //                         .Build();
        //        config.Filters.Add(new AuthorizeFilter(policy));
        //        // config.Filters.Add(new RequireHttpsAttribute());
        //        config.RespectBrowserAcceptHeader = true;
        //        config.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
        //    })
        //    .AddJsonOptions(jsonOptions =>
        //    {
        //        //Suppress properties with null value
        //        //jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        //    });

        //    services.AddAuthentication(o =>
        //    {
        //        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //        o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        //    }).AddJwtBearer(options =>
        //    {
        //        options.TokenValidationParameters = tokenValidationParameters;
        //    });

        //    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //        .AddCookie(options =>
        //        {
        //            options.AccessDeniedPath = "/Account/Forbidden/";
        //            options.LoginPath = "/Account/Unauthorized/";
        //        });
        //    // Configure JwtIssuerOptions
        //    services.Configure<JwtIssuerOptions>(options =>
        //    {
        //        options.Issuer = issurer;
        //        options.Audience = audience;
        //        options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        //    });
        //}
        //private void JwtConfig(IApplicationBuilder app, ILoggerFactory loggerFactory)
        //{

        //}
        private void MappingScopeService(IServiceCollection services)
        {
            //General
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthService, AuthService>();
            //services.AddSingleton<IAuthorizationHandler, PermissionsHandler>();
            //UnitOfWork
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            //services.AddScoped<ISignalRHubService, SignalRHubService>();
        }
        private void MiddlewareConfig(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
        }
    }
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _delegate;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _delegate = next;
        }
        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            try
            {
                await _delegate(httpContext);
            }
            catch (Exception ex)
            {
                await ResponseExceptionHelper.HandleExceptionAsync(httpContext, ex);
            }
        }
    }
}
