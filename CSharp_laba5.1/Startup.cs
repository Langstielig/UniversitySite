using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_laba5._1.Service;
using CSharp_laba5._1.Controllers;
using CSharp_laba5._1.Domains.Repositories.EntityFramework;
using CSharp_laba5._1.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CSharp_laba5._1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //��������� Project � appsattings � ������� Config
            Configuration.Bind("Project", new Config());

            services.AddMvc();

            //���������� ��������� � �����-��������
            services.AddTransient<EFStudentsRepository>();
            services.AddTransient<EFTextFieldsRepository>();
            services.AddTransient<EFGroupsRepository>();
            services.AddTransient<EFActivitiesRepository>();
            services.AddTransient<EFStudentActivityRepository>();
            services.AddTransient<DataManager>();

            //���������� ��
            services.AddDbContext<UniversityContext>(x => x.UseSqlServer(Config.ConnectionString));

            //
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 5; //����������� ����� ������
                opts.Password.RequireNonAlphanumeric = false; 
                opts.Password.RequireLowercase = false; //�������������� ������������� ��������� ����
                opts.Password.RequireUppercase = false; //�������������� ������������� ��������� ����
                opts.Password.RequireDigit = false; //�������������� ������������� ����

            }).AddEntityFrameworkStores<UniversityContext>().AddDefaultTokenProviders();

            //cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "university";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //��������� �������� ����������� ��� ������, ��������� �������� ��� ������������ �����
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //��������� ��������� ������������ � �������������
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                //���������� ������������� � asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) //���� �� � �������� ����������, �� ������������ ������
            {
                app.UseDeveloperExceptionPage();
            }

            //��������� ������� �����������

            //���������� ��������� ����� (��-�� ���� ���������� html ������, ������� ���� �� ����������)
            app.UseStaticFiles();

            //������� �������������
            app.UseRouting();

            //����������� �������������� � �����������
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //������������� �������������, ������������ ������ ��������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("_Layout.cshtml","{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
