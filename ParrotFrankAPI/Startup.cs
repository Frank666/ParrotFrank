using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ParrotFrankEntities.parrot_frank;
using ParrotFrankData;
using ParrotFrankData.Products;
using ParrotFrankData.Tokens;
using ParrotFrankData.SubProducts;
using System.Linq;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace ParrotFrankAPI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //add controllers
            services.AddControllers();

            //Entity Framework
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            services.AddDbContextPool<MySQLContext>(
                options => options.UseMySql(configuration.GetConnectionString("Parrot_Frank")
            ));

            //Security Middleware
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = true;
            o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

            services.AddOpenApiDocument(document =>
            {
                document.Title = "Parrot Frank Web API";
                document.Description = "Web API para proyecto de Parrot";

                // CONFIGURAMOS LA SEGURIDAD JWT PARA SWAGGER,
                // PERMITE AÑADIR EL TOKEN JWT A LA CABECERA.
                document.AddSecurity("JWT", Enumerable.Empty<string>(),
                    new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Copia y pega el Token en el campo 'Value:' así: Bearer {Token JWT}."
                    }
                );

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            services.AddScoped<ProductsRepository>();
            services.AddScoped<SubProductsRepository>();
            services.AddScoped<UsersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }    
    }
}
