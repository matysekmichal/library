using AutoMapper;
using Library.Controllers;
using Library.Data;
using Library.Data.Repository;
using Library.Data.Seed;
using Library.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ReservationRepository = Library.Data.Repository.ReservationRepository;
using SwaggerOptions = Library.Options.SwaggerOptions;

namespace Library
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<AuthorRepository>();
            services.AddScoped<BorrowerRepository>();
            services.AddScoped<GenreRepository>();
            services.AddScoped<PublicationRepository>();
            services.AddScoped<PublisherRepository>();
            services.AddScoped<ReservationRepository>();

            Seeders(services);
            
            services.AddAutoMapper(typeof(DataContext).Assembly);
            
            services.AddDbContext<DataContext>(x => 
                x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo(){Title = "Library API", Version = "v1"});
            });
            
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        private void Seeders(IServiceCollection service)
        {
            service.AddScoped<AuthorFactory>();
            service.AddScoped<BorrowerFactory>();
            service.AddScoped<GenreFactory>();
            service.AddScoped<PublicationFactory>();
            service.AddScoped<PublisherFactory>();
            service.AddScoped<ReservationFactory>();
            
            service.AddScoped<AuthorGenre>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(options => { options.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
            });
            
            // app.UseHttpsRedirection();
            
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
