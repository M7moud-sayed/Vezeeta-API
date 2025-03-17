
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using VezeetaAPI.Models;

namespace VezeetaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var AllowAll = "AllowAll";

            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(VezeetaAPI.MappingConfig.MapperConfig));

            builder.Services.AddDbContext<VezeetaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("VezeetaConnection")));


            builder.Services.AddCors(options =>
            {
                options.AddPolicy(AllowAll,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    });
            });



            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(AllowAll);

            app.UseAuthorization();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "images")),
                RequestPath = "/images"
            });

            app.MapControllers();

            app.Run();
        }
    }
}
