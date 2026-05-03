using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NZWalksAPI.Data;
using NZWalksAPI.Mappings;
using NZWalksAPI.Repositories;
using NZWalksAPI.Services;
using System.Text;

namespace NZWalksAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //injecting db context
            builder.Services.AddDbContext<NZWalksDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksDbConnection")));
            //injecting auth db context
            builder.Services.AddDbContext<NZWalksAuthDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksAuthDbConnection")));

            //injecting automapper
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfiles>());

            //injecting region repository
            builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
            //injecting walk repository
            builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();
            //injecting image repository and image service
            builder.Services.AddScoped<IImageRepository, ImageRepository>();
            builder.Services.AddScoped<IImageService, ImageService>();
            //injecting token repository
            builder.Services.AddScoped<ITokenRepository, TokenRepository>();
            //injecting AuthService
            builder.Services.AddScoped<IAuthSercive, AuthService>();

            // Add Identity
            builder.Services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NZWalks")
                .AddEntityFrameworkStores<NZWalksAuthDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity options
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
            });

            //adding jwt authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudiences = new[] { builder.Configuration["Jwt:Audience"] },
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Images")),
                RequestPath = "/Images"
            });


            app.MapControllers();

            app.Run();
        }
    }
}
