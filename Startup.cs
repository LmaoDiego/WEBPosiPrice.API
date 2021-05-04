using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PosiPrice.API.Domain.Persistence.Contexts;
using PosiPrice.API.Domain.Persistence.Repositories;
using PosiPrice.API.Domain.Services;
using PosiPrice.API.Persitence.Repositories;
using PosiPrice.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosiPrice.API
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

            // DbContext Configuration
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Dependency Injection Configuration
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTagRepository, ProductTagRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserVoteRepository, UserVoteRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTagService, ProductTagService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserVoteService, UserVoteService>();
            services.AddScoped<IVoteService, VoteService>();

            // Endpoints Case Conventions Configuration

            services.AddRouting(options => options.LowercaseUrls = true);

            // AutoMapper initialization
            services.AddAutoMapper(typeof(Startup));


            // Documentation Setup
            services.AddSwaggerGen(c =>
            {
               
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PosiPrice.API", Version = "v1" });
                c.EnableAnnotations();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PosiPrice.API v1"));
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
