using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingCartApi.Models;
using ShoppingCartApi.Services;
using Microsoft.Extensions.Options;
using ShoppingCartApi.Repositories;

namespace ShoppingCartApi
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
            
            services.Configure<ShoppingCartDatabaseSettings>(Configuration.GetSection(nameof(ShoppingCartDatabaseSettings)));

            services.AddSingleton<IShoppingCartDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ShoppingCartDatabaseSettings>>().Value);
            //services.AddScoped(serviceType: typeof(IProductRepository<>), typeof(ProductRepository<>));


            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();

            //services.AddTransient(s => new ShoppingCartRepository(new MongoDBContext(connectionString,databaseName)));

            services.AddControllers(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
