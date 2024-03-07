using DataAccess.DbConection.DbConection;
using Microsoft.EntityFrameworkCore;
using MilesCarRental.Business.Implementations;
using MilesCarRental.Business.Interfaces;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("MilesCarRental"));

            services.AddScoped<ILocationBusiness, LocationBusiness>();
            services.AddScoped<ICarBusiness, CarBusiness>();
            services.AddScoped<ICarRentalBusiness, CarRentalBusiness>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            #region Swagger Configuration
            app.UseSwagger();
            app.UseSwaggerUI();
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}