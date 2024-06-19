using Microsoft.OpenApi.Models;
using Model.JwtModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        // Services
        builder.Services.AddSingleton<Repository.Context.DapperContext>();
        builder.Services.AddScoped<Repository.Interfaces.IAuth, Repository.Services.Auth>();
        builder.Services.AddScoped<Repository.Interfaces.ILogin, Repository.Services.Login>();
        builder.Services.AddScoped<Business.Interfaces.ILogin, Business.Services.Login>();
        builder.Services.AddScoped<Repository.Interfaces.IRegisteration, Repository.Services.Registeration>();
        builder.Services.AddScoped<Business.Interfaces.IRegisteration, Business.Services.Registeration>();
        builder.Services.AddScoped<Business.Interfaces.IBook, Business.Services.Book>();
        builder.Services.AddScoped<Repository.Interfaces.IBook, Repository.Services.Book>();
        builder.Services.AddScoped<Repository.Interfaces.ICart, Repository.Services.Cart>();
        builder.Services.AddScoped<Business.Interfaces.ICart, Business.Services.Cart>();

        // Jwt 
        var jwtSettings = builder.Configuration.GetSection("JwtSetting").Get<JwtSettingModel>();
        if (jwtSettings != null)
        {
            builder.Services.AddSingleton(jwtSettings);

            if (jwtSettings.SecretKey != null)
            {
                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                });
            }
        }

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book Store", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                     new OpenApiSecurityScheme
                     {
                        Reference = new OpenApiReference
                        {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                        }
                     },
                     Array.Empty<string>()
                }
            });
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();

        app.UseCors("AllowSpecificOrigin");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}