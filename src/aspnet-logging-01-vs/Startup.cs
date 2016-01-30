namespace aspnet_logging_01_vs
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MyClass>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;

            loggerFactory.AddDebug(LogLevel.Debug);
                
            app.UseIISPlatformHandler();

            app.Run(async context =>
            {
                var myClass = context.RequestServices.GetService<MyClass>();

                myClass.DoSomething(1);
                myClass.DoSomething(20);
                myClass.DoSomething(-20);

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}