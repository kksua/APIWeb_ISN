using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        // 这个方法被运行时调用。用于将服务添加到容器中。
        public void ConfigureServices(IServiceCollection services)
        {
            // 配置数据库上下文
            services.AddDbContext<APIWeb_ISNContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("APIWeb_ISNContext")));

            // 添加MVC服务
            services.AddControllersWithViews();
        }

        // 这个方法被运行时调用。用于配置HTTP请求管道。
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
