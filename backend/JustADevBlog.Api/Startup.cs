using System;
using System.IO;
using Swashbuckle.AspNetCore;
using JustADevBlog.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace JustADevBlog.Api
{
  /// <summary>
  /// </summary>
  public class Startup
  {
    /// <summary>
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    /// <summary>
    ///   This method gets called by the runtime. Use this method to add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddCors(options =>
      {
        options.AddPolicy("AllowSpecificOrigin", builder => 
                builder.WithOrigins(Configuration["FrontEndAddress"])
                .AllowAnyHeader()
                .AllowAnyMethod()
        );
      });
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "Just a Dev Blog - API", Version = "v1" });

        var basePath = AppContext.BaseDirectory;
        var xmlPath = Path.Combine(basePath, $"{Constants.JustADevBlog}.Api.xml");
        c.IncludeXmlComments(xmlPath);
      });
      services.AddMvc();
    }


    /// <summary>
    ///   This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      // Shows UseCors with named policy.
      app.UseCors("AllowSpecificOrigin");
      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint($"/swagger/V1/swagger.json", "Just a Dev Blog - API.v1");
        c.RoutePrefix = string.Empty;
      });

      app.UseMvc();

    }
  }
}
