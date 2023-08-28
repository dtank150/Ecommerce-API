using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities.Identity;
using API.Extension;
using API.Infrastructure.Identity;
using API.Repository;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace API
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
            services.AddCors((options) =>
            {
                options.AddPolicy("angularApplication", (builder) =>
                 {
                     builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .WithMethods("GET", "PUT", "POST", "DELETE")
                        .WithExposedHeaders("*");
                 });
            });

           /* services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy =>
                 {
                     policy.AllowAnyHeader().WithMethods("GET","POST","PUT","DELETE").AllowAnyMethod().WithOrigins("http://localhost:4200/").WithExposedHeaders("*");
                 });
            
            });*/
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            /* services.AddDbContext<StoreContext>(Options => Options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));*/
            services.AddDbContext<StoreContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           /* services.AddScoped<IConnectionMultiplexer>(c =>
            {
                var options = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(options);
            });*/
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IProduct, ProductRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrderService, OrderService>();
           // services.AddScoped<I, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<AppIdentityDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
            });
            services.AddIdentityCore<AppUser>(opt => { })
           .AddEntityFrameworkStores<AppIdentityDbContext>()
           .AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication();
            services.AddAuthorization();
            services.AddSweggerDocumentation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseSweggerDocumentation();

            app.UseCors("angularApplication");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // Seed the database
         //   StoreContextSeed.SeedAsync(dbContext);

            /*using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<Program>>();
            try
            {
                StoreContext context = services.GetRequiredService<StoreContext>();
                StoreContextSeed.SeedAsync(context).Wait();
            }
            catch (Exception e)
            {
                logger.LogError(e, "An error occured during migration");
            }*/
        }
    }
}
