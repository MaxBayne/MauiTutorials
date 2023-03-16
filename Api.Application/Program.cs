using Api.Application.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Api.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Config Dependency Injection
            builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlite(builder.Configuration.GetConnectionString("HR_db_ConnectionString")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGet("", context =>
            {
                context.Response.Redirect("swagger");
                return Task.CompletedTask;
            });

            app.Run();
        }
    }
}