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
            //связываем Project в appsattings с классом Config
            Configuration.Bind("Project", new Config());

            services.AddMvc();

            //подключаем интерфейс и класс-помощник
            services.AddTransient<EFStudentsRepository>();
            services.AddTransient<EFTextFieldsRepository>();
            services.AddTransient<EFGroupsRepository>();
            services.AddTransient<EFActivitiesRepository>();
            services.AddTransient<EFStudentActivityRepository>();
            services.AddTransient<DataManager>();

            //подключаем бд
            services.AddDbContext<UniversityContext>(x => x.UseSqlServer(Config.ConnectionString));

            //
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 5; //минимальная длина пароля
                opts.Password.RequireNonAlphanumeric = false; 
                opts.Password.RequireLowercase = false; //обязательность использования маленьких букв
                opts.Password.RequireUppercase = false; //обязательность использования заглавных букв
                opts.Password.RequireDigit = false; //обязательность использования цифр

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

            //настройка политики авторизации для админа, добавляем политику для пользователя админ
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //добавляем поддержку контроллеров и представлений
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                //выставляем совместимость с asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) //если мы в процессе разработки, то показываются ошибки
            {
                app.UseDeveloperExceptionPage();
            }

            //требуемый порядок подключения

            //подключаем статичные файлы (из-за него появляется html шаблон, который пока не появляется)
            app.UseStaticFiles();

            //система маршрутизации
            app.UseRouting();

            //подключение аутентификации и авторизации
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //использование маршрутизации, регистрируем нужные маршруты
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("_Layout.cshtml","{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
