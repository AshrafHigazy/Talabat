using PersintenceLayer;
using ServiceLayer;
using TalabatDemo.Extensions;


namespace TalabatDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSwaggerService();


            builder.Services.AddInfrastructureServices(builder.Configuration);


            builder.Services.AddApplicationServices();

            builder.Services.AddWebApplicationServises();

            #endregion

            var app = builder.Build();

            await app.SeedDatabaseAsync();


            app.UseCustomExceptionMiddleware();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseStaticFiles();


            app.MapControllers();

            app.Run();
        }
    }
}
