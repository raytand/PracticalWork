using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PracticalWork.DataAccess.Context;
using PracticalWork.DataAccess.Model;
using PracticalWork.DataAccess.Repositories;

namespace PracticalWork
{
    public class Startup
	{
		private IConfiguration Configuration { get; set; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<IPasswordRepositories, PasswordRepositories>();
			Configuration.Bind("ConectionStrings");
            services.AddDbContext<CWContext>(options =>
    options.UseSqlite(Configuration.GetConnectionString("DefaultConection")));
			services.AddIdentity<User, IdentityRole>().AddRoles<IdentityRole>().AddEntityFrameworkStores<CWContext>();
           
			 
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/user/login";
                options.SlidingExpiration = true;
            });

			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.Name = "CWWebApp";
				options.LoginPath = "/user/login";
			});
            services.AddMvc();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
			});
		}
	}
}
