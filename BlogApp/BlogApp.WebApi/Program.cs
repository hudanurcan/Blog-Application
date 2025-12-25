
using BlogApp.WebApi.DependencyResolvers;
using BlogApp.Persistence.DependencyResolvers;
using BlogApp.Application.DependencyResolvers;
using BlogApp.InnerInfrastructure.DependencyResolvers;
using BlogApp.Application.Exceptions.Abstract;
using BlogApp.Application.Exceptions.Concrete;

namespace BlogApp.WebApi
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


            builder.Services.AddDbContextService();
            builder.Services.AddDtoMapperService();
            builder.Services.AddManagerService();
            builder.Services.AddRepositoryService();
            builder.Services.AddVmMapperService();
            builder.Services.AddScoped<ErrorHandler>();
            builder.Services.AddScoped<IErrorHandler, ErrorHandler>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));


            app.MapControllers();

            app.Run();
        }
    }
}
