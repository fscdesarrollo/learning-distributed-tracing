using Learning.DistributedTracing.Abstraction;
using Learning.DistributedTracing.Star.Api.Clients.War;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;

namespace Learning.DistributedTracing.Star.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOpenTracing();
            services.AddJaeger(services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>().ApplicationName);

            services.AddRefitClient<IWarsAPI>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:44377"));

        }

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
