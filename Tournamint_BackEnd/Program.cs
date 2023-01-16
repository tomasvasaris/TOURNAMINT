using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Tournamint_BackEnd.Database;
using Tournamint_BackEnd.Services;
using Tournamint_BackEnd.Repositories;
using Tournamint_BackEnd.Models;

namespace Tournamint_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MatchContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("MatchConnectionString"));
            });

            builder.Services.AddTransient<IRepository<Match>, MatchRepository>();
            builder.Services.AddTransient<IMatchAdapter, MatchAdapter>();

            builder.Services.AddHttpContextAccessor();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            builder.Services.AddCors(p => p.AddPolicy("corsformatches", builder =>
            {
                builder.WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("corsformatches");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}