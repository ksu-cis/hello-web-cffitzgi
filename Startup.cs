using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloWeb
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
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();    // Useful developer crash info
            }
            else
            {
                app.UseExceptionHandler("/Error");  // Non developer crash info
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();              // Use https
            app.UseStaticFiles();                   // Uses the static files

            app.UseRouting();                       // Allows ASP.Net to respond to request appropriately

            app.UseAuthorization();                 // Allows for use of authorization techniques

            app.UseEndpoints(endpoints =>           // Draws the lines between the pages
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
