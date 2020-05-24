# learning-distributed-tracing
Repository to implement some tools that allow distributed tracking and monitoring .Net Core based applications.

## Purpose
Implement tools that allow distributed tracing, loggin and monitoring of applications. Providers:
 - Jaeger: https://www.jaegertracing.io/
 - Azure:
	 - Application Insights : https://github.com/microsoft/ApplicationInsights-Home

## Frameworks/Libraries
 - Source Code:
	 - .Net Core 3.1: https://docs.microsoft.com/es-es/dotnet/core/
 - Loggin:
    - Serilog: https://github.com/serilog/serilog
 - Container:
	 - Docker: https://www.docker.com/
	 - Docker Compose: https://docs.docker.com/compose/

### Docker
- Jeager: 
    ```sh
    docker run -d --name jaeger \
      -e COLLECTOR_ZIPKIN_HTTP_PORT=9411 \
      -p 5775:5775/udp \
      -p 6831:6831/udp \
      -p 6832:6832/udp \
      -p 5778:5778 \
      -p 16686:16686 \
      -p 14268:14268 \
      -p 14250:14250 \
      -p 9411:9411 \
      jaegertracing/all-in-one:1.17
    ```