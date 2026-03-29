using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Mappings;
using NZWalksAPI.Repositories;

namespace NZWalksAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            //injecting db context
            builder.Services.AddDbContext<NZWalksDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksDbConnection")));

            //injecting automapper
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfiles>());

            //injecting region repository
            builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
            //injecting walk repository
            builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //debugging routes - claude ai
            //app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
            //string.Join("\n", endpointSources
            //.SelectMany(s => s.Endpoints)
            //.OfType<RouteEndpoint>()
            //.Select(e => $"{e.RoutePattern.RawText} | {e.DisplayName}")));

            app.Run();
        }
    }
}
