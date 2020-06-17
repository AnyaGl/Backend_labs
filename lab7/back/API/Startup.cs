using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using DAL;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.OpenApi.Models;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

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
            services.AddDbContext<DBContext>(builder =>
                builder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("API")));
            
            services.AddScoped<IBikeService, BikeService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ITypeService, TypeService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("api", new OpenApiInfo()
                {
                    Title = "bikesApi",
                    Version = "1.0"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/api/swagger.json", "bikes");
                });
            }
            
            app.UseStaticFiles();

            var path = Path.Combine(env.ContentRootPath, "images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            /*var provider = new FileExtensionContentTypeProvider();*/

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(path),
                RequestPath = "/images",
                ContentTypeProvider = new FileExtensionContentTypeProvider()
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
