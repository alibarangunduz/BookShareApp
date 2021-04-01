using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthAPI.Business;
using AuthAPI.Business.Abstract;
using AuthAPI.Business.Concrete;
using AuthAPI.DataAccess.Abstract;
using AuthAPI.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthAPI.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
            }));

            services.AddControllers();
            services.AddSingleton<IAuthService, UserManager>();
            services.AddSingleton<IPostService, PostManager>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IPostRepository, PostRepository>();
            services.AddSingleton<IEncryptOperation, EncryptOperation>();
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "User registration ";
                    doc.Info.Version = "2.0.0";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Name = "Ali Baran Gündüz",
                        Url = "https://www.linkedin.com/in/ali-baran-g%C3%BCnd%C3%BCz-851204195/",
                        Email = "alibarangunduzz@gmail.com",
                    };
                });
            });
          


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            
            app.UseRouting();
            app.UseCors("ApiCorsPolicy");
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
