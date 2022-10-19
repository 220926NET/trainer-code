using BusinessLayer;

namespace ApiDemo1;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //use this statement as a template for configuring DI
        builder.Services.AddScoped</*interfaceName1,*/ Class1>();
        // builder.Services.AddScoped</*interfaceName2,*/ Class2>();

        WebApplication? app = builder.Build();

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
