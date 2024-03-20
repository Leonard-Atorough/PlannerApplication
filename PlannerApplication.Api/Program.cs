using PlannerApplication.Api.Endpoints;
using PlannerApplication.Api.Mappers;
using PlannerApplication.Infrastructure.Data;
using PlannerApplication.Infrastructure.Data.MongoDb;

namespace PlannerApplication.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
            builder.Services.AddAutoMapper(typeof(DomainMappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapCalendarEndpoints();

            app.Run();
        }
    }
}
