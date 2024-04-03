using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIWeb_ISN.Data;
namespace APIWeb_ISN
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

            services.AddDbContext<APIWeb_ISNContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("APIWeb_ISNContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Safely access IServiceScopeFactory
            var serviceScopeFactory = app.ApplicationServices?.GetService<IServiceScopeFactory>();
            if (serviceScopeFactory != null)
            {
                using (var serviceScope = serviceScopeFactory.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<APIWeb_ISNContext>();
                    //context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}
