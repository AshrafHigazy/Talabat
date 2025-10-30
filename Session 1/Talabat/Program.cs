
using DomanLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer;
using PersistenceLayer.Data;

namespace Talabat
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDataSeeding,DataSeeding>(); //

            #endregion

            var app = builder.Build();

            using var scope=app.Services.CreateScope();//Manual Engection 
            var seedobj=scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            seedobj.DataSeed();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
