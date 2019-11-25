using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace TomaattiAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TomaattiAPI", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigins",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

                //options.AddPolicy("AllowMethods",
                //builder => builder.AllowAnyMethod().AllowAnyHeader());

                //options.AddPolicy("AllowPut",
                //builder => builder.WithMethods("put"/*, "options"*/).AllowAnyHeader());

                //options.AddPolicy("AllowPut",
                //builder => builder.

                //options.AddPolicy("AllowHeaders",
                //builder =>
                //{
                //    builder.WithOrigins("*").AllowAnyHeader();
                //});
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TomaattiAPI V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors("AllowOrigins");
            app.UseCors("AllowMethods");
            //app.UseCors("AllowPut");
            //app.UseCors("AllowHeaders");


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
