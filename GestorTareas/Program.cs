using ProbarApp.Observer;
using ProbarApp.Servicios;

namespace ProbarApp
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
            builder.Services.AddTransient<Login>();
            builder.Services.AddTransient<FollowTask>();
            builder.Services.AddTransient<CrearTarea>();
            builder.Services.AddTransient<EliminarTarea>();
            builder.Services.AddTransient<BuscarTarea>();
            builder.Services.AddTransient<UnFollowTask>();
            builder.Services.AddTransient<Tasks>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}