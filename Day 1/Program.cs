using Microsoft.CodeAnalysis.Options;

namespace Day_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string txt = "";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //builder.Services.AddControllers()  // is not Teh best Solution
            //    .AddNewtonsoftJson(option =>
            //option.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore);

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            //builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option => {
                option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My First API",
                    Version = "v1",
                    Description = "This is my first ASP.NET Core Web API",
                    TermsOfService = new Uri("https://www.linkedin.com/in/adham-mohamed74/"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Adham Mohamed",
                        Email = "adhamdr10@gmail.com"
                    }
                });


                option.EnableAnnotations(); // to use Swagger Annotations
            }
            );

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetSection("constr").Value;
                options.UseLazyLoadingProxies().UseSqlServer(connectionString);
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(txt, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
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

            app.UseCors(txt);
            app.MapControllers();

            app.Run();
        }
    }
}
