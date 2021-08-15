using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clavax.DAL;
using Clavax.Utility.IRepositry;
using Clavax.Utility.RepositryService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clavax
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
            services.AddMvc();
            services.AddDbContext<DrNaazdbContext>(
 options => options.UseSqlServer("workstation id=DrNaazdb.mssql.somee.com;packet size=4096;user id=drnaaz_SQLLogin_1;pwd=5hr4to2kem;data source=DrNaazdb.mssql.somee.com;persist security info=False;initial catalog=DrNaazdb;"));


            services.AddScoped<IEmployee, EmployeeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=GetEmployees}/{id?}");
            });
        }
    }
}
