using System.Reflection;
using Tournamint_BackEnd.Services;

namespace Tournamint_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IOperationTransient, GuidService>();
            builder.Services.AddScoped<IOperationScoped, GuidService>();
            builder.Services.AddSingleton<IOperationSingleton, GuidService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                option.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

                /*
                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header is using Bearer scheme. \r\n\r\n" +
                        "Enter token. \r\n\r\n" +
                        "Example: \"d5f41g85d1f52a\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                option.AddSecurityDefinition("Bearer", securityScheme);
                option.AddSecurityRequirement(new OpenApiSecurityRequirement { { securityScheme, new[] { "Bearer" } } });
                */
            });

            var app = builder.Build();

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