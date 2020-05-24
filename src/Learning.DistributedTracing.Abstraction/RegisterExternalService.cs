using Jaeger;
using Jaeger.Reporters;
using Jaeger.Samplers;
using Jaeger.Senders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Util;

namespace Learning.DistributedTracing.Abstraction
{
    public static class RegisterExternalService
    {
        public static IServiceCollection AddJaeger(this IServiceCollection services, string serviceName)
        {
            services.AddSingleton<ITracer>(sp =>
            {
                var loggerFactory = sp.GetRequiredService<ILoggerFactory>();

                var reporter = new RemoteReporter
                .Builder()
                .WithSender(new UdpSender("192.168.0.81",6831,0))
                .WithLoggerFactory(loggerFactory)
                .Build();

                var tracer = new Tracer
                .Builder(serviceName)
                .WithReporter(reporter)
                .WithSampler(new ConstSampler(true))
                .Build();

                // Allows code that can't use DI to also access the tracer.
                GlobalTracer.Register(tracer);

                return tracer;
            });

            //services.AddSingleton<ITracer>(serviceProvider =>
            //{

            //    // This will log to a default localhost installation of Jaeger.
            //    var tracer = new Tracer.Builder(serviceName)
            //        .WithSampler(new ConstSampler(true))
            //        .Build();

            //    // Allows code that can't use DI to also access the tracer.
            //    GlobalTracer.Register(tracer);

            //    return tracer;
            //});
            return services;
        }
    }
}
