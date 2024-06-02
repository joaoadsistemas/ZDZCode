
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ZDZCode.API.Context;
using ZDZCode.API.Entities;
using ZDZCode.API.Repositories;
using ZDZCode.API.Repositories.Interfaces;
using ZDZCode.API.Services;
using ZDZCode.API.Services.Interfaces;

namespace ZDZCode.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            /* Database Context Dependency Injection */
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True";
            builder.Services.AddDbContext<SystemDbContext>(opt => 
                opt.UseSqlServer(connectionString));
            //builder.Configuration.GetConnectionString("DefaultConnection")) // SE QUISER USAR O SQL BASTA COLAR ESSA LINHA DENTRO DO "opt => opt.UseSqlServer(!AQUI!)"
            /* ===================================== */




            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IHotelService, HotelService>();

            builder.Services.AddScoped<IRentRepository, RentRepository>();
            builder.Services.AddScoped<IRentService, RentService>();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();




            //////////////////////////////////////////////////////////////////////////////////////////////////////////////// DOCKER
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SystemDbContext>();

                // Lista de todas as entidades que você deseja verificar
                var entitiesToCheck = new List<Type>
                {
                    typeof(Hotel),
                    typeof(Person),
                    typeof(Rent),
                  
                };

                foreach (var entity in entitiesToCheck)
                {
                    var tableExists = dbContext.Model.FindEntityType(entity) != null;

                    if (!tableExists)
                    {
                        if (dbContext.Database.GetPendingMigrations().Any())
                        {
                            dbContext.Database.Migrate();
                            break; // Se uma migração for aplicada, não há necessidade de verificar outras entidades
                        }
                    }
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////





            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowOrigin");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
