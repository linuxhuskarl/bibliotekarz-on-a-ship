using Bibliotekarz.Data.Context;
using Bibliotekarz.Data.Model;
using Bibliotekarz.Data.Repositories;
using BibliotekarzBlazor.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace BibliotekarzBlazor.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"))
            .EnableSensitiveDataLogging().EnableDetailedErrors());

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<DbContext, AppDbContext>();
        builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        builder.Services.AddScoped(typeof(IKeyRepository<,>), typeof(KeyRepository<,>));
        
        builder.Services.AddScoped<IBookService, BookService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            //app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseAuthorization();

        app.MapControllers();
        app.MapFallbackToFile("index.html");

        //if (app.Environment.IsDevelopment())
        //{
            using (AppDbContext? dbContext = app.Services.CreateScope().ServiceProvider.GetService<AppDbContext>())
            {
                dbContext?.Database.Migrate();
            }
        //}

        app.Run();
    }
}